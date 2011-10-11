using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace MaximusParserX
{
    public static class BaseExt
    {
        public const string DBNullString = " NULL ";
        public const string DBValueString = "'{0}'";

        public static string ToSQL(this string input)
        {
            if (input == null) input = string.Empty;
            var str = input.Replace("\\", "\\\\");
            str = str.Replace("'", "\\'");
            str = str.Replace("\"", "\\\"");
            str = str.Replace("\r", "\\r");
            str = str.Replace("\n", "\\n");
            return str;
        }
 
        public static string DBString(this string value)
        {
            if (value.IsEmpty())
            {
                return DBNullString;
            }

            return string.Format(DBValueString, value.ToSQL());
        }

        public static string DBString(this string value, int maxLength)
        {
            if (value.IsEmpty())
            {
                return DBNullString;
            }
            else
            {
                if (value.Length > maxLength)
                {
                    return string.Format(DBValueString, value.Substring(0, maxLength).ToSQL());
                }
                else
                {
                    return string.Format(DBValueString, value.ToSQL());
                }
            }
        }

        public static string DBString(this DateTime value)
        {
            try
            {
                return string.Format(DBValueString, System.Data.SqlTypes.SqlDateTime.Parse(value.ToString()).ToString());
            }
            catch
            {
                return DBNullString;
            }
        }

        public static string DBString(this DateTime? value)
        {
            if (value == null)
            {
                return DBNullString;
            }
            return value.Value.DBString();
        }

        public static string DBString(this double value)
        {
            return string.Format(DBValueString, value.ToString());
        }

        public static string DBString(this int value)
        {
            return string.Format(DBValueString, value.ToString());
        }

        public static string DBString(this double? value)
        {
            if (value == null)
            {
                return DBNullString;
            }

            return value.Value.DBString();
        }

        public static string DBString(this int? value)
        {
            if (value == null)
            {
                return DBNullString;
            }

            return value.Value.DBString();
        }

        public static string DBString(this bool? value)
        {
            if (value == null)
            {
                return DBNullString;
            }

            return value.Value.DBString();
        }

        public static string DBString(this bool value)
        {
            if (value)
            {
                return string.Format(DBValueString, 1);
            }

            return string.Format(DBValueString, 0);
        }

        public static string BoolValueYesNo(this object value)
        {
            return value.BoolValue() ? "Yes" : "No";
        }


        public static void AppendLine(this System.Text.StringBuilder stringBuilder, string format, params object[] args)
        {
            stringBuilder.AppendLine(string.Format(format, args));
        }

        public static double? DoubleValueOrNull(this string value, int decimals)
        {
            double? result = value.DoubleValueOrNull();
            if (result != null)
            {
                result = Math.Round(result.Value, decimals);
            }
            return result;
        }

        public static string LeftOrEmpty(this string value, int maxLength)
        {
            if (value == null) return string.Empty;
            if (value.Length > maxLength)
            {
                value = value.Substring(0, maxLength);
            }
            return value;
        }

        public static string LeftOrNull(this string value, int maxLength)
        {
            if (value == null) return null;
            if (value.Length > maxLength)
            {
                value = value.Substring(0, maxLength);
            }
            return value;
        }

        public static string Right(this string value, int maxLength)
        {
            if (value == null) return string.Empty;
            if (value.Length > maxLength)
            {
                value = value.Substring(value.Length - maxLength);
            }
            return value;
        }

        public static string RightOrNull(this string value, int maxLength)
        {
            if (value == null) return null;
            if (value.Length > maxLength)
            {
                value = value.Substring(value.Length - maxLength);
            }
            return value;
        }

        public static System.DateTime? DateValueOrNull(this string value)
        {
            System.DateTime result;
            if (System.DateTime.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public static DateTime? StripSecondsAndMilliseconds(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }
            else
            {
                return dateTime.Value.StripSecondsAndMilliseconds();
            }
        }

        public static DateTime StripSecondsAndMilliseconds(this DateTime dateTime)
        {
            return dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);// .AddSeconds(-dateTime.Second).AddMilliseconds(-dateTime.Millisecond);
        }

        public static System.DateTime ReplaceTimeValue(this DateTime dateValue, DateTime timeValue)
        {
            return dateValue.Date + timeValue.TimeOfDay;
        }

        public static System.DateTime? ReplaceTimeValueOrNull(this string dateValue, string timeValue)
        {
            return dateValue.DateValueOrNull().ReplaceTimeValueOrNull(timeValue.DateValueOrNull());
        }

        public static System.DateTime? ReplaceTimeValueOrNull(this DateTime? dateValue, DateTime? timeValue)
        {
            if (dateValue.HasValue && timeValue.HasValue)
            {
                return dateValue.Value.Date + timeValue.Value.TimeOfDay;
            }
            else
            {
                return null;
            }

        }

        public static System.DateTime DateValueOrMin(this string value)
        {
            System.DateTime result;
            if (System.DateTime.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return DateTime.MinValue;
            }

        }

        public static long? LongValueOrNull(this string value)
        {
            long result;
            if (long.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public static bool BoolValue(this object value)
        {
            return value.StringValueOrEmpty().BoolValue();

        }

        public static bool BoolValue(this string value)
        {
            if (value.IsEmpty()) { return false; }
            var result = false;
            if (bool.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                if (value.ToUpper() == "Y" || value.ToUpper() == "YES" || value.ToUpper() == "1" || value.ToUpper() == "-1" || value.ToUpper() == "T" || value.ToUpper() == "TRUE")
                    return true;
                else if (value.ToUpper() == "N" || value.ToUpper() == "NO" || value.ToUpper() == "0" || value.ToUpper() == "F" || value.ToUpper() == "FALSE")
                    return false;
                else
                    throw new Exception("Invalid value for boolean type: " + value + ".");
            }

        }

        public static bool? BoolValueOrNull(this string value)
        {
            bool result = false;
            if (bool.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                if (value.ToUpper() == "Y" || value.ToUpper() == "YES" || value.ToUpper() == "1" || value.ToUpper() == "T" || value.ToUpper() == "TRUE")
                    return true;
                else if (value.ToUpper() == "N" || value.ToUpper() == "NO" || value.ToUpper() == "0" || value.ToUpper() == "F" || value.ToUpper() == "FALSE")
                    return false;
                else
                    return null;
            }

        }

        public static short? ShortValueOrNull(this string value)
        {
            short result;
            if (short.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static bool IsNumeric(this string value)
        {
            var result = 0d;
            return double.TryParse(value, out result);
        }

        public static bool IsEmpty(this object value)
        {

            if (value == null || value.Equals(string.Empty) || DBNull.Value.Equals(value))
            {
                return true;
            }
            else
            {
                return value.ToString().Trim().Length == 0;
            }
        }

        public static bool HasValue(this object value)
        {
            return !IsEmpty(value);
        }

        public static int? IntValueOrNull(this string value)
        {
            if (IsNumeric(value))
            {
                var result = Convert.ToInt32(DecimalValueOrNull(value));
                return result;
            }
            else
            {
                return null;
            }
        }

        public static int IntValueOrZero(this string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        public static int IntValueOrDefault(this string value, int defaultValue)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }

        public static double? DoubleValueOrNull(this string value)
        {
            double result;
            if (double.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public static double DoubleValueOrZero(this string value)
        {
            double result;
            if (double.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }

        }

        public static decimal? DecimalValueOrNull(this string value)
        {
            decimal result;
            if (decimal.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public static long LongValueOrZero(this string value)
        {
            long result;
            if (long.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }

        }

        public static decimal DecimalValueOrZero(this string value)
        {
            decimal result;
            if (decimal.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }

        }

        public static short ShortValueOrZero(this string value)
        {
            short result;
            if (short.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }

        }

        public static string StringValueOrEmpty(this object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }

        public static string StringValueOrEmpty(this object value, int maxLength)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var result = value.ToString();
            if (result.Length > maxLength)
            {
                return result.Substring(0, maxLength);
            }
            else
            {
                return result;
            }
        }

        public static string GetValueOrDefault(this object value, string defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            return value.ToString();
        }

        public static string StringValueOrEmpty(this double? value)
        {

            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                return value.Value.ToString();
            }

        }

        public static string StringValueOrEmpty(this DateTime? value)
        {
            return value.StringValueOrEmpty(null);
        }

        public static string StringValueOrEmpty(this DateTime? value, string format)
        {

            if (value == null)
            {
                return string.Empty;
            }
            else
            {
                if (format != null)
                    return value.Value.ToString(format);
                else
                    return value.Value.ToString();
            }

        }

        public static string TruncateFromLeft(this string value, int pLength)
        {
            string result = string.Empty;
            if (value != null)
            {
                if (value.Length > pLength)
                {
                    result = value.Substring(0, pLength);
                }
            }
            return result;
        }

        public static uint UIntValueOrDefault(this string value, uint defaultValue)
        {
            uint result;
            if (uint.TryParse(value, out result))
            {
                return result;
            }
            return defaultValue;
        }

        public static string GetValueByIndex(this string[] array, int index)
        {
            return array.GetValueByIndex(index, string.Empty);
        }

        public static string GetValueByIndex(this string[] array, int index, string defaultValue)
        {
            if (array == null || array.Length == 0 || array.Length <= index) return defaultValue;

            return array[index].StringValueOrEmpty();
        }

        public static T ToEnum<T>(this string enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString);
        }

        public static byte ToByte(this bool boolean)
        {
            return (byte)(boolean ? 1 : 0);
        }

        public static bool HasAnyFlag(this Enum value, Enum toTest)
        {
            var val = ((IConvertible)value).ToUInt64(null);
            var test = ((IConvertible)toTest).ToUInt64(null);

            return (val & test) != 0;
        }

        public static DateTime GetDateTimeFromUnixTime(this int unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTime);
        }

        public static DateTime GetDateTimeFromUnixTime(this long unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTime);
        }

        public static DateTime GetDateTimeFromGameTime(this int packedDate)
        {
            var minute = packedDate & 0x3F;
            var hour = (packedDate >> 6) & 0x1F;
            var day = (packedDate >> 14) & 0x3F;
            var month = (packedDate >> 20) & 0xF;
            var year = (packedDate >> 24) & 0x1F;

            return new DateTime(year + 2000, month + 1, day + 1, hour, minute, 0);
        }

        public static byte[] HexStringToBinary(this string data)
        {
            var bytes = new List<byte>();
            for (var i = 0; i < data.Length; i += 2)
                bytes.Add(Byte.Parse(data.Substring(i, 2), NumberStyles.HexNumber));

            return bytes.ToArray();
        }

        public static string ByteArrayToHexString(this byte[] data)
        {
            var str = string.Empty;
            for (var i = 0; i < data.Length; ++i)
                str += data[i].ToString("X2", CultureInfo.InvariantCulture);

            return str;
        }

        public static string GetPathFromFullPath(string fullPath)
        {
            return !fullPath.Contains("\\") ? Directory.GetCurrentDirectory() :
                fullPath.Substring(0, fullPath.LastIndexOf("\\") + 1);
        }

        public static string GetFileSize(this System.IO.FileInfo fileinfo)
        {
            var byteCount = fileinfo.Length;
            string size = "0 Bytes";
            if (byteCount >= 1073741824.0)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576.0)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " Bytes";

            return size;
        }
    }
}
