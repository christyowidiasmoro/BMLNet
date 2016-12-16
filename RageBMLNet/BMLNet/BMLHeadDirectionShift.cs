
using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Orient the head towards a target referenced by the target attribute.
    /// Permanently orient the head in a certain direction.
    /// </summary>
    public class BMLHeadDirectionShift : BMLBehavior
    {
        /// <summary>
        /// target towards which the head is oriented
        /// </summary>
        public string target;

        /// <summary>
        /// constructor
        /// </summary>
        public BMLHeadDirectionShift()
        {

        }

        /// <summary>
        /// parsing the xml
        /// atribute: id, amount, overshoot
        /// sync attribute: start, end
        /// </summary>
        /// <param name="reader"></param> XMLReader
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            target = TryParseAtribute<string>(reader, "target", "", true);

            TryParseSyncPoint(reader, "start");
            TryParseSyncPoint(reader, "end");
        }
    }
}