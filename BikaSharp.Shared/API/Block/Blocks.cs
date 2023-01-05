using System;
using System.Collections.Generic;


using System.Text.Json.Serialization;


namespace bikabika.API.Block
{

    internal class Category
    {
        public Category() { }
        public string title { get; set; }
        public Thumb thumb { get; set; }
        public bool isWeb { get; set; }
        public bool active { get; set; }
        public string link { get; set; }
        public string _id { get; set; }
        public string description { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Category))]
    internal partial class CategoryContext : JsonSerializerContext
    { }

    internal class Thumb
    {
        public string originalName { get; set; }
        public string path { get; set; }
        public string fileServer { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Thumb))]
    internal partial class ThumbContext : JsonSerializerContext
    { }

    internal class Comic
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int totalViews { get; set; }
        public int totalLikes { get; set; }
        public int pagesCount { get; set; }
        public int epsCount { get; set; }
        public bool finished { get; set; }
        public List<string> categories { get; set; }
        public Thumb thumb { get; set; }
        public string id { get; set; }
        public int likesCount { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Comic))]
    internal partial class ComicContext : JsonSerializerContext
    { }

    internal class ComicInfo
    {
        public string _id { get; set; }
        public Creator _creator { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Thumb thumb { get; set; }
        public string author { get; set; }
        public string chineseTeam { get; set; }
        public List<string> categories { get; set; }
        public List<string> tags { get; set; }
        public int pagesCount { get; set; }
        public int epsCount { get; set; }
        public bool finished { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public bool allowDownload { get; set; }
        public bool allowComment { get; set; }
        public int totalLikes { get; set; }
        public int totalViews { get; set; }
        public int totalComments { get; set; }
        public int viewsCount { get; set; }
        public int likesCount { get; set; }
        public int commentsCount { get; set; }
        public bool isFavourite { get; set; }
        public bool isLiked { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ComicInfo))]
    internal partial class ComicInfoContext : JsonSerializerContext
    { }

    internal class Episode
    {
        public string _id { get; set; }
        public string title { get; set; }
        public int order { get; set; }
        public DateTime updated_at { get; set; }
        public string id { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Episode))]
    internal partial class EpisodeContext : JsonSerializerContext
    { }

    internal class User
    {
        public string _id { get; set; }
        public DateTime birthday { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string name { get; set; }
        public string slogan { get; set; }
        public string title { get; set; }
        public bool verified { get; set; }
        public int exp { get; set; }
        public int level { get; set; }
        public List<string> characters { get; set; }
        public DateTime created_at { get; set; }
        public Thumb avatar { get; set; }
        public bool isPunched { get; set; }
        public string character { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(User))]
    internal partial class UserContext : JsonSerializerContext
    { }

    internal class Creator
    {
        public string _id { get; set; }
        public string gender { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public bool verified { get; set; }
        public int exp { get; set; }
        public int level { get; set; }
        public List<string> characters { get; set; }
        public string role { get; set; }
        public string slogan { get; set; }
        public Thumb avatar { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Creator))]
    internal partial class CreatorContext : JsonSerializerContext
    { }

    internal class Comment
    {
        public string _id { get; set; }
        public string content { get; set; }
        public User _user { get; set; }
        public string _comic { get; set; }
        public int totalComments { get; set; }
        public bool isTop { get; set; }
        public bool hide { get; set; }
        public DateTime created_at { get; set; }
        public string id { get; set; }
        public int likesCount { get; set; }
        public int commentsCount { get; set; }
        public bool isLiked { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Comment))]
    internal partial class CommentContext : JsonSerializerContext
    { }


    internal class Picture
    {
        public string _id { get; set; }
        public Thumb media { get; set; }
        public string id { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Picture))]
    internal partial class PictureContext : JsonSerializerContext
    { }


    internal class Ep
    {
        public string _id { get; set; }
        public string title { get; set; }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(Ep))]
    internal partial class EpContext : JsonSerializerContext
    { }



















}
