using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using bikabika.API.Block;
namespace bikabika.API.Page
{
    internal class ComicsPage
    {
        public List<Comic> docs { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ComicsPage))]
    internal partial class ComicsPageContext : JsonSerializerContext
    { }
    internal class EpisodePage
    {
        public List<Episode> docs { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(EpisodePage))]
    internal partial class EpisodePageContext : JsonSerializerContext
    { }
    internal class CommentsPage
    {
        public List<Comment> docs { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public string page { get; set; }
        public int pages { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(CommentsPage))]
    internal partial class CommentsPageContext : JsonSerializerContext
    { }
    internal class PicturePage
    {
        public List<Picture> docs { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
    }
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(PicturePage))]
    internal partial class PicturePageContext : JsonSerializerContext
    { }
}
