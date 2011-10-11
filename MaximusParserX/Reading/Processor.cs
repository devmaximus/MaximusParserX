using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaximusParserX.Reading.Readers;
using MaximusParserX.Frame;

namespace MaximusParserX.Reading
{
    public class Processor
    {
        public delegate void DelegatePacketProcessed(Packet packet);
        public DelegatePacketProcessed PacketProcessed;

        public WoW.Core Core { get; private set; }
        public ReaderBase Reader { get; private set; }

        public UI.DelegateManager DelegateManager { get; private set; }
        public bool Pause { get; set; }
        public List<uint> UniqueOpcodeList { get; private set; }
        public List<uint> DefinedOpcodeList { get; private set; }
        public List<uint> FilterOpcodeList { get; private set; }

        public Processor(ReaderBase reader, UI.DelegateManager delegateManager, List<uint> filterOpcodeList)
        {
            Reader = reader;
            FilterOpcodeList = filterOpcodeList;
            DelegateManager = delegateManager;
            Core = new WoW.Core(delegateManager, reader.ClientBuildAmount);
            UniqueOpcodeList = new List<uint>();
            DefinedOpcodeList = new List<uint>();
        }

        public void Reset()
        {
            Core = new WoW.Core(DelegateManager, Reader.ClientBuildAmount);
            Reader.Close();
        }

        public void Process()
        {
            Process(false, string.Empty);
        }

        public void Process(bool resume)
        {
            Process(resume);
        }

        public void Process(string query)
        {
            Process(false, query);
        }

        public void Process(bool resume, string query)
        {
            if (!resume)
            {
                Reader.Load(query);
            }

            while (true)
            {
                if (this.Pause) { break; }

                var packet = Reader.GetNextPacket();

                if (packet != null)
                {
                    if (!FilterOpcodeList.Contains(packet.Opcode))
                    {
                        if (!DefinedOpcodeList.Contains(packet.Opcode) && !UniqueOpcodeList.Contains(packet.Opcode))
                        {
                            DelegateManager.AddInfo("Unique Opcode: {0}\t{1}", packet.OpcodeName, packet.Opcode);
                            UniqueOpcodeList.Add(packet.Opcode);
                        }

                        var context = new DefinitionContext(packet, Reader, Core);

                        var definition = context.GetDefinition();

                        definition.Parse();

                        PacketProcessed(packet);
                    }
                }
                else
                {
                    break;
                }
            }
        }

    }
}

