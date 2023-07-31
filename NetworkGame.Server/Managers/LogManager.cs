using NetworkGame.Server.MyEventArgs;
using NetworkGame.Server.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkGame.Server.Managers
{
    class LogManager
    {
        private List<LogMessage> _logMessages;

        public event EventHandler<LogMessageEventArgs> NewLogMessageEvent;
            
        public LogManager()
        {
            _logMessages = new List<LogMessage>();
        }

        public void AddLogMessage(LogMessage logMessage)
        {
            _logMessages.Add(logMessage);

            if (NewLogMessageEvent != null)
            {
                NewLogMessageEvent(this, new LogMessageEventArgs(logMessage));
            }
        }

        public void AddLogMessage(string id, string message)
        {
            AddLogMessage(new LogMessage { Id = id, Message = message });
        }
    }
}
