using System;
using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// Utterance to be spoken by a character.
    /// Realization of the <speech> element generates both speech audio (or text) and speech movement, for example using a speech synthesizer and viseme morphing.
    /// The<speech> element requires a sub-element.This sub-element is a<text> element that contains the text to be spoken, with optionally embedded<sync> elements for alignment with other behaviors.
    /// </summary>
    public class BMLSpeech : BMLBehavior
    {
        /// <summary>
        /// the text that need to be spoken
        /// </summary>
        public string text;

        /// <summary>
        /// constructor
        /// </summary>
        public BMLSpeech()
        {

        }

        /// <summary>
        /// parsing the xml
        /// child node: text
        /// sync point: start, end
        /// </summary>
        /// <param name="reader"></param>
        public override void Parse(XmlReader reader)
        {
            base.Parse(reader);
            
            TryParseSyncPoint(reader, "start");
            TryParseSyncPoint(reader, "end");

            if (reader.ReadToDescendant("text"))
            {
                text = reader.ReadElementContentAsString();
            }
            else
            {
                Console.Error.WriteLine("WARNING: cannot read text node in speech block");
            }

        }
    }
}