using System;
using System.Collections.Generic;
using System.Text;
using bikabika.API.Data;
using System.Text.Json.Serialization;
using bikabika.API.Response;

namespace bikabika.API.Response
{
    internal class ResponseBase
    {
        public int code { get; set; }
        public string message { get; set; }

    }

    internal class CategoriesResponse : ResponseBase
    {
        public CategoryData data { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(CategoriesResponse))]
    internal partial class CategoriesResponseContext : JsonSerializerContext
    { }
    internal class ComicsResponse : ResponseBase
    {
        public ComicsData data { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ComicsResponse))]
    internal partial class ComicsResponseContext : JsonSerializerContext
    { }
    internal class ComicInfoResponse : ResponseBase
    {
        public ComicInfoData data { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ComicInfoResponse))]
    internal partial class ComicInfoResponseContext : JsonSerializerContext
    { }
    internal class EpisodeResponse : ResponseBase
    {

        public EpisodeData data { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(EpisodeResponse))]
    internal partial class EpisodeResponseContext : JsonSerializerContext
    { }
    internal class KeywordsResponse : ResponseBase
    {

        public KeywordsData data { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(KeywordsResponse))]
    internal partial class KeywordsResponseContext : JsonSerializerContext
    { }
    internal class ProfileResponse : ResponseBase
    {

        public UserData data { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ProfileResponse))]
    internal partial class ProfileResponseContext : JsonSerializerContext
    { }
    internal class SignInResponse : ResponseBase
    {

        public SignInData data { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(SignInResponse))]
    internal partial class SignInResponseContext : JsonSerializerContext
    { }
    internal class CommentsResponse
    {

        public CommentsData data { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(CommentsResponse))]
    internal partial class CommentsResponseContext : JsonSerializerContext
    { }
    internal class PictureResponse
    {

        public PictureData data { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(PictureResponse))]
    internal partial class PictureResponseContext : JsonSerializerContext
    { }





}
