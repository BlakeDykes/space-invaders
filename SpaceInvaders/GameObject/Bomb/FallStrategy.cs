using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class FallStrategy : SLink
    {
        public FallStrategy.Name StrategyName;
        public Sprite.Name SpriteName;

        protected ImageProxy pCurImage;

        protected float OldPosY;
        protected float AnimationInterval = 20.0f;

        public enum Name
        {
            Straight,
            ZigZag,
            Dagger
        }

        public void SetStartingPosition(float pos)
        {
            this.OldPosY = pos;
        }

        public virtual void Fall(Bomb pBomb)
        {
            if (pBomb.y < pBomb.OldPosY - this.AnimationInterval)
            {
                this.pCurImage = (ImageProxy)pCurImage.pNext;
                pBomb.pSpriteProxy.SwapImage(pCurImage);

                pBomb.SetOldPosY(pBomb.y);
            }
        }
        public virtual Sprite.Name GetSpriteName()
        {
            return this.SpriteName;
        }
    }
}
