// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

using System.Collections.Generic;
using erl.Oracle.TnsNames.Antlr4.Runtime;
using erl.Oracle.TnsNames.Antlr4.Runtime.Sharpen;
using erl.Oracle.TnsNames.Antlr4.Runtime.Tree;

namespace erl.Oracle.TnsNames.Antlr4.Runtime.Tree.Xpath
{
    public class XPathRuleElement : XPathElement
    {
        protected internal int ruleIndex;

        public XPathRuleElement(string ruleName, int ruleIndex)
            : base(ruleName)
        {
            this.ruleIndex = ruleIndex;
        }

        public override ICollection<IParseTree> Evaluate(IParseTree t)
        {
            // return all children of t that match nodeName
            IList<IParseTree> nodes = new List<IParseTree>();
            foreach (ITree c in Trees.GetChildren(t))
            {
                if (c is ParserRuleContext)
                {
                    ParserRuleContext ctx = (ParserRuleContext)c;
                    if ((ctx.RuleIndex == ruleIndex && !invert) || (ctx.RuleIndex != ruleIndex && invert))
                    {
                        nodes.Add(ctx);
                    }
                }
            }
            return nodes;
        }
    }
}
