using System.Runtime.InteropServices;

namespace MaximusParserX
{
    public sealed class UpdateField
    {
        public UpdateField(int val1, float val2)
        {
            Int32Value = val1;
            FloatValue = val2;
        }

        public readonly int Int32Value;

        public readonly float FloatValue;

        public override string ToString()
        {
            return string.Format("Int32Value: {0}, FloatValue: {1}", this.Int32Value, this.FloatValue);
        }
    }
}
