// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

using erl.Oracle.TnsNames.Antlr4.Runtime.Sharpen;

namespace erl.Oracle.TnsNames.Antlr4.Runtime.Atn
{
    public sealed class StarLoopbackState : ATNState
    {
        public StarLoopEntryState LoopEntryState
        {
            get
            {
                return (StarLoopEntryState)Transition(0).target;
            }
        }

        public override erl.Oracle.TnsNames.Antlr4.Runtime.Atn.StateType StateType
        {
            get
            {
                return erl.Oracle.TnsNames.Antlr4.Runtime.Atn.StateType.StarLoopBack;
            }
        }
    }
}
