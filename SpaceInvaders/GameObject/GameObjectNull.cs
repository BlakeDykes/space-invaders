using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameObjectNull : Leaf
    {
        public GameObjectNull()
            :base(GameObject.Name.Null_Object, Sprite.Name.NullProxy, 0.0f, 0.0f, Constants.TRANSPARENT)
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Add(Component pComp)
        {
        }
    }
}
