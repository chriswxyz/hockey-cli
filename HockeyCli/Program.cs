using ConsoleTables;
using Funccy;
using HockeyCli.NHLApi.GameContent;
using HockeyCli.NHLApi.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HockeyCli
{
    class GameSummary
    {
        public GameSummary(string teams, string time, string channels)
        {
            Teams = teams;
            Time = time;
            Channels = channels;
        }

        public string Teams { get; }
        public string Time { get; }
        public string Channels { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var task = GetGameSummaries(TimeZoneInfo.Local, DateTime.UtcNow);

            var games = task.Result;

            var output = games
                .MapA(CreateGameTable)
                .Extract(
                    t => t.ToMarkDownString(),
                    ex => $"Could not load schedule: {ex.Message}"
                )
                ;

            Console.WriteLine(output);

            Console.ReadLine();
        }

        private static ConsoleTable CreateGameTable(IEnumerable<GameSummary> gs)
        {
            var table = new ConsoleTable("Game", "Time", "Channels");
            table.Options.EnableCount = false;
            foreach (var game in gs)
            {
                table.AddRow(game.Teams, game.Time, game.Channels);
            }

            return table;
        }

        static async Task<OneOf<IEnumerable<GameSummary>, Exception>> GetGameSummaries(TimeZoneInfo localTimeZone, DateTime now)
        {
            var client = new NHLClient();
            var content = (await client.GetSchedule())
                .MapA(s => GetGamesAndContent(s, client))
                .MapA(async s => (await s).WhereA())
                .MapA(async s => (await s).Select(x => GetGameSummary(localTimeZone, now, x.game, x.gameConent)))
                .Extract(
                    async ok => new OneOf<IEnumerable<GameSummary>, Exception>(await ok),
                    async ex => new OneOf<IEnumerable<GameSummary>, Exception>(ex)
                )
                ;

            return await content;
        }

        private static async Task<IEnumerable<OneOf<(Game game, GameContent gameConent), Exception>>> GetGamesAndContent(Schedule s, NHLClient client)
        {
            return await s.Dates
                    .FirstMaybe()
                    .Map(d => d.Games
                        .Select(async x => (await client.GetGameContent(x.GamePk)).MapA(z => (game: x, gameConent: z)))
                        .WhenAll())
                    .Extract(async () => new OneOf<(Game, GameContent), Exception>(new Exception("no games today")).AsArrayOfOne())
                    ;
        }

        public static GameSummary GetGameSummary(TimeZoneInfo localTimeZone, DateTime now, Game game, GameContent gameContent)
        {
            var teams = GetTeams(game);
            var time = GetTime(localTimeZone, now, game);
            var channels = GetChannels(gameContent);

            return new GameSummary(teams, time, channels);
        }

        public static string GetTeams(Game g)
        {
            var h = g.Teams.Home.Team.Name;
            var a = g.Teams.Away.Team.Name;
            return $"{a} at {h}";
        }

        public static string GetTime(TimeZoneInfo localTimeZone, DateTime now, Game g)
        {
            var t = g.GameDate;

            var lt = TimeZoneInfo
                .ConvertTimeFromUtc(t.DateTime, localTimeZone)
                .ToString("hh:mm tt");

            var timeUntil = t.DateTime
                .Subtract(now)
                .Chain(x => x.TotalMilliseconds > 0
                    ? $"{x.Hours}h {x.Minutes}m"
                    : $"In Progress");

            return $"{lt} ({timeUntil})";
        }

        private static string GetChannels(GameContent gameContent)
        {
            //hacky but not seeing a api data point for what channels the game is on
            //it's typically the first part of the preview in the format,
            //and thats inside a bunch of html tags that aren't even balanced
            //7:30PM ET; CH1, CH2, CH3, CH4
            return gameContent
                .Editorial
                .Preview
                .Items
                .FirstMaybe()
                .Bind(ChannelsFromItem)
                .Extract("???");
        }

        private static Maybe<string> ChannelsFromItem(Item x)
        {
            return Regex
                .Split(x.Preview, "<(\\/|[0-9A-Za-z])*>", RegexOptions.ExplicitCapture)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .ToArray()[1]
                .Split("; ")
                .ElementAtMaybe(1)
                .Map(v => v
                    .Split(", ")
                    .Where(c => !c.Equals("NHL.TV", StringComparison.InvariantCultureIgnoreCase))
                    .StringJoin("/"))
                ;
        }
    }

    public static class Extensions
    {
        public static string StringJoin<T>(this IEnumerable<T> coll, string delim)
        {
            return string.Join(delim, coll);
        }

        public static IEnumerable<T> AsArrayOfOne<T>(this T o)
        {
            return new[] { o };
        }

        public static string[] Split(this string str, string separator)
        {
            return str.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static Maybe<T> ElementAtMaybe<T>(this ICollection<T> coll, int idx)
        {
            try
            {
                return new Maybe<T>(coll.ElementAt(idx));
            }
            catch (ArgumentOutOfRangeException)
            {
                return new Maybe<T>();
            }
        }
    }
}
