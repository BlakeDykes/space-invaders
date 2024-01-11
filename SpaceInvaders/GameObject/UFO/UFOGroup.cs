using Azul;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOGroup : Composite
    {
        public UFOGroup() 
            : base(GameObject.Name.UFOGroup, Sprite.Name.NullProxy, 0.0f, 0.0f, Constants.TRANSPARENT)
        {
        }

        public override void Visit(MissleGroup m)
        {
            GameObject pChild = (GameObject)this.GetChild();
            ColPair.Collide(m, pChild);
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
    }
}
