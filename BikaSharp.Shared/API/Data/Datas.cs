using System;
using System.Collections.Generic;
using System.Text;
using bikabika.API.Block;
using bikabika.API.Page;
using System.Text.Json.Serialization;

namespace bikabika.API.Data
{
    internal class CategoryData
    {
        public List<Category> categories { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(CategoryData))]
    internal partial class CategoryDataContext : JsonSerializerContext
    { }
    internal class ComicsData
    {
        public ComicsPage comics { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ComicsData))]
    internal partial class ComicsDataContext : JsonSerializerContext
    { }

    internal class ComicInfoData
    {
        public ComicInfo comic { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ComicInfoData))]
    internal partial class ComicInfoDataContext : JsonSerializerContext
    { }

    internal class EpisodeData
    {
        public EpisodePage eps { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(EpisodeData))]
    internal partial class EpisodeDataContext : JsonSerializerContext
    { }
    internal class KeywordsData
    {
        public List<string> keywords { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(KeywordsData))]
    internal partial class KeywordsDataContext : JsonSerializerContext
    { }
    internal class UserData
    {
        public User user { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(UserData))]
    internal partial class UserDataContext : JsonSerializerContext
    { }
    internal class SignInData
    {
        public string token { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(SignInData))]
    internal partial class SignInDataContext : JsonSerializerContext
    { }
    internal class CommentsData
    {
        public CommentsPage comments { get; set; }
        public List<Comment> topComments { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(CommentsData))]
    internal partial class CommentsDataContext : JsonSerializerContext
    { }
    internal class PictureData
    {
        public PicturePage pages { get; set; }
        public Ep ep { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(PictureData))]
    internal partial class PictureDataContext : JsonSerializerContext
    { }
}
