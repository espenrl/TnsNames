using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace erl.Oracle.TnsNames
{
    public static class ExceptionExtensions
    {
        public static string DumpException(this Exception exception)
        {
            var stack = new Stack<Exception>();
            stack.Push(exception);

            var sb = new StringBuilder();

            // Add main exception ToString()
            sb.AppendLine(exception.ToString());
            sb.Append("\n\n\n");

            // Iterate exception tree - for each exception add message and data pairs
            while (stack.Count != 0)
            {
                var ex = stack.Pop();

                // Add child exceptions to stack
                if (ex.InnerException != null)
                {
                    var aggEx = ex.InnerException as AggregateException;

                    if (aggEx != null)
                    {
                        foreach (var innerException in aggEx.InnerExceptions)
                        {
                            stack.Push(innerException);
                        }
                    }
                    else
                    {
                        stack.Push(ex.InnerException);
                    }
                }

                // Add text for current exception
                sb.AppendLine(ex.Message);
                foreach (var item in ex.Data.OfType<DictionaryEntry>())
                {
                    sb.AppendFormat("\n\t{0}: {1}", item.Key, item.Value);
                }
            }

            return sb.ToString();
        }
    }
}