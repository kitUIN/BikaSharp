
namespace BikaSharp.API.DataModels
{
    public class User
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

















}
