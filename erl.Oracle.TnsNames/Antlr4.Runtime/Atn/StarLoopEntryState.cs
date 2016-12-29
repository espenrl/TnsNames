// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

using erl.Oracle.TnsNames.Antlr4.Runtime.Sharpen;

namespace erl.Oracle.TnsNames.Antlr4.Runtime.Atn
{
    public sealed class StarLoopEntryState : DecisionState
    {
        public StarLoopbackState loopBackState;

        /// <summary>
        /// Indicates whether this state can benefit from a precedence DFA during SLL
        /// decision making.
        /// </summary>
        /// <remarks>
        /// Indicates whether this state can benefit from a precedence DFA during SLL
        /// decision making.
        /// <p>This is a computed property that is calculated during ATN deserialization
        /// and stored for use in
        /// <see cref="ParserATNSimulator"/>
        /// and
        /// <see cref="erl.Oracle.TnsNames.Antlr4.Runtime.ParserInterpreter"/>
        /// .</p>
        /// </remarks>
        /// <seealso cref="erl.Oracle.TnsNames.Antlr4.Runtime.Dfa.DFA.IsPrecedenceDfa()"/>
        public bool precedenceRuleDecision;

        public override erl.Oracle.TnsNames.Antlr4.Runtime.Atn.StateType StateType
        {
            get
            {
                return erl.Oracle.TnsNames.Antlr4.Runtime.Atn.StateType.StarLoopEntry;
            }
        }
    }
}
