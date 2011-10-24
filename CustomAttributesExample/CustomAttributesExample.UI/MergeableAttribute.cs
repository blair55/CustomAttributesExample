using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomAttributesExample.UI
{
    public class MergeableAttribute : Attribute
    {
        public MergeableAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
