
namespace BikaSharp.API.Exception
{
    /// <summary>
    /// This Comic is reviewing
    /// <remarks>
    /// code: 400 1014
    /// </remarks>
    /// </summary>
    class ComicReviewException : System.Exception
    {
        public ComicReviewException(): base("This Comic is reviewing")
        {

        }

    }
}
