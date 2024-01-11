using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SpriteBase : DLink
    {
        private SpriteNode pParentNode;

        public SpriteBase()
            : base()
        {
        }
        
        public SpriteNode GetParent()
        {
            Debug.Assert(this.pParentNode != null);
            return this.pParentNode;
        }

        public void SetParent(SpriteNode _pParentNode)
        {
            Debug.Assert(_pParentNode != null);
            this.pParentNode = _pParentNode;
        }

        abstract public void Render();
        abstract public void Update();
    }
}
