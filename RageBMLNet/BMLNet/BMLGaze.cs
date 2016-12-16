using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Temporarily directs the gaze of the character towards a target.
    /// This behavior causes the character to temporarily direct its gaze to the requested target. 
    /// The influence parameter is read as follows: EYE means 'use only the eyes’; HEAD means 'use only head and eyes to change the gaze direction’, etcetera.
    /// </summary>
    public class BMLGaze : BMLBehavior
    {
        /// <summary>
        /// A reference towards a target instance that represents the target direction of the gaze.
        /// </summary>
        public string target;

        /// <summary>
        /// Determines what parts of the body to move to effect the gaze direction.
        /// </summary>
        public Influence influence;

        /// <summary>
        /// Adds an angle degrees offset to gaze direction relative to the target in the direction specified in the offsetDirection
        /// </summary>
        public float offsetAngle;

        /// <summary>
        /// Direction of the offsetDirection angle
        /// </summary>
        public Direction offsetDirection;

        /// <summary>
        /// Determines what parts of the body to move to effect the gaze direction.
        /// </summary>
        public enum Influence
        {
            NONE,
            EYES,
            HEAD,
            SHOULDER,
            WAIST,
            WHOLE
        }

        /// <summary>
        /// Direction of the offsetDirection angle.
        /// </summary>
        public enum Direction
        {
            RIGHT,
            LEFT,
            UP,
            DOWN,
            UPRIGHT,
            UPLEFT,
            DOWNLEFT,
            DOWNRIGHT
        }

        /// <summary>
        /// constructor
        /// </summary>
        public BMLGaze()
        {
            offsetAngle = 0.0f;
            offsetDirection = Direction.RIGHT;
        }

        /// <summary>
        /// parsing the xml
        /// atribute: target, influence, offsetAngle, offsetDirection
        /// sync point: start, ready, relax, end
        /// </summary>
        /// <param name="reader"></param>
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            target = TryParseAtribute<string>(reader, "target", "", true);
            influence = TryParseAtribute<Influence>(reader, "influence", Influence.NONE, false);
            offsetAngle = TryParseAtribute<float>(reader, "offsetAngle", 0.0f, false);
            offsetDirection = TryParseAtribute<Direction>(reader, "offsetDirection", Direction.RIGHT, false);

            TryParseSyncPoint(reader, "start");
            TryParseSyncPoint(reader, "ready");
            TryParseSyncPoint(reader, "relax");
            TryParseSyncPoint(reader, "end");
        }

    }
}