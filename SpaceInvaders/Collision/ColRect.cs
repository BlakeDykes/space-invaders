using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColRect : Azul.Rect
    {
        public float minX;
        public float maxX;
        public float minY;
        public float maxY;

        public ColRect(float x, float y, float width, float height)
            :base(x, y, width, height)
        {
            this.minX = x - width * 0.5f;
            this.maxX = minX + width;
            this.minY = y - height * 0.5f;
            this.maxY = minY + height;
        }

        public ColRect(Azul.Rect pRect)
            :base(pRect)
        {
        }

        public ColRect()
            : base()
        {
            this.minX = 0.0f;
            this.maxX = 0.0f;
            this.minY = 0.0f;
            this.maxY = 0.0f;
        }

        public void Update()
        {
            float width = this.maxX - this.minX;
            float height = this.maxY - this.minY;
            float x = this.minX + (width * 0.5f);
            float y = this.minY + (height * 0.5f);

            Set(x, y, width, height);
        }

        public void ClearMinMax()
        {
            this.minX = 0.0f;
            this.maxX = 0.0f;
            this.minY = 0.0f;
            this.maxY = 0.0f;
        }

        public void UpdatePos(float _x, float _y)
        {
            this.minX -= (this.x - _x);
            this.maxX -= (this.x - _x);
            this.minY -= (this.y - _y);
            this.maxY -= (this.y - _y);
            this.x = _x;
            this.y = _y;
        }

        public bool Intersect(ColRect colRect)
        {
            bool status = false;

            if((this.minX > colRect.maxX) || (this.maxX < colRect.minX) || (this.minY > colRect.maxY) || (this.maxY < colRect.minY))
            {
                status = false;
            }
            else
            {
                status = true;
            }

            return status;
        }

        public void SetBounds(SpriteProxy pSpriteProxy)
        {
            this.width = pSpriteProxy.pSprite.poRect.width;
            this.height = pSpriteProxy.pSprite.poRect.height;
            this.minX = this.x - this.width * .5f;
            this.minY = this.y - this.height * .5f;
            this.maxY = this.minY + this.height;
            this.maxX = this.minX + this.width;
        }

        public void SetLocal(ColRect colRect)
        {
            this.minX = colRect.minX;
            this.maxX = colRect.maxX;
            this.minY = colRect.minY;
            this.maxY = colRect.maxY;
        }

        public void Union(ColRect colRect)
        {
            if(this.minX > colRect.minX)
            {
                this.minX = colRect.minX;
            }
            if(this.maxX < colRect.maxX)
            {
                this.maxX = colRect.maxX;
            }
            if (this.minY > colRect.minY)
            {
                this.minY = colRect.minY;
            }
            if (this.maxY < colRect.maxY)
            {
                this.maxY = colRect.maxY;
            }
        }
    }
}
