using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBoxProxy : SpriteBase
    {
        public SpriteBox.Name SBName;
        public float x;
        public float y;
        public float width;
        public float height;
        SpriteBox pSpriteBox;
        Azul.Color pColor;
    
    
        public SpriteBoxProxy()
        {
            SBName = SpriteBox.Name.Uninitialized;
            x = 0.0f;
            y = 0.0f;
            width = 0.0f;
            height = 0.0f;
            pSpriteBox = null;
        }

        public SpriteBoxProxy(SpriteBox.Name _sbName)
        {
            SBName = _sbName;
            x = 0.0f;
            y = 0.0f;
            width = 0.0f;
            height = 0.0f;
            pSpriteBox = SpriteBoxManager.Find(_sbName);
        }

        public void UpdateSpriteBox()
        {
            pSpriteBox.Set(this.x, this.y, this.width, this.height, this.pColor);
        }

        public void Set(SpriteBox.Name _sbName, float _x, float _y, float _width, float _height)
        {
            this.SBName = _sbName;
            this.pSpriteBox = SpriteBoxManager.Find(_sbName);
            this.x = _x;
            this.y = _y;
            this.width = _width;
            this.height = _height;
        }

        public override void Render()
        {
            this.UpdateSpriteBox();
            this.pSpriteBox.Update();
            this.pSpriteBox.Render();
        }

        public void Update(ColRect pRect)
        {
            this.x = pRect.x;
            this.y = pRect.y;
            this.width = pRect.width;
            this.height = pRect.height;

            this.UpdateSpriteBox();
            this.pSpriteBox.Update();
            this.pSpriteBox.poColor = SpriteBoxManager.ClearSpriteBoxColor;
        }

        public override void Update()
        {
            this.UpdateSpriteBox();
            this.pSpriteBox.Update();
        }

        public override void Wash()
        {
            base.Wash();
            this.x = 0.0f;
            this.y = 0.0f;
            this.SBName = SpriteBox.Name.Uninitialized;
            this.pSpriteBox = null;
        }

        public override bool Compare(NodeBase pNode)
        {
            Debug.Assert(pNode != null);
            SpriteBoxProxy pSBP = (SpriteBoxProxy)pNode;

            return (pSBP.SBName == this.SBName);
        }

        public void SetColor(Azul.Color color)
        {
            this.pColor = color;
        }

    }


}
