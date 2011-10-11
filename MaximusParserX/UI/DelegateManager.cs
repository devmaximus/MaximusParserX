using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MaximusParserX.Frame;

namespace MaximusParserX.UI
{
    public class DelegateManager
    {
        public delegate void DelegateAddOrUpdateItem<T>(T item);

        public delegate void DelegateAddResult(Result result);
        public DelegateAddResult AddResult;

        [DefaultValue(ResultSeverityType.Critical)]
        public ResultSeverityType AddResultSeverityLevel { get; set; }

        public delegate void DelegateUpdateProgress(Guid guid, int total, int current, string info);
        public DelegateUpdateProgress UpdateProgress;

        public void CheckedAddResult(Result result)
        {
            if (result.Message.HasValue() && result.Severity <= AddResultSeverityLevel)
            {
                AddResult(result);
            }
        }


        public void AddInfo(string message, params object[] args)
        {
            AddResult(new Result(string.Format(message, args), ResultSeverityType.Info));
        }

        public void AddError(string message, params object[] args)
        {
            AddResult(new Result(string.Format(message, args), ResultSeverityType.Error));
        }

        public void AddWarning(string message, params object[] args)
        {
            AddResult(new Result(string.Format(message, args), ResultSeverityType.Warning));
        }

        public void AddCritical(string message, params object[] args)
        {
            AddResult(new Result(string.Format(message, args), ResultSeverityType.Critical));
        }


        public void AddException(Exception exc)
        {
            AddResult(Result.NewCritical(exc.ToString()));
        }
    }
}
