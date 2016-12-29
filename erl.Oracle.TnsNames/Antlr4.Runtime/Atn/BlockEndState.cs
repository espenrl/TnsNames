// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

using erl.Oracle.TnsNames.Antlr4.Runtime.Sharpen;

namespace erl.Oracle.TnsNames.Antlr4.Runtime.Atn
{
    /// <summary>
    /// Terminal node of a simple
    /// <c>(a|b|c)</c>
    /// block.
    /// </summary>
    public sealed class BlockEndState : ATNState
    {
        public BlockStartState startState;

        public override erl.Oracle.TnsNames.Antlr4.Runtime.Atn.StateType StateType
        {
            get
            {
                return erl.Oracle.TnsNames.Antlr4.Runtime.Atn.StateType.BlockEnd;
            }
        }
    }
}
