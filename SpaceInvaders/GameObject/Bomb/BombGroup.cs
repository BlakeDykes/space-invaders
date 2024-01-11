using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombGroup : Composite
    {
        public BombGroup()
            : base(GameObject.Name.BombGroup, Sprite.Name.NullProxy)
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Update()
        {
            BaseUpdateColBox(this, out this.LeafCount);
            base.Update();
        }

        public override void Visit(MissleGroup m)
        {
            //Debug.WriteLine(" Collision: {0} <-> {1}", m.GOName, this.GOName);
            GameObject pChild = (GameObject)this.GetChild();

            while(pChild != null)
            {
                ColPair.Collide(m, pChild);
                pChild = (GameObject)pChild.pNext;
            }
        }
    }
}
