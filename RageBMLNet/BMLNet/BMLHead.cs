using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Movement of the head, recalled from a gesticon by requesting the corresponding lexeme.
    /// Movement of the head, recalled from a gesticon by requesting the corresponding lexeme. The stroke phase of the head motion (from strokeStart till strokeEnd is the "meaningful" part of the head motion. The stroke sync point is the "peak" moment of the motion. If repetition > 1, the meaning of the stroke sync point becomes undefined
    /// </summary>
    public class BMLHead : BMLBehavior
    {
        /// <summary>
        /// Refers to an animation or a controller to realize this particular head behavior. Minimum set offered by all realizers: [NOD, SHAKE]
        /// </summary>
        public Lexeme lexeme;

        /// <summary>
        /// Number of times the basic head motion is repeated.
        /// </summary>
        public int repetition;

        /// <summary>
        /// How intense is the head nod? 0 means immeasurable small; 0.5 means "moderate"; 1 means maximally large
        /// </summary>
        public float amount;

        /// <summary>
        /// Refers to an animation or a controller to realize this particular head behavior. Minimum set offered by all realizers: [NOD, SHAKE]
        /// </summary>
        public enum Lexeme
        {
            NONE,
            NOD,
            SHAKE
        }

        /// <summary>
        /// constructor
        /// </summary>
        public BMLHead()
        {
        }

        /// <summary>
        /// parsing the xml
        /// atribute: id, amount, overshoot
        /// sync attribute: start, ready, strokeStart, stroke, strokeEnd, relax, end
        /// </summary>
        /// <param name="reader"></param> XMLReader
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            lexeme = TryParseAtribute<Lexeme>(reader, "lexeme", Lexeme.NONE, true);
            repetition = TryParseAtribute<int>(reader, "repetition", 1, false);
            amount = TryParseAtribute<float>(reader, "amount", 1.0f, false);

            TryParseSyncPoint(reader, "start");
            TryParseSyncPoint(reader, "ready");
            TryParseSyncPoint(reader, "strokeStart");
            TryParseSyncPoint(reader, "stroke");
            TryParseSyncPoint(reader, "strokeEnd");
            TryParseSyncPoint(reader, "relax");
            TryParseSyncPoint(reader, "end");
        }

    }
}