
namespace BikaSharp.API.Exception
{
    class LevelCommentException : System.Exception
    {
        public LevelCommentException(): base("higher level is required. Please comment when high level")
        {

        }



    }

}
