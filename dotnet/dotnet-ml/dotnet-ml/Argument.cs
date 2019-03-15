using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MarkLogic.NetCoreCLI
{
    public sealed class Argument
    {
        public Argument(string name, string shorthand, IEnumerable<Parameter> parameters)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(name), "Argument name cannot be null, empty, or whitespace.");
            Name = name;
            Shorthand = shorthand;
            HasShorthand = !string.IsNullOrWhiteSpace(Shorthand);

            if (parameters != null)
            {
                var ps = parameters.ToArray();
                Parameters = ps;
                HasParameters = ps.Length > 0;
            }
            else
            {
                Parameters = new Parameter[0];
                HasParameters = false;
            }
        }

        public string Name { get; }

        public string Shorthand { get; }

        public bool HasShorthand { get; }

        public IEnumerable<Parameter> Parameters { get; }

        public bool HasParameters { get; }
    }
}
