using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteProxy : SpriteBase
    {
        public Sprite.Name SpriteName;
        public float x;
        public float y;
        public Sprite pSprite;
        public Image pImage;
        public Azul.Color pColor;

        public SpriteProxy()
            : base()
        {
            x = 0.0f;
            y = 0.0f;
            pSprite = null;
            pColor = Constants.DEFAULT_SPRITE_COLOR;
        }

        public SpriteProxy(Sprite.Name _name)
        {
            this.SpriteName = _name;
            this.x = 0.0f;
            this.y = 0.0f;
            pSprite = null;
            pColor = Constants.DEFAULT_SPRITE_COLOR;
        }

        public void UpdateLocal(float _x, float _y)
        {
            this.x = _x;
            this.y = _y;
        }

        private void UpdateSprite()
        {
            pSprite.x = this.x;
            pSprite.y = this.y;
            pSprite.poColor = this.pColor;
        }

        public void Set(Sprite.Name _name, float _x, float _y)
        {
            SpriteName = _name;
            this.pSprite = SpriteManager.Find(_name);
            this.x = _x;
            this.y = _y;
        }

        public void SwapImage(ImageProxy _pImage)
        {
            pSprite.SwapImage(_pImage.pImage);
        }

        public void SwapColor(Azul.Color _pColor)
        {
            this.pColor = _pColor;
        }

        public override void Render()
        {
            this.UpdateSprite();
            this.pSprite.Update();
            this.pSprite.Render();
        }

        public override void Update()
        {
            this.UpdateSprite();
            this.pSprite.Update();
        }

        public float GetWidth()
        {
            return this.pSprite.poRect.width;
        }

        public float GetHeight()
        {
            return this.pSprite.poRect.height;
        }

        public override void Wash()
        {
            base.Wash();
            this.x = 0.0f;
            this.y = 0.0f;
            this.SpriteName = Sprite.Name.Uninitialized;
            this.pSprite = null;
        }

        public void Remove()
        {
            SpriteNode pSpriteNode = this.GetParent();
            Debug.Assert(pSpriteNode != null);

            SpriteBatchManager.Remove(pSpriteNode);
        }

        public override bool Compare(NodeBase pNode)
        {
            Debug.Assert(pNode != null);
            SpriteProxy pSP = (SpriteProxy)pNode;

            return (pSP.SpriteName == this.SpriteName);
        }
    }
}
