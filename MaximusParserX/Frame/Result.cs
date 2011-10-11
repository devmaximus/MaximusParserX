using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX.Frame
{
    public enum ResultSeverityType : int
    {
        None = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Critical = 4
    }

    public class Result
    {
        public Guid? ResultGUID { get; set; }
        public ResultSeverityType Severity { get; set; }
        public string Message { get; set; }
        public List<Result> SubResultList { get; set; }

        public Result()
        {
            this.SubResultList = new List<Result>();
        }

        public Result(string message, ResultSeverityType severity)
        {
            ResultGUID = Guid.NewGuid();
            Severity = severity;
            Message = message;
            this.SubResultList = new List<Result>();
        }


        public Result(Exception exception)
        {
            ResultGUID = Guid.NewGuid();
            Severity = ResultSeverityType.Critical;
            Message = exception.ToString();
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

        public void AddResult(Exception exception)
        {
            AddResult(exception.ToString(), ResultSeverityType.Critical);
        }

        public void AddResult(Result result)
        {
            if (ResultGUID == null)
            {
                ResultGUID = result.ResultGUID;
                Severity = result.Severity;
                Message = result.Message;
            }
            else
            {
                if (SubResultList == null) SubResultList = new List<Result>();
                SubResultList.Add(new Result(result.Message, result.Severity));
            }
        }

        public void AddResult(string message, ResultSeverityType severity)
        {
            if (ResultGUID == null)
            {
                ResultGUID = Guid.NewGuid();
                Severity = severity;
                Message = message;
            }
            else
            {
                if (SubResultList == null) SubResultList = new List<Result>();
                SubResultList.Add(new Result(message, severity));
            }
        }

        public bool HasErrorOrCritical()
        {
            bool hasErrorOrCritical = (Severity == ResultSeverityType.Error || Severity == ResultSeverityType.Critical);

            if (!hasErrorOrCritical && SubResultList != null)
            {
                foreach (var subresult in SubResultList)
                {
                    hasErrorOrCritical = subresult.HasErrorOrCritical();
                    if (hasErrorOrCritical) break;
                }
            }

            return hasErrorOrCritical;
        }

        public List<Result> GetFlatList()
        {
            var tList = new List<Result>();

            if (this.Message.HasValue())
            {
                tList.Add(this);

                if (this.SubResultList.Count > 0)
                {
                    tList.AddRange(this.SubResultList);
                }
            }

            return tList;
        }

        public static Result New(string message, ResultSeverityType severity, params object[] args)
        {
            return new Result(string.Format(message, args), severity);
        }

        public static Result NewInfo(string message, params object[] args)
        {
            return new Result(string.Format(message, args), ResultSeverityType.Info);
        }

        public static Result NewError(string message, params object[] args)
        {
            return new Result(string.Format(message, args), ResultSeverityType.Error);
        }

        public static Result NewWarning(string message, params object[] args)
        {
            return new Result(string.Format(message, args), ResultSeverityType.Warning);
        }

        public static Result NewCritical(string message, params object[] args)
        {
            return new Result(string.Format(message, args), ResultSeverityType.Critical);
        }
    }
}
