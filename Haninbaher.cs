
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

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
        SYMBOL_EOF                  =  0, // (EOF)
        SYMBOL_ERROR                =  1, // (Error)
        SYMBOL_WHITESPACE           =  2, // Whitespace
        SYMBOL_MINUS                =  3, // '-'
        SYMBOL_MINUSMINUS           =  4, // '--'
        SYMBOL_EXCLAMEQ             =  5, // '!='
        SYMBOL_PERCENT              =  6, // '%'
        SYMBOL_LPAREN               =  7, // '('
        SYMBOL_RPAREN               =  8, // ')'
        SYMBOL_TIMES                =  9, // '*'
        SYMBOL_COMMA                = 10, // ','
        SYMBOL_DIV                  = 11, // '/'
        SYMBOL_COLON                = 12, // ':'
        SYMBOL_COLONEQ              = 13, // ':='
        SYMBOL_LBRACKET             = 14, // '['
        SYMBOL_RBRACKET             = 15, // ']'
        SYMBOL_LBRACE               = 16, // '{'
        SYMBOL_RBRACE               = 17, // '}'
        SYMBOL_PLUS                 = 18, // '+'
        SYMBOL_PLUSPLUS             = 19, // '++'
        SYMBOL_LT                   = 20, // '<'
        SYMBOL_LTEQ                 = 21, // '<='
        SYMBOL_EQEQ                 = 22, // '=='
        SYMBOL_GT                   = 23, // '>'
        SYMBOL_MINUSGT              = 24, // '->'
        SYMBOL_GTEQ                 = 25, // '>='
        SYMBOL_AND                  = 26, // and
        SYMBOL_BEGIN                = 27, // begin
        SYMBOL_CLASS                = 28, // class
        SYMBOL_ELIF                 = 29, // elif
        SYMBOL_ELSE                 = 30, // else
        SYMBOL_END                  = 31, // end
        SYMBOL_EXCEPT               = 32, // except
        SYMBOL_FALSE                = 33, // false
        SYMBOL_FINALLY              = 34, // finally
        SYMBOL_FLOATLITERAL         = 35, // FloatLiteral
        SYMBOL_FOR                  = 36, // for
        SYMBOL_FROM                 = 37, // from
        SYMBOL_FUNCTION             = 38, // function
        SYMBOL_IDENTIFIER           = 39, // Identifier
        SYMBOL_IF                   = 40, // if
        SYMBOL_IMPORT               = 41, // import
        SYMBOL_IN                   = 42, // in
        SYMBOL_INTEGERLITERAL       = 43, // IntegerLiteral
        SYMBOL_LET                  = 44, // let
        SYMBOL_NONE                 = 45, // none
        SYMBOL_NOT                  = 46, // not
        SYMBOL_OR                   = 47, // or
        SYMBOL_PRINT                = 48, // print
        SYMBOL_RETURN               = 49, // return
        SYMBOL_STRINGLITERAL        = 50, // StringLiteral
        SYMBOL_TRUE                 = 51, // true
        SYMBOL_TRY                  = 52, // try
        SYMBOL_UNTIL                = 53, // until
        SYMBOL_WHILE                = 54, // while
        SYMBOL_ARITHMETICEXPRESSION = 55, // <ArithmeticExpression>
        SYMBOL_ASSIGNMENT           = 56, // <Assignment>
        SYMBOL_CLASSATTRIBUTE       = 57, // <ClassAttribute>
        SYMBOL_CLASSBODY            = 58, // <ClassBody>
        SYMBOL_CLASSDEFINITION      = 59, // <ClassDefinition>
        SYMBOL_CLASSMETHOD          = 60, // <ClassMethod>
        SYMBOL_COMPARISONEXPRESSION = 61, // <ComparisonExpression>
        SYMBOL_COMPOUNDSTATEMENT    = 62, // <CompoundStatement>
        SYMBOL_DICTIONARYLITERAL    = 63, // <DictionaryLiteral>
        SYMBOL_ELSECLAUSE           = 64, // <ElseClause>
        SYMBOL_EXCEPTBLOCK          = 65, // <ExceptBlock>
        SYMBOL_EXPRESSION           = 66, // <Expression>
        SYMBOL_EXPRESSIONLIST       = 67, // <ExpressionList>
        SYMBOL_FACTOR               = 68, // <Factor>
        SYMBOL_FINALLYBLOCK         = 69, // <FinallyBlock>
        SYMBOL_FORSTATEMENT         = 70, // <ForStatement>
        SYMBOL_FUNCTIONCALL         = 71, // <FunctionCall>
        SYMBOL_FUNCTIONDEFINITION   = 72, // <FunctionDefinition>
        SYMBOL_IFSTATEMENT          = 73, // <IfStatement>
        SYMBOL_IMPORTSTATEMENT      = 74, // <ImportStatement>
        SYMBOL_KEYVALUE             = 75, // <KeyValue>
        SYMBOL_KEYVALUELIST         = 76, // <KeyValueList>
        SYMBOL_LISTLITERAL          = 77, // <ListLiteral>
        SYMBOL_LOGICALEXPRESSION    = 78, // <LogicalExpression>
        SYMBOL_PARAMETERLIST        = 79, // <ParameterList>
        SYMBOL_PRIMARY              = 80, // <Primary>
        SYMBOL_PRINTSTATEMENT       = 81, // <PrintStatement>
        SYMBOL_PROGRAM              = 82, // <Program>
        SYMBOL_RETURNSTATEMENT      = 83, // <ReturnStatement>
        SYMBOL_RETURNTYPE           = 84, // <ReturnType>
        SYMBOL_SIMPLESTATEMENT      = 85, // <SimpleStatement>
        SYMBOL_STATEMENT            = 86, // <Statement>
        SYMBOL_STATEMENTLIST        = 87, // <StatementList>
        SYMBOL_TERM                 = 88, // <Term>
        SYMBOL_TRYSTATEMENT         = 89, // <TryStatement>
        SYMBOL_UNTILSTATEMENT       = 90, // <UntilStatement>
        SYMBOL_WHILESTATEMENT       = 91  // <WhileStatement>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                                                 =  0, // <Program> ::= <StatementList>
        RULE_STATEMENTLIST                                                           =  1, // <StatementList> ::= <Statement> <StatementList>
        RULE_STATEMENTLIST2                                                          =  2, // <StatementList> ::= <Statement>
        RULE_STATEMENT                                                               =  3, // <Statement> ::= <SimpleStatement>
        RULE_STATEMENT2                                                              =  4, // <Statement> ::= <CompoundStatement>
        RULE_SIMPLESTATEMENT                                                         =  5, // <SimpleStatement> ::= <Assignment>
        RULE_SIMPLESTATEMENT2                                                        =  6, // <SimpleStatement> ::= <Expression>
        RULE_SIMPLESTATEMENT3                                                        =  7, // <SimpleStatement> ::= <PrintStatement>
        RULE_SIMPLESTATEMENT4                                                        =  8, // <SimpleStatement> ::= <ReturnStatement>
        RULE_SIMPLESTATEMENT5                                                        =  9, // <SimpleStatement> ::= <ImportStatement>
        RULE_COMPOUNDSTATEMENT                                                       = 10, // <CompoundStatement> ::= <IfStatement>
        RULE_COMPOUNDSTATEMENT2                                                      = 11, // <CompoundStatement> ::= <WhileStatement>
        RULE_COMPOUNDSTATEMENT3                                                      = 12, // <CompoundStatement> ::= <ForStatement>
        RULE_COMPOUNDSTATEMENT4                                                      = 13, // <CompoundStatement> ::= <UntilStatement>
        RULE_COMPOUNDSTATEMENT5                                                      = 14, // <CompoundStatement> ::= <FunctionDefinition>
        RULE_COMPOUNDSTATEMENT6                                                      = 15, // <CompoundStatement> ::= <ClassDefinition>
        RULE_COMPOUNDSTATEMENT7                                                      = 16, // <CompoundStatement> ::= <TryStatement>
        RULE_ASSIGNMENT_LET_IDENTIFIER_COLONEQ                                       = 17, // <Assignment> ::= let Identifier ':=' <Expression>
        RULE_ASSIGNMENT_IDENTIFIER_COLONEQ                                           = 18, // <Assignment> ::= Identifier ':=' <Expression>
        RULE_EXPRESSION                                                              = 19, // <Expression> ::= <LogicalExpression>
        RULE_LOGICALEXPRESSION                                                       = 20, // <LogicalExpression> ::= <ComparisonExpression>
        RULE_LOGICALEXPRESSION_AND                                                   = 21, // <LogicalExpression> ::= <LogicalExpression> and <ComparisonExpression>
        RULE_LOGICALEXPRESSION_OR                                                    = 22, // <LogicalExpression> ::= <LogicalExpression> or <ComparisonExpression>
        RULE_COMPARISONEXPRESSION                                                    = 23, // <ComparisonExpression> ::= <ArithmeticExpression>
        RULE_COMPARISONEXPRESSION_EQEQ                                               = 24, // <ComparisonExpression> ::= <ComparisonExpression> '==' <ArithmeticExpression>
        RULE_COMPARISONEXPRESSION_EXCLAMEQ                                           = 25, // <ComparisonExpression> ::= <ComparisonExpression> '!=' <ArithmeticExpression>
        RULE_COMPARISONEXPRESSION_LT                                                 = 26, // <ComparisonExpression> ::= <ComparisonExpression> '<' <ArithmeticExpression>
        RULE_COMPARISONEXPRESSION_GT                                                 = 27, // <ComparisonExpression> ::= <ComparisonExpression> '>' <ArithmeticExpression>
        RULE_COMPARISONEXPRESSION_LTEQ                                               = 28, // <ComparisonExpression> ::= <ComparisonExpression> '<=' <ArithmeticExpression>
        RULE_COMPARISONEXPRESSION_GTEQ                                               = 29, // <ComparisonExpression> ::= <ComparisonExpression> '>=' <ArithmeticExpression>
        RULE_ARITHMETICEXPRESSION                                                    = 30, // <ArithmeticExpression> ::= <Term>
        RULE_ARITHMETICEXPRESSION_PLUS                                               = 31, // <ArithmeticExpression> ::= <ArithmeticExpression> '+' <Term>
        RULE_ARITHMETICEXPRESSION_MINUS                                              = 32, // <ArithmeticExpression> ::= <ArithmeticExpression> '-' <Term>
        RULE_TERM                                                                    = 33, // <Term> ::= <Factor>
        RULE_TERM_TIMES                                                              = 34, // <Term> ::= <Term> '*' <Factor>
        RULE_TERM_DIV                                                                = 35, // <Term> ::= <Term> '/' <Factor>
        RULE_TERM_PERCENT                                                            = 36, // <Term> ::= <Term> '%' <Factor>
        RULE_FACTOR                                                                  = 37, // <Factor> ::= <Primary>
        RULE_FACTOR_PLUS                                                             = 38, // <Factor> ::= '+' <Factor>
        RULE_FACTOR_MINUS                                                            = 39, // <Factor> ::= '-' <Factor>
        RULE_FACTOR_NOT                                                              = 40, // <Factor> ::= not <Factor>
        RULE_FACTOR_PLUSPLUS                                                         = 41, // <Factor> ::= <Factor> '++'
        RULE_FACTOR_MINUSMINUS                                                       = 42, // <Factor> ::= <Factor> '--'
        RULE_PRIMARY_IDENTIFIER                                                      = 43, // <Primary> ::= Identifier
        RULE_PRIMARY_INTEGERLITERAL                                                  = 44, // <Primary> ::= IntegerLiteral
        RULE_PRIMARY_FLOATLITERAL                                                    = 45, // <Primary> ::= FloatLiteral
        RULE_PRIMARY_STRINGLITERAL                                                   = 46, // <Primary> ::= StringLiteral
        RULE_PRIMARY_TRUE                                                            = 47, // <Primary> ::= true
        RULE_PRIMARY_FALSE                                                           = 48, // <Primary> ::= false
        RULE_PRIMARY_NONE                                                            = 49, // <Primary> ::= none
        RULE_PRIMARY_LPAREN_RPAREN                                                   = 50, // <Primary> ::= '(' <Expression> ')'
        RULE_PRIMARY                                                                 = 51, // <Primary> ::= <FunctionCall>
        RULE_PRIMARY2                                                                = 52, // <Primary> ::= <ListLiteral>
        RULE_PRIMARY3                                                                = 53, // <Primary> ::= <DictionaryLiteral>
        RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN                                   = 54, // <FunctionCall> ::= Identifier '(' <ExpressionList> ')'
        RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN2                                  = 55, // <FunctionCall> ::= Identifier '(' ')'
        RULE_EXPRESSIONLIST                                                          = 56, // <ExpressionList> ::= <Expression>
        RULE_EXPRESSIONLIST_COMMA                                                    = 57, // <ExpressionList> ::= <Expression> ',' <ExpressionList>
        RULE_LISTLITERAL_LBRACKET_RBRACKET                                           = 58, // <ListLiteral> ::= '[' <ExpressionList> ']'
        RULE_LISTLITERAL_LBRACKET_RBRACKET2                                          = 59, // <ListLiteral> ::= '[' ']'
        RULE_DICTIONARYLITERAL_LBRACE_RBRACE                                         = 60, // <DictionaryLiteral> ::= '{' <KeyValueList> '}'
        RULE_DICTIONARYLITERAL_LBRACE_RBRACE2                                        = 61, // <DictionaryLiteral> ::= '{' '}'
        RULE_KEYVALUELIST                                                            = 62, // <KeyValueList> ::= <KeyValue>
        RULE_KEYVALUELIST_COMMA                                                      = 63, // <KeyValueList> ::= <KeyValue> ',' <KeyValueList>
        RULE_KEYVALUE_COLON                                                          = 64, // <KeyValue> ::= <Expression> ':' <Expression>
        RULE_IFSTATEMENT_IF_BEGIN_END                                                = 65, // <IfStatement> ::= if <Expression> begin <StatementList> end
        RULE_IFSTATEMENT_IF_BEGIN_END2                                               = 66, // <IfStatement> ::= if <Expression> begin <StatementList> end <ElseClause>
        RULE_ELSECLAUSE_ELSE_BEGIN_END                                               = 67, // <ElseClause> ::= else begin <StatementList> end
        RULE_ELSECLAUSE_ELIF_BEGIN_END                                               = 68, // <ElseClause> ::= elif <Expression> begin <StatementList> end
        RULE_ELSECLAUSE_ELIF_BEGIN_END2                                              = 69, // <ElseClause> ::= elif <Expression> begin <StatementList> end <ElseClause>
        RULE_WHILESTATEMENT_WHILE_BEGIN_END                                          = 70, // <WhileStatement> ::= while <Expression> begin <StatementList> end
        RULE_UNTILSTATEMENT_UNTIL_BEGIN_END                                          = 71, // <UntilStatement> ::= until <Expression> begin <StatementList> end
        RULE_FORSTATEMENT_FOR_IDENTIFIER_IN_BEGIN_END                                = 72, // <ForStatement> ::= for Identifier in <Expression> begin <StatementList> end
        RULE_FUNCTIONDEFINITION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_MINUSGT_BEGIN_END  = 73, // <FunctionDefinition> ::= function Identifier '(' <ParameterList> ')' '->' <ReturnType> begin <StatementList> end
        RULE_FUNCTIONDEFINITION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_MINUSGT_BEGIN_END2 = 74, // <FunctionDefinition> ::= function Identifier '(' ')' '->' <ReturnType> begin <StatementList> end
        RULE_FUNCTIONDEFINITION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_BEGIN_END          = 75, // <FunctionDefinition> ::= function Identifier '(' <ParameterList> ')' begin <StatementList> end
        RULE_FUNCTIONDEFINITION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_BEGIN_END2         = 76, // <FunctionDefinition> ::= function Identifier '(' ')' begin <StatementList> end
        RULE_PARAMETERLIST_IDENTIFIER                                                = 77, // <ParameterList> ::= Identifier
        RULE_PARAMETERLIST_IDENTIFIER_COMMA                                          = 78, // <ParameterList> ::= Identifier ',' <ParameterList>
        RULE_RETURNTYPE_IDENTIFIER                                                   = 79, // <ReturnType> ::= Identifier
        RULE_CLASSDEFINITION_CLASS_IDENTIFIER_BEGIN_END                              = 80, // <ClassDefinition> ::= class Identifier begin <ClassBody> end
        RULE_CLASSBODY                                                               = 81, // <ClassBody> ::= <ClassMethod> <ClassBody>
        RULE_CLASSBODY2                                                              = 82, // <ClassBody> ::= <ClassMethod>
        RULE_CLASSBODY3                                                              = 83, // <ClassBody> ::= <ClassAttribute> <ClassBody>
        RULE_CLASSBODY4                                                              = 84, // <ClassBody> ::= <ClassAttribute>
        RULE_CLASSMETHOD                                                             = 85, // <ClassMethod> ::= <FunctionDefinition>
        RULE_CLASSATTRIBUTE_LET_IDENTIFIER_COLONEQ                                   = 86, // <ClassAttribute> ::= let Identifier ':=' <Expression>
        RULE_PRINTSTATEMENT_PRINT_LPAREN_RPAREN                                      = 87, // <PrintStatement> ::= print '(' <Expression> ')'
        RULE_PRINTSTATEMENT_PRINT_LPAREN_RPAREN2                                     = 88, // <PrintStatement> ::= print '(' ')'
        RULE_RETURNSTATEMENT_RETURN                                                  = 89, // <ReturnStatement> ::= return <Expression>
        RULE_RETURNSTATEMENT_RETURN2                                                 = 90, // <ReturnStatement> ::= return
        RULE_IMPORTSTATEMENT_IMPORT_IDENTIFIER                                       = 91, // <ImportStatement> ::= import Identifier
        RULE_IMPORTSTATEMENT_FROM_IDENTIFIER_IMPORT_IDENTIFIER                       = 92, // <ImportStatement> ::= from Identifier import Identifier
        RULE_IMPORTSTATEMENT_FROM_IDENTIFIER_IMPORT_TIMES                            = 93, // <ImportStatement> ::= from Identifier import '*'
        RULE_TRYSTATEMENT_TRY_BEGIN_END                                              = 94, // <TryStatement> ::= try begin <StatementList> end <ExceptBlock>
        RULE_TRYSTATEMENT_TRY_BEGIN_END2                                             = 95, // <TryStatement> ::= try begin <StatementList> end <FinallyBlock>
        RULE_TRYSTATEMENT_TRY_BEGIN_END3                                             = 96, // <TryStatement> ::= try begin <StatementList> end <ExceptBlock> <FinallyBlock>
        RULE_EXCEPTBLOCK_EXCEPT_BEGIN_END                                            = 97, // <ExceptBlock> ::= except begin <StatementList> end
        RULE_EXCEPTBLOCK_EXCEPT_IDENTIFIER_BEGIN_END                                 = 98, // <ExceptBlock> ::= except Identifier begin <StatementList> end
        RULE_FINALLYBLOCK_FINALLY_BEGIN_END                                          = 99  // <FinallyBlock> ::= finally begin <StatementList> end
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
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

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLONEQ :
                //':='
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

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
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

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
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

                case (int)SymbolConstants.SYMBOL_MINUSGT :
                //'->'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //and
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF :
                //elif
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCEPT :
                //except
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLY :
                //finally
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOATLITERAL :
                //FloatLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FROM :
                //from
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IMPORT :
                //import
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGERLITERAL :
                //IntegerLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LET :
                //let
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NONE :
                //none
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOT :
                //not
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //or
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT :
                //print
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRY :
                //try
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNTIL :
                //until
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARITHMETICEXPRESSION :
                //<ArithmeticExpression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSATTRIBUTE :
                //<ClassAttribute>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSBODY :
                //<ClassBody>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSDEFINITION :
                //<ClassDefinition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSMETHOD :
                //<ClassMethod>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPARISONEXPRESSION :
                //<ComparisonExpression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPOUNDSTATEMENT :
                //<CompoundStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DICTIONARYLITERAL :
                //<DictionaryLiteral>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSECLAUSE :
                //<ElseClause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCEPTBLOCK :
                //<ExceptBlock>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSIONLIST :
                //<ExpressionList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLYBLOCK :
                //<FinallyBlock>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORSTATEMENT :
                //<ForStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONCALL :
                //<FunctionCall>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONDEFINITION :
                //<FunctionDefinition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<IfStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IMPORTSTATEMENT :
                //<ImportStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KEYVALUE :
                //<KeyValue>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KEYVALUELIST :
                //<KeyValueList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTLITERAL :
                //<ListLiteral>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALEXPRESSION :
                //<LogicalExpression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERLIST :
                //<ParameterList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARY :
                //<Primary>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINTSTATEMENT :
                //<PrintStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNSTATEMENT :
                //<ReturnStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNTYPE :
                //<ReturnType>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SIMPLESTATEMENT :
                //<SimpleStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<StatementList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<Term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRYSTATEMENT :
                //<TryStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNTILSTATEMENT :
                //<UntilStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILESTATEMENT :
                //<WhileStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<StatementList> ::= <Statement> <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST2 :
                //<StatementList> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <SimpleStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <CompoundStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLESTATEMENT :
                //<SimpleStatement> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLESTATEMENT2 :
                //<SimpleStatement> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLESTATEMENT3 :
                //<SimpleStatement> ::= <PrintStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLESTATEMENT4 :
                //<SimpleStatement> ::= <ReturnStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLESTATEMENT5 :
                //<SimpleStatement> ::= <ImportStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUNDSTATEMENT :
                //<CompoundStatement> ::= <IfStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUNDSTATEMENT2 :
                //<CompoundStatement> ::= <WhileStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUNDSTATEMENT3 :
                //<CompoundStatement> ::= <ForStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUNDSTATEMENT4 :
                //<CompoundStatement> ::= <UntilStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUNDSTATEMENT5 :
                //<CompoundStatement> ::= <FunctionDefinition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUNDSTATEMENT6 :
                //<CompoundStatement> ::= <ClassDefinition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUNDSTATEMENT7 :
                //<CompoundStatement> ::= <TryStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_LET_IDENTIFIER_COLONEQ :
                //<Assignment> ::= let Identifier ':=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_COLONEQ :
                //<Assignment> ::= Identifier ':=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <LogicalExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXPRESSION :
                //<LogicalExpression> ::= <ComparisonExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXPRESSION_AND :
                //<LogicalExpression> ::= <LogicalExpression> and <ComparisonExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXPRESSION_OR :
                //<LogicalExpression> ::= <LogicalExpression> or <ComparisonExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONEXPRESSION :
                //<ComparisonExpression> ::= <ArithmeticExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONEXPRESSION_EQEQ :
                //<ComparisonExpression> ::= <ComparisonExpression> '==' <ArithmeticExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONEXPRESSION_EXCLAMEQ :
                //<ComparisonExpression> ::= <ComparisonExpression> '!=' <ArithmeticExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONEXPRESSION_LT :
                //<ComparisonExpression> ::= <ComparisonExpression> '<' <ArithmeticExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONEXPRESSION_GT :
                //<ComparisonExpression> ::= <ComparisonExpression> '>' <ArithmeticExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONEXPRESSION_LTEQ :
                //<ComparisonExpression> ::= <ComparisonExpression> '<=' <ArithmeticExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONEXPRESSION_GTEQ :
                //<ComparisonExpression> ::= <ComparisonExpression> '>=' <ArithmeticExpression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARITHMETICEXPRESSION :
                //<ArithmeticExpression> ::= <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARITHMETICEXPRESSION_PLUS :
                //<ArithmeticExpression> ::= <ArithmeticExpression> '+' <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARITHMETICEXPRESSION_MINUS :
                //<ArithmeticExpression> ::= <ArithmeticExpression> '-' <Term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<Term> ::= <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<Term> ::= <Term> '*' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<Term> ::= <Term> '/' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<Term> ::= <Term> '%' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <Primary>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_PLUS :
                //<Factor> ::= '+' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_MINUS :
                //<Factor> ::= '-' <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_NOT :
                //<Factor> ::= not <Factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_PLUSPLUS :
                //<Factor> ::= <Factor> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_MINUSMINUS :
                //<Factor> ::= <Factor> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_IDENTIFIER :
                //<Primary> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_INTEGERLITERAL :
                //<Primary> ::= IntegerLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_FLOATLITERAL :
                //<Primary> ::= FloatLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_STRINGLITERAL :
                //<Primary> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_TRUE :
                //<Primary> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_FALSE :
                //<Primary> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_NONE :
                //<Primary> ::= none
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_LPAREN_RPAREN :
                //<Primary> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY :
                //<Primary> ::= <FunctionCall>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY2 :
                //<Primary> ::= <ListLiteral>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY3 :
                //<Primary> ::= <DictionaryLiteral>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN :
                //<FunctionCall> ::= Identifier '(' <ExpressionList> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONCALL_IDENTIFIER_LPAREN_RPAREN2 :
                //<FunctionCall> ::= Identifier '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST :
                //<ExpressionList> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST_COMMA :
                //<ExpressionList> ::= <Expression> ',' <ExpressionList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTLITERAL_LBRACKET_RBRACKET :
                //<ListLiteral> ::= '[' <ExpressionList> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LISTLITERAL_LBRACKET_RBRACKET2 :
                //<ListLiteral> ::= '[' ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DICTIONARYLITERAL_LBRACE_RBRACE :
                //<DictionaryLiteral> ::= '{' <KeyValueList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DICTIONARYLITERAL_LBRACE_RBRACE2 :
                //<DictionaryLiteral> ::= '{' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEYVALUELIST :
                //<KeyValueList> ::= <KeyValue>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEYVALUELIST_COMMA :
                //<KeyValueList> ::= <KeyValue> ',' <KeyValueList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_KEYVALUE_COLON :
                //<KeyValue> ::= <Expression> ':' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_BEGIN_END :
                //<IfStatement> ::= if <Expression> begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_BEGIN_END2 :
                //<IfStatement> ::= if <Expression> begin <StatementList> end <ElseClause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSECLAUSE_ELSE_BEGIN_END :
                //<ElseClause> ::= else begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSECLAUSE_ELIF_BEGIN_END :
                //<ElseClause> ::= elif <Expression> begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSECLAUSE_ELIF_BEGIN_END2 :
                //<ElseClause> ::= elif <Expression> begin <StatementList> end <ElseClause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILESTATEMENT_WHILE_BEGIN_END :
                //<WhileStatement> ::= while <Expression> begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNTILSTATEMENT_UNTIL_BEGIN_END :
                //<UntilStatement> ::= until <Expression> begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORSTATEMENT_FOR_IDENTIFIER_IN_BEGIN_END :
                //<ForStatement> ::= for Identifier in <Expression> begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDEFINITION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_MINUSGT_BEGIN_END :
                //<FunctionDefinition> ::= function Identifier '(' <ParameterList> ')' '->' <ReturnType> begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDEFINITION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_MINUSGT_BEGIN_END2 :
                //<FunctionDefinition> ::= function Identifier '(' ')' '->' <ReturnType> begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDEFINITION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_BEGIN_END :
                //<FunctionDefinition> ::= function Identifier '(' <ParameterList> ')' begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDEFINITION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_BEGIN_END2 :
                //<FunctionDefinition> ::= function Identifier '(' ')' begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST_IDENTIFIER :
                //<ParameterList> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST_IDENTIFIER_COMMA :
                //<ParameterList> ::= Identifier ',' <ParameterList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNTYPE_IDENTIFIER :
                //<ReturnType> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDEFINITION_CLASS_IDENTIFIER_BEGIN_END :
                //<ClassDefinition> ::= class Identifier begin <ClassBody> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSBODY :
                //<ClassBody> ::= <ClassMethod> <ClassBody>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSBODY2 :
                //<ClassBody> ::= <ClassMethod>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSBODY3 :
                //<ClassBody> ::= <ClassAttribute> <ClassBody>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSBODY4 :
                //<ClassBody> ::= <ClassAttribute>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSMETHOD :
                //<ClassMethod> ::= <FunctionDefinition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSATTRIBUTE_LET_IDENTIFIER_COLONEQ :
                //<ClassAttribute> ::= let Identifier ':=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINTSTATEMENT_PRINT_LPAREN_RPAREN :
                //<PrintStatement> ::= print '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINTSTATEMENT_PRINT_LPAREN_RPAREN2 :
                //<PrintStatement> ::= print '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN :
                //<ReturnStatement> ::= return <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN2 :
                //<ReturnStatement> ::= return
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IMPORTSTATEMENT_IMPORT_IDENTIFIER :
                //<ImportStatement> ::= import Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IMPORTSTATEMENT_FROM_IDENTIFIER_IMPORT_IDENTIFIER :
                //<ImportStatement> ::= from Identifier import Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IMPORTSTATEMENT_FROM_IDENTIFIER_IMPORT_TIMES :
                //<ImportStatement> ::= from Identifier import '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TRYSTATEMENT_TRY_BEGIN_END :
                //<TryStatement> ::= try begin <StatementList> end <ExceptBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TRYSTATEMENT_TRY_BEGIN_END2 :
                //<TryStatement> ::= try begin <StatementList> end <FinallyBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TRYSTATEMENT_TRY_BEGIN_END3 :
                //<TryStatement> ::= try begin <StatementList> end <ExceptBlock> <FinallyBlock>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXCEPTBLOCK_EXCEPT_BEGIN_END :
                //<ExceptBlock> ::= except begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXCEPTBLOCK_EXCEPT_IDENTIFIER_BEGIN_END :
                //<ExceptBlock> ::= except Identifier begin <StatementList> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FINALLYBLOCK_FINALLY_BEGIN_END :
                //<FinallyBlock> ::= finally begin <StatementList> end
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
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
