using System.Xml;

namespace BMLNet
{
    public class BMLWait : BMLBehavior
    {
        /// <summary>
        /// the duration of the wait in seconds
        /// </summary>
        public float duration;

        /// <summary>
        /// constructor
        /// </summary>
        public BMLWait()
        {

        }

        /// <summary>
        /// parsing the XML
        /// atribute: duration
        /// </summary>
        /// <param name="reader"></param>
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            duration = TryParseAtribute<float>(reader, "duration", 0.0f, true);

            TryParseSyncPoint(reader, "start");

            syncPoints.Add("end", new BMLSyncPoint(this, "end", id + ":start+" + duration));
        }
    }
}
