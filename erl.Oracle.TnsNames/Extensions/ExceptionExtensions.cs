using System;

namespace erl.Oracle.TnsNames
{
    internal static class ExceptionExtensions
    {
        public static T AddData<T>(this T ex, object key, object value) where T : Exception
        {
            ex.Data.Add(key, value);

            return ex;
        }
    }
}