using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.WoW;
using MaximusParserX.Reading.Readers;

namespace MaximusParserX.Reading
{
    public abstract class DefinitionBase : ReadingBase
    {
        public DefinitionContext Context { get; private set; }

        public DefinitionBase()
        {
        }

        public DefinitionBase(DefinitionContext context)
            : base(context.Data)
        {

        }

        public void Initialize(DefinitionContext context)
        {
            Context = context;
            this.Load(Context.Data);
        }

        public int Index
        {
            get
            {
                return Context.Reader.CurrentIndex;
            }
        }

        public uint Opcode
        {
            get
            {
                return Context.Opcode;
            }
        }

        public string OpcodeName
        {
            get
            {
                return Context.OpcodeName;
            }
        }

        public Frame.Result Result
        {
            get
            {
                return Context.Result;
            }

            set
            {
                Context.Result = value;
            }
        }

        public Direction Direction
        {
            get
            {
                return Context.Direction;
            }
        }

        public override int ClientBuildAmount
        {
            get
            {
                return Context.ClientBuildAmount;
            }
        }

        public ClientBuild ClientBuild
        {
            get
            {
                return Context.ClientBuild;
            }
        }

        public string ClientBuildName
        {
            get
            {
                return Context.ClientBuildName;
            }
        }

        public string AccountName
        {
            get
            {
                return Context.AccountName;
            }
        }

        public Core Core
        {
            get
            {
                return Context.Core;
            }
        }

        public virtual bool Parse()
        {
            return false;
        }

        public virtual bool Parse(uint opcode)
        {
            return false;
        }

        public virtual bool Parse(uint parentopcode, uint opcode, long position, long size)
        {
            return false;
        }

        public virtual bool Parse(SearchCriteria searchcriteria)
        {
            return false;
        }

        public virtual bool Validate()
        {
            var result = true;

            if (AvailableBytes > 0)
            {
                if (base.BaseStream.Position == 0)
                {
                    Context.Result.AddWarning("{0} has not been parsed.", OpcodeName);
                }
                else
                {
                    Context.Result.AddError("has {0} bytes left.", AvailableBytes);
                }

                result = false;
            }

            return result;
        }

        public string ReaderFileName
        {
            get
            {
                return Context.Reader.FileName;
            }
        }

        public string AnalysisDataDump()
        {
            var data = new System.Text.StringBuilder();

            data.AppendLine(string.Format("ClientBuild: {0}", ClientBuild));
            data.AppendLine(string.Format("RemainingBytes: {0}", AvailableBytes));
            data.AppendLine();
            data.AppendLine();
            data.AppendLine();
            data.Append(HexDump());
            data.AppendLine();
            data.AppendLine();
            data.AppendLine();
            foreach (var log in FieldLog)
            {
                data.AppendLine(string.Format("{0}: {1}", log.Key, log.Value));
            }
            return data.ToString();
        }

        public string HexDump()
        {

            var hexDump = new StringBuilder();
            hexDump.AppendLine("**********************************************************");
            hexDump.AppendLine(string.Format("Index: {3}, Opcode: {0} {1},  Direction: {2}, Size: {0}", Opcode, OpcodeName, Direction, Index, Context.Data.Length));
            hexDump.AppendLine("|------------------------------------------------|----------------|");
            hexDump.AppendLine("|00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F |0123456789ABCDEF|");
            hexDump.AppendLine("|------------------------------------------------|----------------|");
            int start = 0;
            int count = Context.Data.Length;
            int end = start + count;
            for (int i = start; i < end; i += 16)
            {
                StringBuilder text = new StringBuilder();
                StringBuilder hex = new StringBuilder();
                hex.Append("|");

                for (int j = 0; j < 16; j++)
                {
                    if (j + i < end)
                    {
                        byte val = Context.Data[j + i];
                        hex.Append(Context.Data[j + i].ToString("X2"));
                        hex.Append(" ");
                        if (val >= 32 && val <= 127)
                        {
                            text.Append((char)val);
                        }
                        else
                        {
                            text.Append(".");
                        }
                    }
                    else
                    {
                        hex.Append("   ");
                        text.Append(" ");
                    }
                }
                hex.Append("|");
                hex.Append(text + "|");
                hex.AppendLine();
                hexDump.Append(hex.ToString());
            }

            hexDump.AppendLine("**********************************************************");

            return hexDump.ToString();
        }

        public void LogIt(string file, string text)
        {
            using (var sw = new System.IO.StreamWriter(file, true))
            {
                sw.WriteLine(text);
            }
        }
    }
}
