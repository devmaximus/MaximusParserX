using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MaximusParserX
{
    public class Option
    {
        public string ValueName { get; set; }
        public string DisplayName { get; set; }
        public string Discription { get; set; }
        public string Value { get; set; }
        public Type ValueType { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public Font Font { get; set; }
    }
}
