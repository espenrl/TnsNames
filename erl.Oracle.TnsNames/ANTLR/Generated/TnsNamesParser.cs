//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from TnsNamesParser.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace erl.Oracle.TnsNames.ANTLR {
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public partial class TnsNamesParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		WORD=1, LEFT_PAREN=2, RIGHT_PAREN=3, EQUALS=4, COMMA=5, SINGLE_QUOTE=6, 
		DOUBLE_QUOTE=7, COMMENT=8, WHITESPACE=9, NEWLINE=10;
	public const int
		RULE_configuration_file = 0, RULE_parameter = 1, RULE_parameterValue = 2, 
		RULE_keyword = 3, RULE_value = 4;
	public static readonly string[] ruleNames = {
		"configuration_file", "parameter", "parameterValue", "keyword", "value"
	};

	private static readonly string[] _LiteralNames = {
		null, null, "'('", "')'", "'='", "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, "WORD", "LEFT_PAREN", "RIGHT_PAREN", "EQUALS", "COMMA", "SINGLE_QUOTE", 
		"DOUBLE_QUOTE", "COMMENT", "WHITESPACE", "NEWLINE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "TnsNamesParser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static TnsNamesParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public TnsNamesParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public TnsNamesParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}
	public partial class Configuration_fileContext : ParserRuleContext {
		public ParameterContext[] parameter() {
			return GetRuleContexts<ParameterContext>();
		}
		public ParameterContext parameter(int i) {
			return GetRuleContext<ParameterContext>(i);
		}
		public Configuration_fileContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_configuration_file; } }
		public override void EnterRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.EnterConfiguration_file(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.ExitConfiguration_file(this);
		}
	}

	[RuleVersion(0)]
	public Configuration_fileContext configuration_file() {
		Configuration_fileContext _localctx = new Configuration_fileContext(Context, State);
		EnterRule(_localctx, 0, RULE_configuration_file);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 13;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==WORD) {
				{
				{
				State = 10; parameter();
				}
				}
				State = 15;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ParameterContext : ParserRuleContext {
		public KeywordContext keyword() {
			return GetRuleContext<KeywordContext>(0);
		}
		public ITerminalNode EQUALS() { return GetToken(TnsNamesParser.EQUALS, 0); }
		public ParameterValueContext parameterValue() {
			return GetRuleContext<ParameterValueContext>(0);
		}
		public ParameterContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_parameter; } }
		public override void EnterRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.EnterParameter(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.ExitParameter(this);
		}
	}

	[RuleVersion(0)]
	public ParameterContext parameter() {
		ParameterContext _localctx = new ParameterContext(Context, State);
		EnterRule(_localctx, 2, RULE_parameter);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 16; keyword();
			State = 17; Match(EQUALS);
			State = 18; parameterValue();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ParameterValueContext : ParserRuleContext {
		public ParameterValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_parameterValue; } }
	 
		public ParameterValueContext() { }
		public virtual void CopyFrom(ParameterValueContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class ParameterListParameterValueContext : ParameterValueContext {
		public ParameterContext _parameter;
		public IList<ParameterContext> _parameterList = new List<ParameterContext>();
		public ITerminalNode[] LEFT_PAREN() { return GetTokens(TnsNamesParser.LEFT_PAREN); }
		public ITerminalNode LEFT_PAREN(int i) {
			return GetToken(TnsNamesParser.LEFT_PAREN, i);
		}
		public ITerminalNode[] RIGHT_PAREN() { return GetTokens(TnsNamesParser.RIGHT_PAREN); }
		public ITerminalNode RIGHT_PAREN(int i) {
			return GetToken(TnsNamesParser.RIGHT_PAREN, i);
		}
		public ParameterContext[] parameter() {
			return GetRuleContexts<ParameterContext>();
		}
		public ParameterContext parameter(int i) {
			return GetRuleContext<ParameterContext>(i);
		}
		public ParameterListParameterValueContext(ParameterValueContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.EnterParameterListParameterValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.ExitParameterListParameterValue(this);
		}
	}
	public partial class ScalarParameterValueContext : ParameterValueContext {
		public ValueContext scalar;
		public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		public ScalarParameterValueContext(ParameterValueContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.EnterScalarParameterValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.ExitScalarParameterValue(this);
		}
	}
	public partial class ValueListParameterValueContext : ParameterValueContext {
		public ValueContext _value;
		public IList<ValueContext> _valueList = new List<ValueContext>();
		public ITerminalNode LEFT_PAREN() { return GetToken(TnsNamesParser.LEFT_PAREN, 0); }
		public ITerminalNode RIGHT_PAREN() { return GetToken(TnsNamesParser.RIGHT_PAREN, 0); }
		public ValueContext[] value() {
			return GetRuleContexts<ValueContext>();
		}
		public ValueContext value(int i) {
			return GetRuleContext<ValueContext>(i);
		}
		public ITerminalNode[] COMMA() { return GetTokens(TnsNamesParser.COMMA); }
		public ITerminalNode COMMA(int i) {
			return GetToken(TnsNamesParser.COMMA, i);
		}
		public ValueListParameterValueContext(ParameterValueContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.EnterValueListParameterValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.ExitValueListParameterValue(this);
		}
	}

	[RuleVersion(0)]
	public ParameterValueContext parameterValue() {
		ParameterValueContext _localctx = new ParameterValueContext(Context, State);
		EnterRule(_localctx, 4, RULE_parameterValue);
		int _la;
		try {
			State = 40;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
			case 1:
				_localctx = new ScalarParameterValueContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 20; ((ScalarParameterValueContext)_localctx).scalar = value();
				}
				break;
			case 2:
				_localctx = new ValueListParameterValueContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 21; Match(LEFT_PAREN);
				State = 22; ((ValueListParameterValueContext)_localctx)._value = value();
				((ValueListParameterValueContext)_localctx)._valueList.Add(((ValueListParameterValueContext)_localctx)._value);
				State = 27;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==COMMA) {
					{
					{
					State = 23; Match(COMMA);
					State = 24; ((ValueListParameterValueContext)_localctx)._value = value();
					((ValueListParameterValueContext)_localctx)._valueList.Add(((ValueListParameterValueContext)_localctx)._value);
					}
					}
					State = 29;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 30; Match(RIGHT_PAREN);
				}
				break;
			case 3:
				_localctx = new ParameterListParameterValueContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 36;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				do {
					{
					{
					State = 32; Match(LEFT_PAREN);
					State = 33; ((ParameterListParameterValueContext)_localctx)._parameter = parameter();
					((ParameterListParameterValueContext)_localctx)._parameterList.Add(((ParameterListParameterValueContext)_localctx)._parameter);
					State = 34; Match(RIGHT_PAREN);
					}
					}
					State = 38;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				} while ( _la==LEFT_PAREN );
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class KeywordContext : ParserRuleContext {
		public ITerminalNode WORD() { return GetToken(TnsNamesParser.WORD, 0); }
		public KeywordContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_keyword; } }
		public override void EnterRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.EnterKeyword(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.ExitKeyword(this);
		}
	}

	[RuleVersion(0)]
	public KeywordContext keyword() {
		KeywordContext _localctx = new KeywordContext(Context, State);
		EnterRule(_localctx, 6, RULE_keyword);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 42; Match(WORD);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ValueContext : ParserRuleContext {
		public IToken content;
		public ITerminalNode WORD() { return GetToken(TnsNamesParser.WORD, 0); }
		public ITerminalNode[] SINGLE_QUOTE() { return GetTokens(TnsNamesParser.SINGLE_QUOTE); }
		public ITerminalNode SINGLE_QUOTE(int i) {
			return GetToken(TnsNamesParser.SINGLE_QUOTE, i);
		}
		public ITerminalNode[] DOUBLE_QUOTE() { return GetTokens(TnsNamesParser.DOUBLE_QUOTE); }
		public ITerminalNode DOUBLE_QUOTE(int i) {
			return GetToken(TnsNamesParser.DOUBLE_QUOTE, i);
		}
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
		public override void EnterRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.EnterValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ITnsNamesParserListener typedListener = listener as ITnsNamesParserListener;
			if (typedListener != null) typedListener.ExitValue(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 8, RULE_value);
		try {
			State = 51;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case WORD:
				EnterOuterAlt(_localctx, 1);
				{
				State = 44; _localctx.content = Match(WORD);
				}
				break;
			case SINGLE_QUOTE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 45; Match(SINGLE_QUOTE);
				State = 46; _localctx.content = Match(WORD);
				State = 47; Match(SINGLE_QUOTE);
				}
				break;
			case DOUBLE_QUOTE:
				EnterOuterAlt(_localctx, 3);
				{
				State = 48; Match(DOUBLE_QUOTE);
				State = 49; _localctx.content = Match(WORD);
				State = 50; Match(DOUBLE_QUOTE);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\f', '\x38', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x3', '\x2', '\a', '\x2', '\xE', '\n', '\x2', '\f', 
		'\x2', '\xE', '\x2', '\x11', '\v', '\x2', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\a', '\x4', '\x1C', '\n', '\x4', '\f', '\x4', 
		'\xE', '\x4', '\x1F', '\v', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x6', '\x4', '\'', '\n', 
		'\x4', '\r', '\x4', '\xE', '\x4', '(', '\x5', '\x4', '+', '\n', '\x4', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x5', '\x6', 
		'\x36', '\n', '\x6', '\x3', '\x6', '\x2', '\x2', '\a', '\x2', '\x4', '\x6', 
		'\b', '\n', '\x2', '\x2', '\x2', '\x39', '\x2', '\xF', '\x3', '\x2', '\x2', 
		'\x2', '\x4', '\x12', '\x3', '\x2', '\x2', '\x2', '\x6', '*', '\x3', '\x2', 
		'\x2', '\x2', '\b', ',', '\x3', '\x2', '\x2', '\x2', '\n', '\x35', '\x3', 
		'\x2', '\x2', '\x2', '\f', '\xE', '\x5', '\x4', '\x3', '\x2', '\r', '\f', 
		'\x3', '\x2', '\x2', '\x2', '\xE', '\x11', '\x3', '\x2', '\x2', '\x2', 
		'\xF', '\r', '\x3', '\x2', '\x2', '\x2', '\xF', '\x10', '\x3', '\x2', 
		'\x2', '\x2', '\x10', '\x3', '\x3', '\x2', '\x2', '\x2', '\x11', '\xF', 
		'\x3', '\x2', '\x2', '\x2', '\x12', '\x13', '\x5', '\b', '\x5', '\x2', 
		'\x13', '\x14', '\a', '\x6', '\x2', '\x2', '\x14', '\x15', '\x5', '\x6', 
		'\x4', '\x2', '\x15', '\x5', '\x3', '\x2', '\x2', '\x2', '\x16', '+', 
		'\x5', '\n', '\x6', '\x2', '\x17', '\x18', '\a', '\x4', '\x2', '\x2', 
		'\x18', '\x1D', '\x5', '\n', '\x6', '\x2', '\x19', '\x1A', '\a', '\a', 
		'\x2', '\x2', '\x1A', '\x1C', '\x5', '\n', '\x6', '\x2', '\x1B', '\x19', 
		'\x3', '\x2', '\x2', '\x2', '\x1C', '\x1F', '\x3', '\x2', '\x2', '\x2', 
		'\x1D', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x1E', '\x3', '\x2', 
		'\x2', '\x2', '\x1E', ' ', '\x3', '\x2', '\x2', '\x2', '\x1F', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', ' ', '!', '\a', '\x5', '\x2', '\x2', '!', 
		'+', '\x3', '\x2', '\x2', '\x2', '\"', '#', '\a', '\x4', '\x2', '\x2', 
		'#', '$', '\x5', '\x4', '\x3', '\x2', '$', '%', '\a', '\x5', '\x2', '\x2', 
		'%', '\'', '\x3', '\x2', '\x2', '\x2', '&', '\"', '\x3', '\x2', '\x2', 
		'\x2', '\'', '(', '\x3', '\x2', '\x2', '\x2', '(', '&', '\x3', '\x2', 
		'\x2', '\x2', '(', ')', '\x3', '\x2', '\x2', '\x2', ')', '+', '\x3', '\x2', 
		'\x2', '\x2', '*', '\x16', '\x3', '\x2', '\x2', '\x2', '*', '\x17', '\x3', 
		'\x2', '\x2', '\x2', '*', '&', '\x3', '\x2', '\x2', '\x2', '+', '\a', 
		'\x3', '\x2', '\x2', '\x2', ',', '-', '\a', '\x3', '\x2', '\x2', '-', 
		'\t', '\x3', '\x2', '\x2', '\x2', '.', '\x36', '\a', '\x3', '\x2', '\x2', 
		'/', '\x30', '\a', '\b', '\x2', '\x2', '\x30', '\x31', '\a', '\x3', '\x2', 
		'\x2', '\x31', '\x36', '\a', '\b', '\x2', '\x2', '\x32', '\x33', '\a', 
		'\t', '\x2', '\x2', '\x33', '\x34', '\a', '\x3', '\x2', '\x2', '\x34', 
		'\x36', '\a', '\t', '\x2', '\x2', '\x35', '.', '\x3', '\x2', '\x2', '\x2', 
		'\x35', '/', '\x3', '\x2', '\x2', '\x2', '\x35', '\x32', '\x3', '\x2', 
		'\x2', '\x2', '\x36', '\v', '\x3', '\x2', '\x2', '\x2', '\a', '\xF', '\x1D', 
		'(', '*', '\x35',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace erl.Oracle.TnsNames.ANTLR