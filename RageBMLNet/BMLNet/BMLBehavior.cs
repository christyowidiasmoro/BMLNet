using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// BML behavior class.
    /// all behavior need to derived from this class
    /// </summary>
    public class BMLBehavior : BMLBlock
    {
        
        /// <summary>
        /// constructor
        /// </summary>
        public BMLBehavior()
        {
        }

        /// <summary>
        /// parsing the xml
        /// atribute: id
        /// </summary>
        /// <param name="reader"></param>
        public override void Parse(XmlReader reader)
        {
            id = TryParseAtribute<string>(reader, "id", "", true);
        }



    }
}
