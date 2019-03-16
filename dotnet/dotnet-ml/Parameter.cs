using System;
using System.Collections.Generic;
using System.Text;

namespace MarkLogic.NetCoreCLI
{
    public abstract class Parameter
    {
        protected Parameter(bool isRequired)
        {
            Required = isRequired;
        }

        public bool Required { get; }

        public bool Optional => !Required;
    }
}
