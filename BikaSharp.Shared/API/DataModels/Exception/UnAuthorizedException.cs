
namespace BikaSharp.API.Exception
{
    class UnAuthorizedException: System.Exception
    {
        public UnAuthorizedException(): base("Unauthorized token. Please sign-in again!")
        {

        }



    }

}
