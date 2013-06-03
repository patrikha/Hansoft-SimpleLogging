using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansoft.SimpleLogging
{
    /// <summary>
    /// An interface defining a simple logging service.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Initialize the logging service.
        /// </summary>
        /// <param name="applicationName">The name of the application that will log messages to this instance of the logging service.</param>
        void Initialize(string applicationName);

        /// <summary>
        /// Log an informational message.
        /// </summary>
        /// <param name="message"></param>
        void Information(string message);

        /// <summary>
        /// Log a warning message.
        /// </summary>
        /// <param name="message"></param>
        void Warning(string message);

        /// <summary>
        /// Log an error message.
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="e">The exception to be logged.</param>
        void Exception(Exception e);

        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="message">Message that should be logged in addition to the exception itself.</param>
        /// <param name="e">The exception to be logged.</param>
        void Exception(string message, Exception e);
    }
}
