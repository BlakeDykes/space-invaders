using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ShipBase : Leaf
    {
        public ShipBase.Category ShipType;

        public enum Category
        {
            Ship,
            Life,
            ShipRoot,
            
            Uninitialized
        }

        public ShipBase(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, ShipBase.Category shipType, Azul.Color pColor)
            :base(_name, _spriteName, _x, _y, pColor)
        {
            this.ShipType = shipType;
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
