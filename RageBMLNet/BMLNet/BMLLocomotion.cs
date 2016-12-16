using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Move the body of the character from one location to another.
    /// This behavior causes the character to move to the requested target in the manner described.
    /// </summary>
    public class BMLLocomotion : BMLBehavior
    {
        /// <summary>
        /// A reference towards a target instance that represents the end location of the locomotive behavior.
        /// </summary>
        public string target;

        /// <summary>
        /// The general manner of locomotion [WALK, RUN, STRAFE ...] (WALK is the only mandatory element in the set)
        /// </summary>
        public string manner;

        /// <summary>
        /// constructor
        /// </summary>
        public BMLLocomotion()
        {

        }

        /// <summary>
        /// parsing xml
        /// atribute: id, target, manner
        /// sync point: start, end
        /// </summary>
        /// <param name="reader"></param>
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            target = TryParseAtribute<string>(reader, "target", "", true);
            manner = TryParseAtribute<string>(reader, "manner", "WALK", false);

            TryParseSyncPoint(reader, "start");
            TryParseSyncPoint(reader, "end");
        }

    }
}
