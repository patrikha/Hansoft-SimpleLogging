using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HPMSdk;

namespace Hansoft.SimpleLogging
{
    /// <summary>
    /// An implementation of the ILogger interface that will log messages to the Console.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        string applicationName;

        /// <summary>
        /// Initialize the logging service.
        /// </summary>
        /// <param name="applicationName">The name of the application that will log messages to this instance of the logging service.</param>
        public void Initialize(string applicationName)
        {
            this.applicationName = applicationName;
        }

        /// <summary>
        /// Log an informational message.
        /// </summary>
        /// <param name="message"></param>
        public void Information(string message)
        {
            DisplayMessage("Information: " + message);
        }

        /// <summary>
        /// Log a warning message.
        /// </summary>
        /// <param name="message"></param>
        public void Warning(string message)
        {
            DisplayMessage("Warning: " + message);
        }

        /// <summary>
        /// Log an error message.
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            DisplayMessage("Error: " + message);
        }

        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="e">The exception to be logged.</param>
        public void Exception(Exception e)
        {
            Exception("", e);
        }

        /// <summary>
        /// Log an exception.
        /// </summary>
        /// <param name="message">Message that should be logged in addition to the exception itself.</param>
        /// <param name="e">The exception to be logged.</param>
        public void Exception(string message, Exception e)
        {
            DisplayMessage("Exception: " + message);
            if (e is HPMSdkException)
            {
                HPMSdkException hpme = (HPMSdkException)e;
                Error(hpme.ErrorAsStr());
            }
            else
                Error(e.Message);
        }

        internal void DisplayMessage(string message)
        {
            string messageWithPrelude = DateTime.Now.ToString() + " : " + applicationName + " : " + message;
            Console.WriteLine(messageWithPrelude);
        }

    }
}
