#pragma warning disable 1591 // Missing comments

namespace erl.Oracle.TnsNames.ANTLR
{
    public class TnsNamesListenerErrorNode
    {
        public TnsNamesListenerErrorNode(TnsNamesParser.ParameterContext parameterContext, TnsNamesParseError parseError)
        {
            ParameterContext = parameterContext;
            ParseError = parseError;
        }

        public TnsNamesParser.ParameterContext ParameterContext { get; }
        public TnsNamesParseError ParseError { get; }
    }
}