
namespace BikaSharp.API.DataModels
{
    public class BikaResponse<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public int error { get; set; }
        public string detail { get; set; }
        public T data { get; set; }
    }





}
