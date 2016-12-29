// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

using System;
using erl.Oracle.TnsNames.Antlr4.Runtime.Sharpen;

namespace erl.Oracle.TnsNames.Antlr4.Runtime.Misc
{
    /// <author>Sam Harwell</author>
    public static class Args
    {
        /// <exception cref="System.ArgumentNullException">
        /// if
        /// <paramref name="value"/>
        /// is
        /// <see langword="null"/>
        /// .
        /// </exception>
        public static void NotNull(string parameterName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
