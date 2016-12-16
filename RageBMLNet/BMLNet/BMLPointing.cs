using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Deictic gesture towards the target specified by the target attribute
    /// </summary>
    public class BMLPointing : BMLBehavior
    {
        /// <summary>
        /// What hand/arm is being used
        /// </summary>
        public Mode mode;

        /// <summary>
        /// The gesture is directed towards this target
        /// </summary>
        public string target;
        
        /// <summary>
        /// What hand/arm is being used
        /// </summary>
        public enum Mode
        {
            NONE,
            LEFT_HAND,
            RIGHT_HAND,
            BOTH_HANDS
        }

        /// <summary>
        /// constructor
        /// </summary>
        public BMLPointing()
        {

        }

        /// <summary>
        /// parsing the xml
        /// atribute: id, target, mode
        /// sync point: start, ready, strokeStart, stroke, strokeEnd, relax, end
        /// </summary>
        /// <param name="reader"></param> XMLReader
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            mode = TryParseAtribute<Mode>(reader, "mode", Mode.NONE, false);
            target = TryParseAtribute<string>(reader, "target", "", true);

            TryParseSyncPoint(reader, "start");
            TryParseSyncPoint(reader, "ready");
            TryParseSyncPoint(reader, "stroke_start");
            TryParseSyncPoint(reader, "stroke");
            TryParseSyncPoint(reader, "stroke_end");
            TryParseSyncPoint(reader, "relax");
            TryParseSyncPoint(reader, "end");
        }
    }
}