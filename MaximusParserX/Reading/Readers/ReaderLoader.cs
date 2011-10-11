using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Reading.Readers
{
    public static class ReaderLoader
    {
        public static ReaderBase GetReaderForFile(UI.DelegateManager delegateManager, string file)
        {
            var result = TiawpsReader.IsValid(delegateManager, file);
            if (!result.HasErrorOrCritical())
            {
                return new TiawpsReader(delegateManager, file);
            }
            else
            {
                delegateManager.AddResult(result);
                return null;
            }
        }
    }
}
