
namespace BikaSharp.API.Exception
{
    class ExistedNameException : System.Exception
    {
        public ExistedNameException() : base("Name is already existed. Please replace your name!")
        {

        }

    }
}
