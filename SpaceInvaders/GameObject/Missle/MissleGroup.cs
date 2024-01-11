using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissleGroup : Composite
    {
        public MissleGroup() 
            : base(GameObject.Name.MissleGroup, Sprite.Name.NullProxy)
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
    }
}
