using System;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// Excpetion for TNS names parse errors.
    /// </summary>
    [PublicAPI]
    public class TnsNamesParseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TnsNamesParseException"/> class.
        /// </summary>
        public TnsNamesParseException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TnsNamesParseException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TnsNamesParseException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TnsNamesParseException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public TnsNamesParseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}