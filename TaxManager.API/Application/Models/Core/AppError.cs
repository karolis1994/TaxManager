namespace TaxManager.API.Application.Models.Core
{
    /// <summary>
    /// App error model, used to return readable and understandable errors that occur in the application
    /// </summary>
    public class AppError
    {
        public AppError(string key, string message)
        {
            Key = key;
            Message = message;
        }

        /// <summary>
        /// Error key
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; }
    }
}
