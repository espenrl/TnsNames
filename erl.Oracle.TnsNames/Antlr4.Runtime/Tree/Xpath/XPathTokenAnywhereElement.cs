// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

using System.Collections.Generic;
using erl.Oracle.TnsNames.Antlr4.Runtime.Sharpen;
using erl.Oracle.TnsNames.Antlr4.Runtime.Tree;

namespace erl.Oracle.TnsNames.Antlr4.Runtime.Tree.Xpath
{
    public class XPathTokenAnywhereElement : XPathElement
    {
        protected internal int tokenType;

        public XPathTokenAnywhereElement(string tokenName, int tokenType)
            : base(tokenName)
        {
            this.tokenType = tokenType;
        }

        public override ICollection<IParseTree> Evaluate(IParseTree t)
        {
            return Trees.FindAllTokenNodes(t, tokenType);
        }
    }
}
