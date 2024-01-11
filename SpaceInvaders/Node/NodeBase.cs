using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public abstract class NodeBase
    {
        abstract public void Wash();

        virtual public bool Compare(NodeBase pNode)
        {
            Debug.Assert(false);
            return false;
        }
    }
}
