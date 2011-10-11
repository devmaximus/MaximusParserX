using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading;
using MaximusParserX.WoW;

namespace MaximusParserX.Parsing.Parsers
{
    public class UnknownDef : DefinitionBase
    {
        public override bool Parse()
        {
            ResetPosition();

            return Validate();
        }
    }
}
