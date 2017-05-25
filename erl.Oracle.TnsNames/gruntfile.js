module.exports = function (grunt) {
    grunt.initConfig({
        run_java: {
            tnsnames_lexer: {
                execOptions: {
                    cwd: 'ANTLR'
                },
                command: "java",
                jarName: "<%= grunt.option('base') %>/../Build/antlr-4.7-complete.jar",
                javaArgs: "TnsNamesLexer.g4 -Dlanguage=CSharp -package erl.Oracle.TnsNames.ANTLR -o Generated"
            },
            tnsnames_parser: {
                execOptions: {
                    cwd: 'ANTLR'
                },
                command: "java",
                jarName: "<%= grunt.option('base') %>/../Build/antlr-4.7-complete.jar",
                javaArgs: "TnsNamesParser.g4 -Dlanguage=CSharp -package erl.Oracle.TnsNames.ANTLR -o Generated"
            }
        },
        clean: [
            "ANTLR/Generated/"
        ]
    });

    grunt.loadNpmTasks("grunt-run-java");
    grunt.loadNpmTasks("grunt-contrib-clean");
};