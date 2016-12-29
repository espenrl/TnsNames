// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

using erl.Oracle.TnsNames.Antlr4.Runtime;
using erl.Oracle.TnsNames.Antlr4.Runtime.Sharpen;

namespace erl.Oracle.TnsNames.Antlr4.Runtime.Tree.Xpath
{
    public class XPathLexerErrorListener : IAntlrErrorListener<int>
    {
        public virtual void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
        }
    }
}
