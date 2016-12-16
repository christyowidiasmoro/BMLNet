using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Child element of <posture> and <postureShift> behaviors, defines global body posture of the ECA.
    /// Child element of <posture> and <postureShift> behaviors, defines global body posture of the ECA. This global posture may then be modified by one or more <pose> siblings.
    /// </summary>
    public class BMLStance : BMLBehavior
    {
        /// <summary>
        /// Global body posture. Possible values are [SITTING, CROUCHING, STANDING, LYING]
        /// </summary>
        public Type type;

        /// <summary>
        /// Global body posture. Possible values are [SITTING, CROUCHING, STANDING, LYING]
        /// </summary>
        public enum Type
        {
            SITTING,
            CROUCHING,
            STANDING,
            LYING
        }

        /// <summary>
        /// constructor
        /// </summary>
        public BMLStance()
        {

        }

        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            type = TryParseAtribute<Type>(reader, "type", Type.STANDING, true);
        }
    }
}
