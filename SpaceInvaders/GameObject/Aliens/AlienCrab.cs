using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienCrab : AlienBase
    {
        public AlienCrab(Sprite.Name _name, float _x, float _y, Azul.Color color)
            : base(GameObject.Name.Crab, _name, _x, _y, color)
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Visit(Missle m)
        {
            //Debug.WriteLine(" {0} Collided with {1}", m.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(m, this);
            pActiveCol.Notify();
        }

        public override void Visit(MissleGroup m)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", m.GOName, this.GOName);
            GameObject pMissle = (GameObject)m.GetChild();
            ColPair.Collide(pMissle, this);
        }

        public override void Visit(WallGroup w)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", w.GOName, this.GOName);
            GameObject pWall = (GameObject)w.GetChild();
            ColPair.Collide(w, pWall);
        }

        public override void Visit(WallLeft w)
        {
            //Debug.WriteLine(" {0} Collided with {1}", w.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(w, this);
            pActiveCol.Notify();
        }

        public override void Visit(WallRight w)
        {
            //Debug.WriteLine(" {0} Collided with {1}", w.GOName, this.GOName);
            //Debug.WriteLine("------------------------");
            //Debug.WriteLine("");

            ColPair pActiveCol = ColPairManager.GetActivePair();
            pActiveCol.SetCollision(w, this);
            pActiveCol.Notify();
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }
    }
}
