using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Permanently change the BASE posture of the ECA.
    /// </summary>
    public class BMLPostureShift : BMLBehavior
    {
        /// <summary>
        /// constructor
        /// </summary>
        public BMLPostureShift()
        {

        }

        /// <summary>
        /// parsing xml
        /// atribute: id
        /// sync point: start, end
        /// </summary>
        /// <param name="reader"></param> XmlReader
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            TryParseSyncPoint(reader, "start");
            TryParseSyncPoint(reader, "end");
        }
    }
}
