parser grammar TnsNamesParser;

options
{
	tokenVocab = TnsNamesLexer;
}

configuration_file	: ( parameter )*
					;

parameter			: keyword EQUALS parameterValue;

parameterValue		: scalar=value															  #scalarParameterValue
					| LEFT_PAREN valueList+=value ( COMMA valueList+=value )* RIGHT_PAREN	  #valueListParameterValue
					| ( LEFT_PAREN parameterList+=parameter RIGHT_PAREN )+					  #parameterListParameterValue
					;

keyword				: WORD
					;

value				: content=WORD
					| SINGLE_QUOTE content=WORD SINGLE_QUOTE
					| DOUBLE_QUOTE content=WORD DOUBLE_QUOTE
					;