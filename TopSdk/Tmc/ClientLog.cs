using System.Collections.Generic;
using Taobao.Top.Link;
using Top.Api;

namespace Top.Tmc
{
    //refer to https://gist.github.com/wsky/5027961
    internal class ClientLog : DefaultLogger, IClientLog, ITopLogger
    {
        public ClientLog(string name
            , bool isDebugEnabled
            , bool isInfoEnabled
            , bool isWarnEnabled
            , bool isErrorEnabled
            , bool isFatalEnabled)
            : base(name
            , isDebugEnabled
            , isInfoEnabled
            , isWarnEnabled
            , isErrorEnabled
            , isFatalEnabled) { }



        public bool IsDebugEnabled()
        {
            return true;
        }

        public void TraceApiError(string appKey, string apiName, string url, Dictionary<string, string> parameters, double latency, string errorMessage)
        { }

        public void Error(string message)
        {
            
        }

        public void Error(string format, params object[] args)
        {
            
        }

        public void Warn(string message)
        {
            
        }

        public void Warn(string format, params object[] args)
        {
            
        }

        public void Info(string message)
        {
           
        }

        public void Info(string format, params object[] args)
        {
            
        }

        public void Debug(string message)
        {
            
        }

        public void Debug(string format, params object[] args)
        {
            
        }
    }
}