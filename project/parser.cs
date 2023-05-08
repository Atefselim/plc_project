
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF             =  0, // (EOF)
        SYMBOL_ERROR           =  1, // (Error)
        SYMBOL_WHITESPACE      =  2, // Whitespace
        SYMBOL_MINUS           =  3, // '-'
        SYMBOL_MINUSMINUS      =  4, // '--'
        SYMBOL_EXCLAMEQ        =  5, // '!='
        SYMBOL_DOLLAR          =  6, // '$'
        SYMBOL_PERCENT         =  7, // '%'
        SYMBOL_LPAREN          =  8, // '('
        SYMBOL_RPAREN          =  9, // ')'
        SYMBOL_TIMES           = 10, // '*'
        SYMBOL_TIMESTIMES      = 11, // '**'
        SYMBOL_DIV             = 12, // '/'
        SYMBOL_SEMI            = 13, // ';'
        SYMBOL_AT              = 14, // '@'
        SYMBOL_LBRACKET        = 15, // '['
        SYMBOL_RBRACKET        = 16, // ']'
        SYMBOL_PLUS            = 17, // '+'
        SYMBOL_PLUSPLUS        = 18, // '++'
        SYMBOL_LT              = 19, // '<'
        SYMBOL_EQ              = 20, // '='
        SYMBOL_EQEQ            = 21, // '=='
        SYMBOL_GT              = 22, // '>'
        SYMBOL_DIGIT           = 23, // Digit
        SYMBOL_DO              = 24, // Do
        SYMBOL_DOUBLE          = 25, // double
        SYMBOL_ELSE            = 26, // else
        SYMBOL_FINITO          = 27, // Finito
        SYMBOL_FOR             = 28, // for
        SYMBOL_FOREACH         = 29, // foreach
        SYMBOL_GO              = 30, // Go
        SYMBOL_ID              = 31, // Id
        SYMBOL_IF              = 32, // if
        SYMBOL_IN              = 33, // in
        SYMBOL_INT             = 34, // int
        SYMBOL_WHILE           = 35, // while
        SYMBOL_ASSIGN          = 36, // <assign>
        SYMBOL_CONDITION       = 37, // <condition>
        SYMBOL_CONTENT         = 38, // <content>
        SYMBOL_COUNT           = 39, // <count>
        SYMBOL_DECLARATION_STM = 40, // <declaration_stm>
        SYMBOL_DIGIT2          = 41, // <digit>
        SYMBOL_DO_WHILE        = 42, // <do_while>
        SYMBOL_E               = 43, // <e>
        SYMBOL_EXPR            = 44, // <expr>
        SYMBOL_FACTOR          = 45, // <factor>
        SYMBOL_FOR_STM         = 46, // <for_stm>
        SYMBOL_FOREACH_STM     = 47, // <foreach_stm>
        SYMBOL_ID2             = 48, // <id>
        SYMBOL_IF_ELSE_STM     = 49, // <if_else_stm>
        SYMBOL_OPERATOR        = 50, // <operator>
        SYMBOL_PROJECT         = 51, // <project>
        SYMBOL_STATEMENT       = 52, // <statement>
        SYMBOL_TERM            = 53, // <term>
        SYMBOL_TYPE            = 54, // <type>
        SYMBOL_WHILE_STM       = 55  // <while_stm>
    };

    enum RuleConstants : int
    {
        RULE_PROJECT_GO_FINITO                                             =  0, // <project> ::= Go <content> Finito
        RULE_CONTENT                                                       =  1, // <content> ::= <statement>
        RULE_CONTENT2                                                      =  2, // <content> ::= <statement> <content>
        RULE_STATEMENT                                                     =  3, // <statement> ::= <declaration_stm>
        RULE_STATEMENT2                                                    =  4, // <statement> ::= <if_else_stm>
        RULE_STATEMENT3                                                    =  5, // <statement> ::= <assign>
        RULE_STATEMENT4                                                    =  6, // <statement> ::= <for_stm>
        RULE_STATEMENT5                                                    =  7, // <statement> ::= <foreach_stm>
        RULE_STATEMENT6                                                    =  8, // <statement> ::= <while_stm>
        RULE_STATEMENT7                                                    =  9, // <statement> ::= <do_while>
        RULE_ASSIGN_EQ                                                     = 10, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                                                         = 11, // <id> ::= Id
        RULE_EXPR_PLUS                                                     = 12, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                                    = 13, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                          = 14, // <expr> ::= <term>
        RULE_TERM_TIMES                                                    = 15, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                                      = 16, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                                  = 17, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                          = 18, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                             = 19, // <factor> ::= <factor> '**' <e>
        RULE_FACTOR                                                        = 20, // <factor> ::= <e>
        RULE_E_LPAREN_RPAREN                                               = 21, // <e> ::= '(' <expr> ')'
        RULE_E                                                             = 22, // <e> ::= <id>
        RULE_E2                                                            = 23, // <e> ::= <digit>
        RULE_DIGIT_DIGIT                                                   = 24, // <digit> ::= Digit
        RULE_IF_ELSE_STM_IF_LPAREN_RPAREN_GO_FINITO_LBRACKET_ELSE_RBRACKET = 25, // <if_else_stm> ::= if '(' <condition> ')' Go <statement> Finito '[' else <statement> ']'
        RULE_CONDITION                                                     = 26, // <condition> ::= <expr> <operator> <expr>
        RULE_OPERATOR_LT                                                   = 27, // <operator> ::= '<'
        RULE_OPERATOR_GT                                                   = 28, // <operator> ::= '>'
        RULE_OPERATOR_EQEQ                                                 = 29, // <operator> ::= '=='
        RULE_OPERATOR_EXCLAMEQ                                             = 30, // <operator> ::= '!='
        RULE_DECLARATION_STM_SEMI                                          = 31, // <declaration_stm> ::= <type> <id> ';'
        RULE_TYPE_INT                                                      = 32, // <type> ::= int
        RULE_TYPE_DOUBLE                                                   = 33, // <type> ::= double
        RULE_ID_ID2                                                        = 34, // <id> ::= <id> Id
        RULE_ID_DIGIT                                                      = 35, // <id> ::= <id> Digit
        RULE_FOR_STM_FOR_LPAREN_AT_AT_RPAREN_GO_FINITO                     = 36, // <for_stm> ::= for '(' <type> <assign> '@' <condition> '@' <count> ')' Go <statement> Finito
        RULE_COUNT_MINUSMINUS                                              = 37, // <count> ::= '--' <id>
        RULE_COUNT_MINUSMINUS2                                             = 38, // <count> ::= <id> '--'
        RULE_COUNT_PLUSPLUS                                                = 39, // <count> ::= '++' <id>
        RULE_COUNT_PLUSPLUS2                                               = 40, // <count> ::= <id> '++'
        RULE_COUNT                                                         = 41, // <count> ::= <assign>
        RULE_FOREACH_STM_FOREACH_LPAREN_IN_RPAREN_SEMI                     = 42, // <foreach_stm> ::= foreach '(' <type> <id> in <expr> ')' <statement> ';'
        RULE_WHILE_STM_WHILE_LPAREN_RPAREN_GO                              = 43, // <while_stm> ::= while '(' <assign> ')' Go <statement>
        RULE_DO_WHILE_DO_WHILE_LPAREN_RPAREN_DOLLAR                        = 44  // <do_while> ::= Do <statement> while '(' <assign> ')' '$'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        public MyParser(string filename, ListBox lst)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            Init(stream);
            stream.Close();
            this.lst = lst;
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOLLAR :
                //'$'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AT :
                //'@'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //Do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINITO :
                //Finito
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOREACH :
                //foreach
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GO :
                //Go
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTENT :
                //<content>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COUNT :
                //<count>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARATION_STM :
                //<declaration_stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE :
                //<do_while>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_E :
                //<e>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STM :
                //<for_stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOREACH_STM :
                //<foreach_stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_ELSE_STM :
                //<if_else_stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPERATOR :
                //<operator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROJECT :
                //<project>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STM :
                //<while_stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROJECT_GO_FINITO :
                //<project> ::= Go <content> Finito
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONTENT :
                //<content> ::= <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONTENT2 :
                //<content> ::= <statement> <content>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <declaration_stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <if_else_stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<statement> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<statement> ::= <for_stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<statement> ::= <foreach_stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<statement> ::= <while_stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT7 :
                //<statement> ::= <do_while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <e>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <e>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_E_LPAREN_RPAREN :
                //<e> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_E :
                //<e> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_E2 :
                //<e> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_ELSE_STM_IF_LPAREN_RPAREN_GO_FINITO_LBRACKET_ELSE_RBRACKET :
                //<if_else_stm> ::= if '(' <condition> ')' Go <statement> Finito '[' else <statement> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<condition> ::= <expr> <operator> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATOR_LT :
                //<operator> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATOR_GT :
                //<operator> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATOR_EQEQ :
                //<operator> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATOR_EXCLAMEQ :
                //<operator> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARATION_STM_SEMI :
                //<declaration_stm> ::= <type> <id> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_DOUBLE :
                //<type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID2 :
                //<id> ::= <id> Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_DIGIT :
                //<id> ::= <id> Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STM_FOR_LPAREN_AT_AT_RPAREN_GO_FINITO :
                //<for_stm> ::= for '(' <type> <assign> '@' <condition> '@' <count> ')' Go <statement> Finito
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COUNT_MINUSMINUS :
                //<count> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COUNT_MINUSMINUS2 :
                //<count> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COUNT_PLUSPLUS :
                //<count> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COUNT_PLUSPLUS2 :
                //<count> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COUNT :
                //<count> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOREACH_STM_FOREACH_LPAREN_IN_RPAREN_SEMI :
                //<foreach_stm> ::= foreach '(' <type> <id> in <expr> ')' <statement> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STM_WHILE_LPAREN_RPAREN_GO :
                //<while_stm> ::= while '(' <assign> ')' Go <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_DO_WHILE_LPAREN_RPAREN_DOLLAR :
                //<do_while> ::= Do <statement> while '(' <assign> ')' '$'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string messageUE = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
            lst.Items.Add(messageUE);

            string messageE = "Parse error caused by token: '" + args.ExpectedTokens.ToString() + "'";
            //todo: Report message to UI?
            lst.Items.Add(messageE);

            string messageLine = "Parse error caused by token: '" + (args.UnexpectedToken.Location.LineNr + 1).ToString();
            //todo: Report message to UI?
            lst.Items.Add(messageLine);
        }

    }
}
