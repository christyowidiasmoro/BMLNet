using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Currently, BML offers two types of gesture behaviors. The first provides a set of gestures recalled by name from a gesticon; the second provides simple pointing gestures.
    /// Coordinated movement with arms and hands, recalled from a gesticon by requesting the corresponding lexeme
    /// </summary>
    public class BMLGesture : BMLBehavior
    {
        /// <summary>
        /// What hand/arm is being used
        /// </summary>
        public Mode mode;

        /// <summary>
        /// Refers to an animation or a controller to realize this particular gesture.
        /// </summary>
        public Lexeme lexeme;

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
        /// Refers to an animation or a controller to realize this particular gesture.
        /// </summary>
        public enum Lexeme
        {
            BEAT
        }

        /// <summary>
        /// constructor
        /// </summary>
        public BMLGesture()
        {

        }

        /// <summary>
        /// parsing the xml
        /// atribute: mode, lexeme
        /// sync point: start, ready, strokeStart, stroke, strokeEnd, relax, end
        /// </summary>
        /// <param name="reader"></param>
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            mode = TryParseAtribute<Mode>(reader, "mode", Mode.NONE, false);
            lexeme = TryParseAtribute<Lexeme>(reader, "lexeme", Lexeme.BEAT, true);

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