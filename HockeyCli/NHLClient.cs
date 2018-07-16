using Funccy;
using HockeyCli.NHLApi.GameContent;
using HockeyCli.NHLApi.Schedule;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace HockeyCli
{
    public static class HttpClientExtensions
    {
        public static async Task<OneOf<T, Exception>> GetAndHandle<T>(this HttpClient http, string uri, Func<string, T> fromJson)
        {
            try
            {
                var res = await http.GetAsync(uri);
                var json = await res.Content.ReadAsStringAsync();
                var o = fromJson(json);
                return new OneOf<T, Exception>(o);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new OneOf<T, Exception>(e);
            }
        }
    }

    class NHLClient
    {
        public async Task<OneOf<Schedule, Exception>> GetSchedule()
        {
            using (var http = new HttpClient())
            {
                return await http.GetAndHandle("http://statsapi.web.nhl.com/api/v1/schedule", Schedule.FromJson);
            }
        }

        public async Task<OneOf<GameContent, Exception>> GetGameContent(long gamePk)
        {
            using (var http = new HttpClient())
            {
                return await http.GetAndHandle($"http://statsapi.web.nhl.com/api/v1/game/{gamePk}/content", GameContent.FromJson);
            }
        }
    }
}
