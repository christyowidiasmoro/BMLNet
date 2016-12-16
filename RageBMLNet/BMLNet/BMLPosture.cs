using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Temporarily change the posture of the ECA.
    /// Temporarily change the posture of the ECA. After the <posture> behavior has ended, return to the BASE posture.
    /// </summary>
    public class BMLPosture : BMLBehavior
    {
        /// <summary>
        /// constructor
        /// </summary>
        public BMLPosture()
        {

        }

        /// <summary>
        /// parsing xml
        /// atribute: id
        /// sync point: start, ready, relax, end
        /// </summary>
        /// <param name="reader"></param> XmlReader
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            TryParseSyncPoint(reader, "start");
            TryParseSyncPoint(reader, "ready");
            TryParseSyncPoint(reader, "relax");
            TryParseSyncPoint(reader, "end");
        }
    }
}