using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ShieldBase : Leaf
    {
        public ShieldBase.ShieldType shieldType;

        protected ShieldBase(Name _name, Sprite.Name _spriteName, float _x, float _y, ShieldBase.ShieldType _shieldType, Azul.Color pColor) 
            : base(_name, _spriteName, _x, _y, pColor)
        {
            this.shieldType = _shieldType;
        }

        public enum ShieldType
        {
            Group,
            Grid,
            Column,
            Brick,
            Brick_2_2,
            Brick_2_4,
            Brick_2_3,
            Brick_3_4,
            Brick_3_3,
            Brick_3_2,

            LeftTop0,
            LeftTop1,
            LeftBottom,
            RightTop0,
            RightTop1,
            RightBottom,

            Uninitialized
        }



    }
}
