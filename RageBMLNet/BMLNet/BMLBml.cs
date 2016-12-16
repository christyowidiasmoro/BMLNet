using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BMLNet
{
    public class BMLBml : BMLBlock
    {

        /// <summary>
        /// a reference towards the controlled character
        /// </summary>
        public string characterId;

        public string xmlns;

        /// <summary>
        /// one among [MERGE,APPEND,REPLACE], defines the composition policy to apply if the current <bml> block overlaps with previous <bml> blocks (see below).
        /// </summary>
        public Composition composition;

        private int childNumber;

        private int endChildNumber;

        /// <summary>
        /// one among [MERGE,APPEND,REPLACE], defines the composition policy to apply if the current <bml> block overlaps with previous <bml> blocks (see below).
        /// </summary>
        public enum Composition
        {
            MERGE,
            APPEND,
            REPLACE
        }

        /// <summary>
        /// constructor
        /// </summary>
        public BMLBml()
        {
            parentBml = null;

            childNumber = 0;
            endChildNumber = 0;

            id = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 00)).TotalMilliseconds.ToString();
            characterId = "";
            composition = Composition.MERGE;
        }

        /// <summary>
        /// parsing the xml
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public override void Parse(XmlReader reader)
        {
            id = TryParseAtribute<string>(reader, "id", "", true);
            xmlns = TryParseAtribute<string>(reader, "xmlns", "http://www.bml-initiative.org/bml/bml-1.0", false);
            characterId = TryParseAtribute<string>(reader, "characterId", "", false);
            composition = TryParseAtribute<Composition>(reader, "composition", Composition.MERGE, false);

            // The start time of the new <bml> block will be as soon as possible. 
            SetGlobalStartTrigger("0");
        }

        public void SetGlobalStartTrigger(string value)
        {
            if (syncPoints.ContainsKey("globalStart"))
            {
                syncPoints["globalStart"] = new BMLSyncPoint(this, "globalStart", value);
            }
            else
            {
                syncPoints.Add("globalStart", new BMLSyncPoint(this, "globalStart", value));
            }
        }

        public void IncreaseChild()
        {
            childNumber++;
        }

        public bool IncreaseEndChild()
        {
            endChildNumber++;

            return (endChildNumber == childNumber);
        }
    }
}
