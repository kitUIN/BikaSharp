
namespace BikaSharp.API.DataModels
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
}
