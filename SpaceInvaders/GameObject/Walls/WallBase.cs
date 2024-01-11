using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class WallBase : Leaf
    {
        public WallType wallType;

        public enum WallType
        {
            Group,

            Top,
            Left,
            Right,
            Bottom,

            Uninitialized
        }

        public WallBase(Name _name, Sprite.Name _spriteName, float _x, float _y, float _width, float _height, Azul.Color pColor) 
            : base(_name, _spriteName, _x, _y, _width, _height, pColor)
        {
            this.poColObj.poColRect.Set(x, y, _width, _height);
        }

        public WallType GetWallType()
        {
            return this.wallType;
        }

    }
}
