
namespace BikaSharp.API.Exception
{
    class ExistedEmailException : System.Exception
    {
        public ExistedEmailException() : base("Email is already existed. Please replace your email!")
        {

        }

    }
}
