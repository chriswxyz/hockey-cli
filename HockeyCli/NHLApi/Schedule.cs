// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using HockeyCli;
//
//    var schedule = Schedule.FromJson(jsonString);

//https://app.quicktype.io/#l=cs&r=json2csharp

namespace HockeyCli.NHLApi.Schedule
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Globalization;

    public partial class Schedule
    {
        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("totalItems")]
        public long TotalItems { get; set; }

        [JsonProperty("totalEvents")]
        public long TotalEvents { get; set; }

        [JsonProperty("totalGames")]
        public long TotalGames { get; set; }

        [JsonProperty("totalMatches")]
        public long TotalMatches { get; set; }

        [JsonProperty("wait")]
        public long Wait { get; set; }

        [JsonProperty("dates")]
        public Date[] Dates { get; set; }
    }

    public partial class Date
    {
        [JsonProperty("date")]
        public System.DateTimeOffset DateDate { get; set; }

        [JsonProperty("totalItems")]
        public long TotalItems { get; set; }

        [JsonProperty("totalEvents")]
        public long TotalEvents { get; set; }

        [JsonProperty("totalGames")]
        public long TotalGames { get; set; }

        [JsonProperty("totalMatches")]
        public long TotalMatches { get; set; }

        [JsonProperty("games")]
        public Game[] Games { get; set; }

        [JsonProperty("events")]
        public object[] Events { get; set; }

        [JsonProperty("matches")]
        public object[] Matches { get; set; }
    }

    public partial class Game
    {
        [JsonProperty("gamePk")]
        public long GamePk { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("gameDate")]
        public System.DateTimeOffset GameDate { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("teams")]
        public Teams Teams { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("abstractGameState")]
        public string AbstractGameState { get; set; }

        [JsonProperty("codedGameState")]
        public string CodedGameState { get; set; }

        [JsonProperty("detailedState")]
        public string DetailedState { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("startTimeTBD")]
        public bool StartTimeTbd { get; set; }
    }

    public partial class Teams
    {
        [JsonProperty("away")]
        public Away Away { get; set; }

        [JsonProperty("home")]
        public Away Home { get; set; }
    }

    public partial class Away
    {
        [JsonProperty("leagueRecord")]
        public LeagueRecord LeagueRecord { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("team")]
        public Team Team { get; set; }
    }

    public partial class LeagueRecord
    {
        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("ot")]
        public long Ot { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public partial class Venue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public partial class Schedule
    {
        public static Schedule FromJson(string json) => JsonConvert.DeserializeObject<Schedule>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Schedule self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
