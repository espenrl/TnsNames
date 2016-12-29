lexer grammar TnsNamesLexer;

WORD  : ( 'A' .. 'Z'
      | 'a' .. 'z'
      | '0' .. '9'
      | '<'
      | '>'
      | '/'
      | '.'
      | ':'
      | ';'
      | '-'
      | '_'
      | '$'
      | '+'
      | '*'
      | '&'
      | '!'
      | '%'
      | '?'
      | '@'
      | '\\' .
      )+
    ;

LEFT_PAREN
    : '('
    ;

RIGHT_PAREN
    : ')'
    ;

EQUALS
    : '='
    ;

COMMA
    : ','
    ;

SINGLE_QUOTE
    : '\'' -> pushMode(A)
    ;

DOUBLE_QUOTE
    : '"' -> pushMode(B)
    ;

COMMENT
    : '#' ( ~( '\n' ) )* -> skip
    ;

WHITESPACE
    : ( '\t'
      | ' '
      ) -> skip
    ;

NEWLINE
    : ( '\r' )? '\n' -> skip
    ;


mode A;

A1 : ( ~( '\'' ) )* -> type(WORD);
A2 : '\'' -> popMode, type(SINGLE_QUOTE);

mode B;

B1 : ( ~( '"' ) )* -> type(WORD);
B2 : '"' -> popMode, type(DOUBLE_QUOTE);
