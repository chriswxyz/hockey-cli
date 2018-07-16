// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using HockeyCli;
//
//    var gameContent = GameContent.FromJson(jsonString);

namespace HockeyCli.NHLApi.GameContent
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public partial class GameContent
    {
        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("editorial")]
        public Editorial Editorial { get; set; }

        [JsonProperty("media")]
        public GameContentMedia Media { get; set; }

        [JsonProperty("highlights")]
        public Highlights Highlights { get; set; }
    }

    public partial class Editorial
    {
        [JsonProperty("preview")]
        public Articles Preview { get; set; }

        [JsonProperty("articles")]
        public Articles Articles { get; set; }

        [JsonProperty("recap")]
        public Articles Recap { get; set; }
    }

    public partial class Articles
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("topicList", NullValueHandling = NullValueHandling.Ignore)]
        public string TopicList { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public string Date { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("headline", NullValueHandling = NullValueHandling.Ignore)]
        public string Headline { get; set; }

        [JsonProperty("subhead", NullValueHandling = NullValueHandling.Ignore)]
        public string Subhead { get; set; }

        [JsonProperty("seoTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoTitle { get; set; }

        [JsonProperty("seoDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoDescription { get; set; }

        [JsonProperty("seoKeywords", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoKeywords { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("commenting", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Commenting { get; set; }

        [JsonProperty("tagline", NullValueHandling = NullValueHandling.Ignore)]
        public string Tagline { get; set; }

        [JsonProperty("tokenData", NullValueHandling = NullValueHandling.Ignore)]
        public TokenData TokenData { get; set; }

        [JsonProperty("contributor", NullValueHandling = NullValueHandling.Ignore)]
        public ItemContributor Contributor { get; set; }

        [JsonProperty("keywordsDisplay", NullValueHandling = NullValueHandling.Ignore)]
        public KeywordsAll[] KeywordsDisplay { get; set; }

        [JsonProperty("keywordsAll", NullValueHandling = NullValueHandling.Ignore)]
        public KeywordsAll[] KeywordsAll { get; set; }

        [JsonProperty("approval", NullValueHandling = NullValueHandling.Ignore)]
        public string Approval { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("dataURI", NullValueHandling = NullValueHandling.Ignore)]
        public string DataUri { get; set; }

        [JsonProperty("primaryKeyword", NullValueHandling = NullValueHandling.Ignore)]
        public KeywordsAll PrimaryKeyword { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public ItemMedia Media { get; set; }

        [JsonProperty("preview", NullValueHandling = NullValueHandling.Ignore)]
        public string Preview { get; set; }

        [JsonProperty("guid", NullValueHandling = NullValueHandling.Ignore)]
        public string Guid { get; set; }

        [JsonProperty("mediaState", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaState { get; set; }

        [JsonProperty("mediaPlaybackId", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaPlaybackId { get; set; }

        [JsonProperty("mediaFeedType", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaFeedType { get; set; }

        [JsonProperty("callLetters", NullValueHandling = NullValueHandling.Ignore)]
        public string CallLetters { get; set; }

        [JsonProperty("eventId", NullValueHandling = NullValueHandling.Ignore)]
        public string EventId { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("freeGame", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FreeGame { get; set; }

        [JsonProperty("feedName", NullValueHandling = NullValueHandling.Ignore)]
        public string FeedName { get; set; }

        [JsonProperty("gamePlus", NullValueHandling = NullValueHandling.Ignore)]
        public bool? GamePlus { get; set; }
    }

    public partial class ItemContributor
    {
        [JsonProperty("contributors")]
        public ContributorElement[] Contributors { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public partial class ContributorElement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }
    }

    public partial class KeywordsAll
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public partial class ItemMedia
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("altText")]
        public string AltText { get; set; }

        [JsonProperty("cuts")]
        public Dictionary<string, Cut> Cuts { get; set; }
    }

    public partial class Cut
    {
        [JsonProperty("aspectRatio")]
        public AspectRatio AspectRatio { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("at2x")]
        public string At2X { get; set; }

        [JsonProperty("at3x")]
        public string At3X { get; set; }
    }

    public partial class TokenData
    {
        [JsonProperty("token-8F80D6C0928962A5C7B88")]
        public TokenDataToken0509C971294Bf86C57E92 Token8F80D6C0928962A5C7B88 { get; set; }

        [JsonProperty("token-2D333C2CFE0ABB0280491")]
        public TokenDataToken0509C971294Bf86C57E92 Token2D333C2Cfe0Abb0280491 { get; set; }

        [JsonProperty("token-09B5127090A511A0C1D85")]
        public TokenDataToken0509C971294Bf86C57E92 Token09B5127090A511A0C1D85 { get; set; }

        [JsonProperty("token-72322C5EA34567789BEB8")]
        public TokenDataToken0509C971294Bf86C57E92 Token72322C5Ea34567789Beb8 { get; set; }

        [JsonProperty("token-DBAA52F808DC45F9B3686")]
        public TokenDataToken0509C971294Bf86C57E92 TokenDbaa52F808Dc45F9B3686 { get; set; }

        [JsonProperty("token-990C545EA3E2AD16DBEB2")]
        public TokenDataToken0509C971294Bf86C57E92 Token990C545Ea3E2Ad16Dbeb2 { get; set; }

        [JsonProperty("token-10D802FC299BDF743688B")]
        public TokenDataToken0509C971294Bf86C57E92 Token10D802Fc299Bdf743688B { get; set; }

        [JsonProperty("token-059F51A39F63C66E3D2B1")]
        public TokenDataToken0509C971294Bf86C57E92 Token059F51A39F63C66E3D2B1 { get; set; }

        [JsonProperty("token-E94795694E49BD7AC779D")]
        public TokenDataToken0509C971294Bf86C57E92 TokenE94795694E49Bd7Ac779D { get; set; }

        [JsonProperty("token-D30C2C25DE9DC8D846983")]
        public TokenDataToken0509C971294Bf86C57E92 TokenD30C2C25De9Dc8D846983 { get; set; }

        [JsonProperty("token-05C1FC8A267E08FF4ACAE")]
        public TokenDataToken0509C971294Bf86C57E92 Token05C1Fc8A267E08Ff4Acae { get; set; }

        [JsonProperty("token-AB9439068E6D658192593")]
        public TokenDataToken0509C971294Bf86C57E92 TokenAb9439068E6D658192593 { get; set; }

        [JsonProperty("token-80A6F74599C18D72E25BC")]
        public TokenDataToken0509C971294Bf86C57E92 Token80A6F74599C18D72E25Bc { get; set; }

        [JsonProperty("token-0509C971294BF86C57E92")]
        public TokenDataToken0509C971294Bf86C57E92 Token0509C971294Bf86C57E92 { get; set; }

        [JsonProperty("token-29E429F1259DCA55E3B8B")]
        public TokenDataToken0509C971294Bf86C57E92 Token29E429F1259Dca55E3B8B { get; set; }

        [JsonProperty("token-53C07C94B31E466249C8D")]
        public TokenDataToken0509C971294Bf86C57E92 Token53C07C94B31E466249C8D { get; set; }

        [JsonProperty("token-64540695D5A21B07836AD")]
        public TokenDataToken0509C971294Bf86C57E92 Token64540695D5A21B07836Ad { get; set; }

        [JsonProperty("token-7E1D8DB36BBA429700BAD")]
        public TokenDataToken0509C971294Bf86C57E92 Token7E1D8Db36Bba429700Bad { get; set; }

        [JsonProperty("token-1F55BC66AC2B481EEBD94")]
        public TokenDataToken0509C971294Bf86C57E92 Token1F55Bc66Ac2B481Eebd94 { get; set; }

        [JsonProperty("token-B73EA922412AA3FD2E49A")]
        public TokenDataToken0509C971294Bf86C57E92 TokenB73Ea922412Aa3Fd2E49A { get; set; }

        [JsonProperty("token-98B334E1150C5874F7288")]
        public TokenDataToken0509C971294Bf86C57E92 Token98B334E1150C5874F7288 { get; set; }

        [JsonProperty("token-E59202785EC6C2F0B0398")]
        public TokenDataToken0509C971294Bf86C57E92 TokenE59202785Ec6C2F0B0398 { get; set; }

        [JsonProperty("token-1BD53A227540E5EB4E7B1")]
        public TokenDataToken0509C971294Bf86C57E92 Token1Bd53A227540E5Eb4E7B1 { get; set; }

        [JsonProperty("token-203C5DE9F9FE8A1F7FAA4")]
        public TokenDataToken0509C971294Bf86C57E92 Token203C5De9F9Fe8A1F7Faa4 { get; set; }

        [JsonProperty("token-8C742E2E753E879F6108C")]
        public TokenDataToken0509C971294Bf86C57E92 Token8C742E2E753E879F6108C { get; set; }

        [JsonProperty("token-798BB20D0C3E16C191AA4")]
        public TokenDataToken0509C971294Bf86C57E92 Token798Bb20D0C3E16C191Aa4 { get; set; }

        [JsonProperty("token-D1C2C73F1A42CE5E225AA")]
        public TokenDataToken0509C971294Bf86C57E92 TokenD1C2C73F1A42Ce5E225Aa { get; set; }

        [JsonProperty("token-3544FCCD1794701481C98")]
        public TokenDataToken0509C971294Bf86C57E92 Token3544Fccd1794701481C98 { get; set; }

        [JsonProperty("token-7449B4250175AF7F7AFB7")]
        public TokenDataToken0509C971294Bf86C57E92 Token7449B4250175Af7F7Afb7 { get; set; }

        [JsonProperty("token-B75369371E2FF94F8CE98")]
        public TokenDataToken0509C971294Bf86C57E92 TokenB75369371E2Ff94F8Ce98 { get; set; }

        [JsonProperty("token-BB4D60100F94025287C82")]
        public TokenDataToken0509C971294Bf86C57E92 TokenBb4D60100F94025287C82 { get; set; }

        [JsonProperty("token-A7932257E7CAE0BBC0A8F")]
        public TokenDataToken0509C971294Bf86C57E92 TokenA7932257E7Cae0Bbc0A8F { get; set; }

        [JsonProperty("token-840EB1F096561DD873F9C")]
        public TokenDataToken0509C971294Bf86C57E92 Token840Eb1F096561Dd873F9C { get; set; }

        [JsonProperty("token-2A4B92E71D26B88A85CB6")]
        public TokenDataToken0509C971294Bf86C57E92 Token2A4B92E71D26B88A85Cb6 { get; set; }

        [JsonProperty("token-7326FD5A2E9452B200685")]
        public TokenDataToken0509C971294Bf86C57E92 Token7326Fd5A2E9452B200685 { get; set; }

        [JsonProperty("token-E648A84990507F3AC9BBA")]
        public TokenDataToken0509C971294Bf86C57E92 TokenE648A84990507F3Ac9Bba { get; set; }

        [JsonProperty("token-D80C9EBE9CB84BC281895")]
        public TokenDataToken0509C971294Bf86C57E92 TokenD80C9Ebe9Cb84Bc281895 { get; set; }

        [JsonProperty("token-F0344E2FAA03ADDE2B991")]
        public TokenDataToken0509C971294Bf86C57E92 TokenF0344E2Faa03Adde2B991 { get; set; }

        [JsonProperty("token-2E449F00D71342F8DEDA4")]
        public TokenDataToken0509C971294Bf86C57E92 Token2E449F00D71342F8Deda4 { get; set; }

        [JsonProperty("token-8D125D52542964E817F90")]
        public TokenDataToken0509C971294Bf86C57E92 Token8D125D52542964E817F90 { get; set; }

        [JsonProperty("token-804DB39E0E925A45EBB90")]
        public TokenDataToken0509C971294Bf86C57E92 Token804Db39E0E925A45Ebb90 { get; set; }

        [JsonProperty("token-8A80C3D56C320540F9980")]
        public TokenDataToken0509C971294Bf86C57E92 Token8A80C3D56C320540F9980 { get; set; }

        [JsonProperty("token-66CD533DDE69F8F2738BF")]
        public TokenDataToken0509C971294Bf86C57E92 Token66Cd533Dde69F8F2738Bf { get; set; }

        [JsonProperty("token-5F85F7D6BC68E60BEA096")]
        public TokenDataToken0509C971294Bf86C57E92 Token5F85F7D6Bc68E60Bea096 { get; set; }

        [JsonProperty("token-49170F2C1739C80E31AB6")]
        public TokenDataToken0509C971294Bf86C57E92 Token49170F2C1739C80E31Ab6 { get; set; }

        [JsonProperty("token-52E50FB5B39D6F7ADD184")]
        public TokenDataToken0509C971294Bf86C57E92 Token52E50Fb5B39D6F7Add184 { get; set; }

        [JsonProperty("token-50DB1EEC87BCAD361CDA4")]
        public TokenDataToken0509C971294Bf86C57E92 Token50Db1Eec87Bcad361Cda4 { get; set; }

        [JsonProperty("token-5E9E21491736143BAF184")]
        public TokenDataToken0509C971294Bf86C57E92 Token5E9E21491736143Baf184 { get; set; }

        [JsonProperty("token-3511EAB2EAEDC5FF7E996")]
        public TokenDataToken233106C61Bd4C1D2Ef6Ab Token3511Eab2Eaedc5Ff7E996 { get; set; }

        [JsonProperty("token-CCB6A2DAB0D741FF1DFA6")]
        public TokenDataToken0509C971294Bf86C57E92 TokenCcb6A2Dab0D741Ff1Dfa6 { get; set; }

        [JsonProperty("token-C29DDBB3283E0D919348F")]
        public TokenDataToken233106C61Bd4C1D2Ef6Ab TokenC29Ddbb3283E0D919348F { get; set; }

        [JsonProperty("token-233106C61BD4C1D2EF6AB")]
        public TokenDataToken233106C61Bd4C1D2Ef6Ab Token233106C61Bd4C1D2Ef6Ab { get; set; }
    }

    public partial class TokenDataToken0509C971294Bf86C57E92
    {
        [JsonProperty("tokenGUID")]
        public string TokenGuid { get; set; }

        [JsonProperty("type")]
        public Token0509C971294Bf86C57E92Type Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("teamId")]
        public TeamId TeamId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("seoName")]
        public string SeoName { get; set; }
    }

    public partial class TokenDataToken233106C61Bd4C1D2Ef6Ab
    {
        [JsonProperty("tokenGUID")]
        public string TokenGuid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("hrefMobile")]
        public string HrefMobile { get; set; }
    }

    public partial class Highlights
    {
        [JsonProperty("scoreboard")]
        public Articles Scoreboard { get; set; }

        [JsonProperty("gameCenter")]
        public Articles GameCenter { get; set; }
    }

    public partial class GameContentMedia
    {
        [JsonProperty("epg")]
        public Articles[] Epg { get; set; }

        [JsonProperty("milestones")]
        public Milestones Milestones { get; set; }
    }

    public partial class Milestones
    {
    }

    public enum AspectRatio { The169 };

    public enum TeamId { The24, The30 };

    public enum Token0509C971294Bf86C57E92Type { PlayerCard };

    public partial class GameContent
    {
        public static GameContent FromJson(string json) => JsonConvert.DeserializeObject<GameContent>(json, Converter.Settings);
    }

    static class AspectRatioExtensions
    {
        public static AspectRatio? ValueForString(string str)
        {
            switch (str)
            {
                case "16:9": return AspectRatio.The169;
                default: return null;
            }
        }

        public static AspectRatio ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this AspectRatio value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case AspectRatio.The169: serializer.Serialize(writer, "16:9"); break;
            }
        }
    }

    static class TeamIdExtensions
    {
        public static TeamId? ValueForString(string str)
        {
            switch (str)
            {
                case "24": return TeamId.The24;
                case "30": return TeamId.The30;
                default: return null;
            }
        }

        public static TeamId ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this TeamId value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case TeamId.The24: serializer.Serialize(writer, "24"); break;
                case TeamId.The30: serializer.Serialize(writer, "30"); break;
            }
        }
    }

    static class Token0509C971294Bf86C57E92TypeExtensions
    {
        public static Token0509C971294Bf86C57E92Type? ValueForString(string str)
        {
            switch (str)
            {
                case "playerCard": return Token0509C971294Bf86C57E92Type.PlayerCard;
                default: return null;
            }
        }

        public static Token0509C971294Bf86C57E92Type ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Token0509C971294Bf86C57E92Type value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Token0509C971294Bf86C57E92Type.PlayerCard: serializer.Serialize(writer, "playerCard"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this GameContent self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AspectRatio) || t == typeof(TeamId) || t == typeof(Token0509C971294Bf86C57E92Type) || t == typeof(AspectRatio?) || t == typeof(TeamId?) || t == typeof(Token0509C971294Bf86C57E92Type?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(AspectRatio))
                return AspectRatioExtensions.ReadJson(reader, serializer);
            if (t == typeof(TeamId))
                return TeamIdExtensions.ReadJson(reader, serializer);
            if (t == typeof(Token0509C971294Bf86C57E92Type))
                return Token0509C971294Bf86C57E92TypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(AspectRatio?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return AspectRatioExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(TeamId?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return TeamIdExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Token0509C971294Bf86C57E92Type?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return Token0509C971294Bf86C57E92TypeExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(AspectRatio))
            {
                ((AspectRatio)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(TeamId))
            {
                ((TeamId)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Token0509C971294Bf86C57E92Type))
            {
                ((Token0509C971294Bf86C57E92Type)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
