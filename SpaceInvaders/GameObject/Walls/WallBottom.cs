using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallBottom : WallBase
    {
        public WallBottom(Name _name, Sprite.Name _spriteName, float _x, float _y, float _width, float _height, Azul.Color pColor) 
            : base(_name, _spriteName, _x, _y, _width, _height, pColor)
        {
            this.wallType = WallType.Bottom;
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Visit(BombGroup b)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", b.GOName, this.GOName);
            GameObject pMissle = (GameObject)b.GetChild();

            while (pMissle != null)
            {
                ColPair.Collide(pMissle, this);
                pMissle = (GameObject)pMissle.pNext;
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
