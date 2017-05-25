/* Copyright (c) 2012-2017 The ANTLR Project. All rights reserved.
 * Use of this file is governed by the BSD 3-clause license that
 * can be found in the LICENSE.txt file in the project root.
 */
using erl.Oracle.TnsNames.Antlr4.Runtime.Tree;

namespace erl.Oracle.TnsNames.Antlr4.Runtime.Tree
{
    public interface IRuleNode : IParseTree
    {
        erl.Oracle.TnsNames.Antlr4.Runtime.RuleContext RuleContext
        {
            get;
        }

        new IRuleNode Parent
        {
            get;
        }
    }
}
