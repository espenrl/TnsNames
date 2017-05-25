/* Copyright (c) 2012-2017 The ANTLR Project. All rights reserved.
 * Use of this file is governed by the BSD 3-clause license that
 * can be found in the LICENSE.txt file in the project root.
 */
using erl.Oracle.TnsNames.Antlr4.Runtime.Atn;
using erl.Oracle.TnsNames.Antlr4.Runtime.Sharpen;

namespace erl.Oracle.TnsNames.Antlr4.Runtime.Atn
{
    /// <summary>
    /// Decision state for
    /// <c>A+</c>
    /// and
    /// <c>(A|B)+</c>
    /// .  It has two transitions:
    /// one to the loop back to start of the block and one to exit.
    /// </summary>
    public sealed class PlusLoopbackState : DecisionState
    {
        public override erl.Oracle.TnsNames.Antlr4.Runtime.Atn.StateType StateType
        {
            get
            {
                return erl.Oracle.TnsNames.Antlr4.Runtime.Atn.StateType.PlusLoopBack;
            }
        }
    }
}
