module.exports = function (grunt) {
    grunt.initConfig({
        run_java: {
            tnsnames_lexer: {
                execOptions: {
                    cwd: 'ANTLR'
                },
                command: "java",
                jarName: "C:/Users/erl/.nuget/packages/Antlr4.CodeGenerator/4.5.4-beta001/tools/antlr4-csharp-4.5.4-SNAPSHOT-complete.jar",
                javaArgs: "TnsNamesLexer.g4 -Dlanguage=CSharp_v4_5 -package erl.Oracle.TnsNames.ANTLR -o Generated"
            },
            tnsnames_parser: {
                execOptions: {
                    cwd: 'ANTLR'
                },
                command: "java",
                jarName: "C:/Users/erl/.nuget/packages/Antlr4.CodeGenerator/4.5.4-beta001/tools/antlr4-csharp-4.5.4-SNAPSHOT-complete.jar",
                javaArgs: "TnsNamesParser.g4 -Dlanguage=CSharp_v4_5 -package erl.Oracle.TnsNames.ANTLR -o Generated"
            },
            xpath_lexer: {
                execOptions: {
                    cwd: 'Antlr4.Runtime/Tree/Xpath'
                },
                command: "java",
                jarName: "C:/Users/erl/.nuget/packages/Antlr4.CodeGenerator/4.5.4-beta001/tools/antlr4-csharp-4.5.4-SNAPSHOT-complete.jar",
                javaArgs: "XPathLexer.g4 -Dlanguage=CSharp_v4_5 -package erl.Oracle.TnsNames.Antlr4.Runtime.Tree.Xpath -o Generated"
            }
        },
        clean: [
            "ANTLR/Generated/"
        ]
    });

    grunt.loadNpmTasks("grunt-run-java");
    grunt.loadNpmTasks("grunt-contrib-clean");
};