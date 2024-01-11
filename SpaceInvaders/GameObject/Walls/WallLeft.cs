using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallLeft : WallBase
    {
        public WallLeft(Name _name, Sprite.Name _spriteName, float _x, float _y, float _width, float _height, Azul.Color pColor) 
            : base(_name, _spriteName, _x, _y, _width, _height, pColor)
        {
            this.wallType = WallType.Left;
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Visit(ShipGroup s)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", s.GOName, this.GOName);
            GameObject pChild = (GameObject)s.GetChild();
            ColPair.Collide(pChild, this);
        }

        public override void Visit(Ship s)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", s.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(s, this);
            pActiveCol.Notify();
        }

        public override void Visit(AlienGrid aG)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", aG.GOName, this.GOName);
            GameObject pChild = (GameObject)aG.GetChild();
            ColPair.Collide(pChild, this);
        }

        public override void Visit(AlienColumn aC)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", aC.GOName, this.GOName);
            GameObject pChild = (GameObject)aC.GetChild();
            ColPair.Collide(pChild, this);
        }

        public override void Visit(AlienCrab a)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", a.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(a, this);
            pActiveCol.Notify();
        }

        public override void Visit(AlienOcto a)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", a.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(a, this);
            pActiveCol.Notify();
        }

        public override void Visit(AlienSquid a)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", a.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(a, this);
            pActiveCol.Notify();
        }

        public override void Visit(UFOGroup u)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", m.GOName, this.GOName);
            GameObject pChild = (GameObject)u.GetChild();
            ColPair.Collide(pChild, this);
        }

        public override void Visit(UFO u)
        {
            //Debug.WriteLine(" {0} Collided with {1}", m.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(u, this);
            pActiveCol.Notify();
        }
    }
}
