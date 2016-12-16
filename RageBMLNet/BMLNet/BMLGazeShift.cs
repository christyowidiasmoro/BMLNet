using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Permanently change the gaze direction of the character towards a certain target.
    /// This behavior causes the character to direct its gaze to the requested target. This changes the default state of the ECA: after completing this behavior, the new target is the default gaze direction of the ECA. The influence parameter is read as follows: EYE means 'use only the eyes’; HEAD means 'use only head and eyes to change the gaze direction’, etcetera.
    /// </summary>
    public class BMLGazeShift : BMLGaze
    {
        /// <summary>
        /// constructor
        /// sync attribute: start, end
        /// </summary>
        public BMLGazeShift()
        {

        }

        /// <summary>
        /// parsing the xml
        /// attribute:
        /// sync point: start, end
        /// </summary>
        /// <param name="reader"></param> XMLReader
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            TryParseSyncPoint(reader, "start");
            TryParseSyncPoint(reader, "end");
        }
    }
}