using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace BMLNet
{
    /// <summary>
    /// abstract class of BML block
    /// all block need to be derived from this class
    /// </summary>
    public abstract class BMLBlock
    {
        /// <summary>
        /// Unique ID that allows referencing to a particular bml block. The id 'bml’ is reserved.
        /// </summary>
        public string id;

        /// <summary>
        /// Sync Point collection of this block
        /// </summary>
        public Dictionary<string, BMLSyncPoint> syncPoints = new Dictionary<string, BMLSyncPoint>();

        /// <summary>
        /// parent bml tag
        /// </summary>
        public BMLBml parentBml;


        /// <summary>
        /// empty constructor
        /// </summary>
        public BMLBlock()
        {
            
        }

        /// <summary>
        /// all child class need to implement their own parsing standard
        /// </summary>
        /// <param name="reader"></param>
        public abstract void Parse(XmlReader reader);

        /// <summary>
        /// helper function to parse the atribute from XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param> XMLReader
        /// <param name="atributeName"></param> the atribute name that we need to parse
        /// <param name="defaultValue"></param> the value when we do not find the atribute
        /// <param name="required"></param> do you require this atribute or not ?
        /// <returns></returns>
        protected T TryParseAtribute<T>(XmlReader reader, string atributeName, T defaultValue, bool required = true)
        {
            string valueString = reader.GetAttribute(atributeName);

            if (valueString == null && required)
            {
                Console.Error.WriteLine("WARNING: block " + reader.Name + " missing attribute " + atributeName + " !");
            }
            else {
                // if we need int value
                if (typeof(T) == typeof(int))
                {
                    int valueInt = 0;
                    if (required && !int.TryParse(valueString, out valueInt))
                    {
                        Console.Error.WriteLine("WARNING: block " + reader.Name + " cannot parse " + atributeName + " as an int !");
                    }
                    else
                    {
                        return (T)Convert.ChangeType(valueInt, typeof(T));
                    }
                }
                // if we need float value
                else if (typeof(T) == typeof(float))
                {
                    float valueFloat = 0.0f;
                    if (required && !float.TryParse(valueString, out valueFloat))
                    {
                        Console.Error.WriteLine("WARNING: block " + reader.Name + " cannot parse " + atributeName + " as a float!");
                    }
                    else
                    {
                        return (T)Convert.ChangeType(valueFloat, typeof(T));
                    }
                }
                // if we need string value
                else if (typeof(T) == typeof(string))
                {
                    return (T)Convert.ChangeType(valueString, typeof(T));
                }
            }

            // default value
            return defaultValue;
        }

        /// <summary>
        /// helper function to parse the sync point attribute
        /// we do not need to check whether we found the atribute or not.
        /// The BMLSyncPoint class will use those value (null or not null).
        /// </summary>
        /// <param name="reader"></param> XMLReader
        /// <param name="eventName"></param> the name of sync point (start, ready, strokeStart, attackPeak, stroke, strokeEnd, relax, end)
        /// <returns></returns>
        protected bool TryParseSyncPoint(XmlReader reader, string eventName)
        {
            string value = reader.GetAttribute(eventName);
            if (value != null)
            {
                syncPoints.Add(eventName, new BMLSyncPoint(this, eventName, value));
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            IEnumerator enumerator = syncPoints.GetEnumerator();

            while (enumerator.MoveNext())
            {
                //get the pair of Dictionary
                KeyValuePair<string, BMLBlock> pair = ((KeyValuePair<string, BMLBlock>)(enumerator.Current));

                //dispose it
                pair.Value.Dispose();
            }

            syncPoints.Clear();
        }

        public String getCharacterId()
        {
            if (parentBml == null)
                return "";
            else
                return parentBml.characterId;
        }
    }
}
