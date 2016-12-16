using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Show a (partial) face expression from a predefined lexicon.
    /// </summary>
    public class BMLFaceLexeme : BMLFace
    {

        /// <summary>
        /// 
        /// </summary>
        public Lexeme lexeme;

        /// <summary>
        /// 
        /// </summary>
        public enum Lexeme
        {
            NONE,
            OBLIQUE_BROWS,
            RAISE_BROWS,
            RAISE_LEFT_BROW,
            RAISE_RIGHT_BROW,
            LOWER_BROWS,
            LOWER_LEFT_BROW,
            LOWER_RIGHT_BROW,
            LOWER_MOUTH_CORNERS,
            LOWER_LEFT_MOUTH_CORNER,
            LOWER_RIGHT_MOUTH_CORNER,
            RAISE_MOUTH_CORNERS,
            RAISE_RIGHT_MOUTH_CORNER,
            RAISE_LEFT_MOUTH_CORNER,
            OPEN_MOUTH,
            OPEN_LIPS,
            WIDEN_EYES,
            CLOSE_EYES
        };

        /// <summary>
        /// constructor
        /// </summary>
        public BMLFaceLexeme()
        {

        }

        /// <summary>
        /// parsing the xml
        /// atribute: lexeme
        /// </summary>
        /// <param name="reader"></param>
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);

            lexeme = TryParseAtribute<Lexeme>(reader, "lexeme", Lexeme.NONE, true);
        }

    }
}