using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBox : SpriteBase
    {
        //---------------------------------------------
        // Data
        //---------------------------------------------
        public Name SpriteName;
        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;
        public Azul.Color poColor;
        private Azul.SpriteBox poAzulSpriteBox;

        // LTN - SpriteBox
        static private Azul.Rect poRect = new Azul.Rect();


        public enum Name
        {
            SquidBox,
            CrabBox,
            OctoBox,
            AlienColumn,
            AlienGrid,
            ColBox,

            Text,

            Uninitialized
        }

        public SpriteBox()
        {
            this.SpriteName = Name.Uninitialized;
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;

            // LTN - SpriteBox
            this.poColor = new Azul.Color();

            // LTN - SpriteBox
            this.poAzulSpriteBox = new Azul.SpriteBox();
    }
        public SpriteBox(Name _name, Azul.Color _color, float _x, float _y, float _width, float _height,
                        float _sx = 1.0f, float _sy = 1.0f, float _angle = 0.0f)
            :base()
        {
            this.SpriteName = _name;

            // LTN - SpriteBox
            this.poColor = _color == null ? new Azul.Color(SpriteBoxManager.DefaultSpriteBoxColor) : _color;
            this.x = _x;
            this.y = _y;
            this.sx = _sx;
            this.sy = _sy;
            this.angle = _angle;

            SpriteBox.poRect.Set(x, y, _width, _height);

            // LTN - SpriteBox
            this.poAzulSpriteBox = new Azul.SpriteBox(SpriteBox.poRect, this.poColor);
        }

        public void Set(Name _name, Azul.Color _color, float _x, float _y, float _width, float _height,
                        float _sx = 1.0f, float _sy = 1.0f, float _angle = 0.0f)
        {
            this.SpriteName = _name;
            this.x = _x;
            this.y = _y;
            this.sx = _sx;
            this.sy = _sy;
            this.angle = _angle;

            this.poColor.Set(_color);

            poRect.Set(x, y, _width, _height);

            Debug.Assert(this.poAzulSpriteBox != null);
            this.poAzulSpriteBox.Swap(SpriteBox.poRect, this.poColor);
        }
        
        public void Set(float _x, float _y, float _width, float _height, Azul.Color pColor)
        {
            this.x = _x;
            this.y = _y;
            poRect.Set(x, y, _width, _height);
            this.poColor.Set(pColor);

            Debug.Assert(this.poAzulSpriteBox != null);
            this.poAzulSpriteBox.SwapScreenRect(SpriteBox.poRect);
        }

        public override void Update()
        {
            this.poAzulSpriteBox.x = this.x;
            this.poAzulSpriteBox.y = this.y;
            this.poAzulSpriteBox.sx = this.sx;
            this.poAzulSpriteBox.sy = this.sy;
            this.poAzulSpriteBox.angle = this.angle;
            this.poAzulSpriteBox.SwapColor(this.poColor);
            this.poAzulSpriteBox.Update();
        }

        public override void Render()
        {
            this.poAzulSpriteBox.Render();
        }

        public override void Wash()
        {
            base.Wash();
            Clear();
        }

        private void Clear()
        {
            this.SpriteName = Name.Uninitialized;
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 0.0f;
            this.sy = 0.0f;
            this.angle = 0.0f;
            this.poColor.Set(Constants.DEFAULT_SPRITE_COLOR);
        }

        public override bool Compare(NodeBase pNode)
        {
            Debug.Assert(pNode != null);
            SpriteBox pComp = (SpriteBox)pNode;

            return (this.SpriteName == pComp.SpriteName);
        }
    }
}
