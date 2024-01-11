using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteNode : DLink
    {
        public SpriteBase pSpriteBase;
        public SpriteNodeManager pParent;

        public SpriteNode()
            : base()
        {
            this.pSpriteBase = null;
            this.pParent = null;
        }

        public void Set(Sprite.Name name, SpriteNodeManager _pParent)
        {
            this.pParent = _pParent;

            this.pSpriteBase = SpriteManager.Find(name);
            Debug.Assert(pSpriteBase != null);
            this.pSpriteBase.SetParent(this);
        }
        public void Set(SpriteBox.Name name, SpriteNodeManager _pParent)
        {
            this.pParent = _pParent;

            this.pSpriteBase = SpriteBoxManager.Find(name);

            Debug.Assert(pSpriteBase != null);
            this.pSpriteBase.SetParent(this);
        }

        public void Set(Font.Name name, SpriteNodeManager _pParent)
        {
            this.pParent = _pParent;

            this.pSpriteBase = (SpriteBase)FontManager.FindSpriteFont(name);

            Debug.Assert(pSpriteBase != null);
            this.pSpriteBase.SetParent(this);
        }

        public void Set(SpriteProxy pSprite, SpriteNodeManager _pParent)
        {
            this.pParent = _pParent;

            this.pSpriteBase = pSprite;

            this.pSpriteBase.SetParent(this);
        }

        public void Set(SpriteBoxProxy pSB, SpriteNodeManager _pParent)
        {
            this.pParent = _pParent;

            this.pSpriteBase = pSB;
            this.pSpriteBase.SetParent(this);
        }

        public SpriteNodeManager GetParent()
        {
            Debug.Assert(this.pParent != null);
            return this.pParent;
        }

        public override void Wash()
        {
            base.Wash();
        }
    }
}
