using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColObject
    {
        public SpriteBoxProxy pColSprite;
        public ColRect poColRect;

        public ColObject(SpriteProxy pSpriteProxy)
        {
            Debug.Assert(pSpriteProxy != null);

            this.poColRect = new ColRect(pSpriteProxy.x, pSpriteProxy.y, pSpriteProxy.GetWidth(), pSpriteProxy.GetHeight());

            this.pColSprite = SpriteBoxProxyManager.Add(SpriteBox.Name.ColBox, poColRect.x, poColRect.y, poColRect.width, poColRect.height);
            this.pColSprite.SetColor(Constants.RED);
        }

        public ColObject(SpriteProxy pSpriteProxy, float _width, float _height)
        {
            Debug.Assert(pSpriteProxy != null);

            this.poColRect = new ColRect(pSpriteProxy.x, pSpriteProxy.y, _width, _height);

            this.pColSprite = SpriteBoxProxyManager.Add(SpriteBox.Name.ColBox, poColRect.x, poColRect.y, poColRect.width, poColRect.height);
            this.pColSprite.SetColor(Constants.RED);

        }

        public void Recycle(SpriteProxy pSpriteProxy)
        {
            Debug.Assert(pSpriteProxy != null);

            Sprite pSprite = pSpriteProxy.pSprite;

            this.poColRect.SetBounds(pSpriteProxy);

            this.pColSprite.Set(SpriteBox.Name.ColBox, this.poColRect.x, this.poColRect.y, this.poColRect.width, this.poColRect.height);
        }

        public void UpdatePos(float x, float y)
        {
            this.poColRect.UpdatePos(x, y);
            this.pColSprite.Update(poColRect);
        }

        public void UpdateRec()
        {
            poColRect.Update();
        }
    }
}
