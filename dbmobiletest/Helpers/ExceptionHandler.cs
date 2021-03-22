using System;
using System.Collections.Generic;
using System.Linq;

namespace dbmobiletest.Helpers
{
    public class ExceptionHandler
    {
        const string _userStr = "UserId";
        const string _userNameStr = "UserName";
        const string _classStr = "Class";
        const string _methodStr = "Method";
        const string _exceptionStr = "Exception";
        const string _buildNumberAndVersionStr = "App Version and Build Number";
        //const string _buildStr = "Build Number";

        /// <summary>
        /// Logs the and send exception to AppCenter - For non static classes -.
        /// </summary>
        /// <param name="classObj">Class object.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="exception">Exception.</param>
        /// <param name="extendedProperties">Extended properties.</param>
        public static void LogAndSendException(object classObj, string methodName, Exception exception, List<KeyValuePair<string, string>> extendedProperties = null)
        {
            string className = classObj.GetType().ToString();
            Execute(className, methodName, exception, extendedProperties);
        }

        /// <summary>
        /// Logs the and send exception to AppCenter - For Static Classes only -.
        /// </summary>
        /// <param name="className">Class name.</param>
        /// <param name="methodName">Method name.</param>
        /// <param name="exception">Exception.</param>
        /// <param name="extendedProperties">Extended properties.</param>
        public static void LogAndSendException(string className, string methodName, Exception exception, List<KeyValuePair<string, string>> extendedProperties = null)
        {
            Execute(className, methodName, exception, extendedProperties);
        }

        public static void LogException(object classObj, string methodName, Exception exception, List<KeyValuePair<string, string>> extendedProperties = null)
        {
            string className = classObj.GetType().ToString();
            System.Diagnostics.Debug.WriteLine("{0}: {1} {2}: {3} {4}: {5}", _classStr, className, _methodStr, methodName, _exceptionStr, exception.Message);
        }

        public static void LogException(string className, string methodName, Exception exception, List<KeyValuePair<string, string>> extendedProperties = null)
        {
            System.Diagnostics.Debug.WriteLine("{0}: {1} {2}: {3} {4}: {5}", _classStr, className, _methodStr, methodName, _exceptionStr, exception.Message);
        }

        public static void Execute(string className, string methodName, Exception exception, List<KeyValuePair<string, string>> extendedProperties = null)
        {

            var properties = new Dictionary<string, string> {
                { _classStr, className },
                { _methodStr, methodName }
            };

            if (extendedProperties != null)
            {
                if (extendedProperties.Any())
                {
                    foreach (var item in extendedProperties)
                    {
                        var valueStr = item.Value;
                        if (!string.IsNullOrEmpty(valueStr))
                        {
                            properties.Add(item.Key, valueStr);
                        }
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine("{0}: {1} {2}: {3} {4}: {5}", _classStr, className, _methodStr, methodName, _exceptionStr, exception.Message);
        }
    }
}
