using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombBase : Leaf
    {
        public BombBase.BombType mBombType;

        public enum BombType
        {
            Bomb,
            BombGroup,
            Uninitialized
        }

        public BombBase(Name _name, Sprite.Name _spriteName, float _x, float _y, BombBase.BombType bombType) 
            : base(_name, _spriteName, _x, _y, Constants.DEFAULT_SPRITE_COLOR)
        {
            this.mBombType = bombType;
        }

        public override void Accept(ColVisitor other)
        {
            other.Visit(this);
        }

        public override void Update()
        {
            base.Update();
        }

    }
}
