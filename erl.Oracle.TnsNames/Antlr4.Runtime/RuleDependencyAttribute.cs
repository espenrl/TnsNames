﻿namespace erl.Oracle.TnsNames.Antlr4.Runtime
{
    using System;

    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class RuleDependencyAttribute : Attribute
    {
        private readonly Type _recognizer;
        private readonly int _rule;
        private readonly int _version;
        private readonly Dependents _dependents;

        public RuleDependencyAttribute(Type recognizer, int rule, int version)
        {
            this._recognizer = recognizer;
            this._rule = rule;
            this._version = version;
            this._dependents = Dependents.Parents | Dependents.Self;
        }

        public RuleDependencyAttribute(Type recognizer, int rule, int version, Dependents dependents)
        {
            this._recognizer = recognizer;
            this._rule = rule;
            this._version = version;
            this._dependents = dependents | Dependents.Self;
        }

        public Type Recognizer
        {
            get
            {
                return _recognizer;
            }
        }

        public int Rule
        {
            get
            {
                return _rule;
            }
        }

        public int Version
        {
            get
            {
                return _version;
            }
        }

        public Dependents Dependents
        {
            get
            {
                return _dependents;
            }
        }
    }
}
