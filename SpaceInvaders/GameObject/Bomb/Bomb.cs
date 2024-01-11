using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Bomb : BombBase
    {
        public FallStrategy pStrategy;
        public float OldPosY;
        public float Delta;

        public bool ColorSwapped;

        public Bomb(Name _name, FallStrategy pStrategy, float _x, float _y, BombType bombType) 
            : base(_name, pStrategy.GetSpriteName(), _x, _y, bombType)
        {
            this.pStrategy = pStrategy;
            this.OldPosY = _y;

            this.Delta = Constants.BOMB_SPEED;

            this.ColorSwapped = false;
        }

        public void SetStrategy(FallStrategy _strategy)
        {
            this.pStrategy = _strategy;
        }

        public override void Update()
        {
            this.y -= Delta;
            pStrategy.Fall(this);

            if (ColorSwapped == false)
            {
                // Swap Color if in the Green Zone
                if (this.y <= Constants.GREEN_ZONE)
                {
                    this.pSpriteProxy.SwapColor(Constants.GREEN);
                    ColorSwapped = true;
                }
            }
 
            base.Update();
        }

        public void Recycle(float _x, float _y, FallStrategy pStrat)
        {
            this.x = _x;
            this.y = _y;
            this.pStrategy = pStrat;
            this.OldPosY = _y;
            this.Delta = Constants.BOMB_SPEED;
            this.pSpriteProxy.SwapColor(Constants.DEFAULT_SPRITE_COLOR);
            this.ColorSwapped = false;

            base.Recycle();
        }

        public void SetOldPosY(float pos)
        {
            this.OldPosY = pos;
        }

        public override void Visit(MissleGroup m)
        {
            Debug.WriteLine(" Collision: {0} <-> {1}", m.GOName, this.GOName);
            GameObject pChild = (GameObject)m.GetChild();
            ColPair.Collide(pChild, this);
        }

        public override void Visit(Missle m)
        {
            Debug.WriteLine(" {0} Collided with {1}", m.GOName, this.GOName);
            Debug.WriteLine("------------------------");
            Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(m, this);
            pActiveCol.Notify();
        }
    }
}
