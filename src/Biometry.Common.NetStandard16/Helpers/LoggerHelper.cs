using System.Runtime.CompilerServices;
using PipServices.Commons.Log;

namespace Biometry.Common.Helpers
{
    public static class LoggerHelper
    {
        public static void Trace(this Logger logger, string correlationId, object callerObject, [CallerMemberName] string methodName = null)
        {
            logger.Trace(correlationId, "Calling {0} method of {1}", methodName, callerObject.GetType().Name);
        }
    }
}
