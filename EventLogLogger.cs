using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using HPMSdk;

namespace Hansoft.SimpleLogging
{
    /// <summary>
    /// An implementation of the ILogger interface that will log messages to the Application section of the Windows event log.
    /// </summary>
    public class EventLogLogger : ILogger
    {
        string applicationName;

        /// <summary>
        /// Initialize the logging service.
        /// </summary>
        /// <param name="applicationName">The name of the application that will log messages to this instance of the logging service.</param>
        public void Initialize(string applicationName)
        {
            this.applicationName = applicationName;
            try
            {
                if (!EventLog.SourceExists(applicationName))
                    EventLog.CreateEventSource(applicationName, "Application");
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Log an informational message.
        /// </summary>
        /// <param name="message"></param>
        public void Information(string message)
        {
            EventLog.WriteEntry(applicationName, message, EventLogEntryType.Information);
        }

        /// <summary>
        /// Log a warning message.
        /// </summary>
        /// <param name="message"></param>
        public void Warning(string message)
        {
            EventLog.WriteEntry(applicationName, message, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Log an error message.
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            EventLog.WriteEntry(applicationName, message, EventLogEntryType.Error);
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
            Error(message);
            if (e is HPMSdkException)
            {
                HPMSdkException hpme = (HPMSdkException)e;
                Error(hpme.ErrorAsStr()  + " @ " + e.StackTrace);
            }
            else
                Error(e.Message + " @ " +  e.StackTrace);
        }

    }
}
