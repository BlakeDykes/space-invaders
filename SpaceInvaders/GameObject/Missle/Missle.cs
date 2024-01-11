using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Missle : MissleBase
    {
        public float MissleSpeed;
        private bool ColorSwapped;

        public Missle(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, Azul.Color pColor) 
            : base(_name, _spriteName, _x, _y, pColor)
        {
            this.MissleSpeed = Constants.MISSLE_SPEED;

            this.ColorSwapped = false;
        }

        public Missle()
            : base(GameObject.Name.Missle, Sprite.Name.Missle, 0.0f, 0.0f, Constants.GREEN)
        {
            this.MissleSpeed = Constants.MISSLE_SPEED;

            this.ColorSwapped = false;
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Remove()
        {
            this.poColObj.poColRect.Set(0.0f, 0.0f, 0.0f, 0.0f);
            base.Update();

            GameObject pParent = (GameObject)this.GetParent();
            pParent.Update();

            base.Remove();
        }

        public void SetPos(float _x, float _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public override void Update()
        {
            this.y += MissleSpeed;
            if (ColorSwapped == false)
            {
                // Swap Color if in the Green Zone
                if (this.y >= Constants.GREEN_ZONE)
                {
                    this.pSpriteProxy.SwapColor(Constants.DEFAULT_SPRITE_COLOR);
                    ColorSwapped = true;
                }
            }
            base.Update();
        }

        public void Recycle(float _x, float _y)
        {
            this.x = _x;
            this.y = _y;
            this.MissleSpeed = Constants.MISSLE_SPEED;

            base.Recycle();
        }
    }
}
