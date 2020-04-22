using System;

namespace Compeng.PEQP.Util.Extensions
{
    public static class ExceptionExtension
    {
        public static string GetExceptionMessage(this Exception ex)
        {
            var error = string.Empty;
            GetInnerExceptionMessage(ex, ref error);
            return error;
        }

        private static void GetInnerExceptionMessage(Exception ex, ref string error)
        {
            if (null != ex)
            {
                error += ex.Message + ";";
                GetInnerExceptionMessage(ex.InnerException, ref error);
            }
        }
    }
}
