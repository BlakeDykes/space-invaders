using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldBrick : ShieldBase
    {
        public ShieldBrick(Name _name, Sprite.Name _spriteName, float _x, float _y, ShieldBase.ShieldType shieldType, Azul.Color pColor) 
            : base(_name, _spriteName, _x, _y, shieldType, pColor)
        {
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Visit(MissleGroup m)
        {
            GameObject pMissle = (GameObject)m.GetChild();
            ColPair.Collide(pMissle, this);
        }

        public override void Visit(Missle m)
        {
            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(m, this);
            pActiveCol.Notify();
        }

        public override void Visit(BombGroup b)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", b.GOName, this.GOName);
            GameObject pBomb = (GameObject)b.GetChild();

            while(pBomb != null)
            {
                ColPair.Collide(pBomb, this);
                pBomb = (GameObject)pBomb.pNext;
            }
        }

        public override void Visit(BombBase b)
        {
            //Debug.WriteLine(" {0} Collided with {1}", b.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(b, this);
            pActiveCol.Notify();
        }
    }
}
