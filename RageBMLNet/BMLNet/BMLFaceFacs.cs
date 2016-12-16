
namespace BMLNet
{
    /// <summary>
    /// This behavior provides control of the face through single Action Units from the Facial Action Coding Scheme. It is an Core Extension, that is, not every BML Compliant Realizer has to implement this behavior, but if a Realizer offers FACS based face control, they should adhere to the specification of this <faceFacs> behavior
    /// </summary>
    public class BMLFaceFacs : BMLFace
    {
        /// <summary>
        /// The number of the FACS Action Unit to be displayed
        /// </summary>
        public int au;

        /// <summary>
        /// Which side of the face to display the action unit on. Possible values: [LEFT,RIGHT,BOTH] Note that for some Action Units, BOTH is the only possible value
        /// </summary>
        public Side side;

        /// <summary>
        /// 
        /// </summary>
        public enum Side
        {
            LEFT,
            RIGHT,
            BOTH
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BMLFaceFacs()
        {
            this.side = Side.BOTH;
        }

    }
}