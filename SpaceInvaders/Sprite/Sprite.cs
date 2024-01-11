using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Sprite : SpriteBase
    {

        //---------------------------------------------
        // Data
        //---------------------------------------------
        public Name SpriteName;
        public float angle;
        public float sx;
        public float sy;
        public float x;
        public float y;
        public Image pImage;
        public Azul.Color poColor;
        public Azul.Rect poRect;
        public Azul.Sprite poAzulSprite;

        //---------------------------------------------
        // Enum
        //---------------------------------------------
        public enum Name
        {
            Ship,
            Missle,

            AlienCrab,
            AlienOcto,
            AlienSquid,

            UFO,

            BombStraight,
            BombDagger,
            BombZigZag,

            Brick,
            Brick_2_2,
            Brick_2_4,
            Brick_2_3,
            Brick_3_4,
            Brick_3_3,
            Brick_3_2,
            Brick_LeftTop0,
            Brick_LeftTop1,
            Brick_LeftBottom,
            Brick_RightTop0,
            Brick_RightTop1,
            Brick_RightBottom,

            Wall_Bottom,

            Explosion_Small,
            Explosion_Large,
            Explosion_Alien,
            Explosion_Ship,

            Text,

            NullProxy,

            Uninitialized
        }

        //---------------------------------------------
        // Constructors
        //---------------------------------------------
        public Sprite()
            :base()
        {
            this.SpriteName = Name.Uninitialized;
            this.angle = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pImage = null;

            // LTN - Sprite
            this.poColor = new Azul.Color();

            // LTN - Sprite
            this.poRect = new Azul.Rect();

            // LTN - Sprite
            this.poAzulSprite = new Azul.Sprite();
        }

        public Sprite(Name _name, Image _image, Azul.Color _color, float _x, float _y, float _width, float _height, 
                        float _sx = 1.0f, float _sy = 1.0f, float _angle = 0.0f)
            :base()
        {
            this.SpriteName = _name;
            this.pImage = _image;

            // LTN - Sprite
            this.poColor = _color == null ? new Azul.Color(Constants.DEFAULT_SPRITE_COLOR) : _color;
            this.angle = _angle;
            this.sx = _sx;
            this.sy = _sy;
            this.x = _x;
            this.y = _y;

            // LTN - Sprite
            this.poRect = new Azul.Rect(this.x, this.y, _width, _height);
            Debug.Assert(this.poRect != null);

            // LTN - Sprite
            this.poAzulSprite = new Azul.Sprite(_image.poTexture.poAzulTexture, _image.poRect, this.poRect);
            Debug.Assert(this.poAzulSprite != null);

            this.poAzulSprite.sx = this.sx;
            this.poAzulSprite.sy = this.sy;
            this.poAzulSprite.angle = this.angle;
        }

        //---------------------------------------------
        // Methods
        //---------------------------------------------
        public override void Render()
        {
            poAzulSprite.Render();
        }

        public void Set(Sprite.Name _name, Image _image, Azul.Color _color, float _x, float _y, float _width, float _height,
                            float _sx = 1.0f, float _sy = 1.0f, float _angle = 0.0f)
        {
            this.SpriteName = _name;
            this.pImage = _image;
            this.angle = _angle;
            this.sx = _sx;
            this.sy = _sy;
            this.x = _x;
            this.y = _y;

            Debug.Assert(this.poColor != null);
            if (_color != null)
            {
                this.poColor.Set(_color);
            }

            Debug.Assert(this.poRect != null);
            this.poRect.Set(this.x, this.y, _width, _height);

            Debug.Assert(this.poAzulSprite != null);
            this.poAzulSprite.Swap(this.pImage.poTexture.poAzulTexture, this.pImage.poRect, this.poRect, this.poColor);

            poAzulSprite.angle = this.angle;
            poAzulSprite.sx = this.sx;
            poAzulSprite.sy = this.sy;
        }
        public void Set(Name _name, Image _image, Azul.Color _color, float _width, float _height)
        {
            this.SpriteName = _name;
            this.pImage = _image;

            // LTN - Sprite
            this.poColor = _color == null ? new Azul.Color(Constants.DEFAULT_SPRITE_COLOR) : _color;
            this.angle = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.x = 0.0f;
            this.y = 0.0f;

            Debug.Assert(this.poRect != null);
            this.poRect.Set(this.x, this.y, _width, _height);

            Debug.Assert(this.poAzulSprite != null);
            this.poAzulSprite.Swap(this.pImage.poTexture.poAzulTexture, this.pImage.poRect, this.poRect, this.poColor);

        }

        public void SwapImage(Image _pImage)
        {
            Debug.Assert(_pImage != null);
            this.pImage = _pImage;

            this.poAzulSprite.SwapTexture(pImage.GetAzulTexture());
            this.poAzulSprite.SwapTextureRect(pImage.poRect);
        }

        public override void Update()
        {
            poAzulSprite.angle = this.angle;
            poAzulSprite.sx = this.sx;
            poAzulSprite.sy = this.sy;
            poAzulSprite.x = this.x;
            poAzulSprite.y = this.y;
            poAzulSprite.SwapColor(this.poColor);
            this.poAzulSprite.Update();
        }

        public static void Update(Sprite _sprite)
        {
            _sprite.poAzulSprite.angle = _sprite.angle;
            _sprite.poAzulSprite.sx = _sprite.sx;
            _sprite.poAzulSprite.sy = _sprite.sy;
            _sprite.poAzulSprite.x = _sprite.x;
            _sprite.poAzulSprite.y = _sprite.y;
            _sprite.poAzulSprite.SwapColor(_sprite.poColor);

            _sprite.poAzulSprite.Update();
        }

        public override void Wash()
        {
            base.Wash();
            this.Clear();
        }

        private void Clear()
        {
            this.SpriteName = Name.Uninitialized;
            this.angle = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pImage = null;

            this.poColor.Set(Constants.DEFAULT_SPRITE_COLOR);
            this.poRect.Clear();

            Image pNullImage = ImageManager.Find(Image.Name.NullImage);
            Debug.Assert(pNullImage != null);

            this.poAzulSprite.Swap(pNullImage.poTexture.poAzulTexture, pNullImage.poRect, this.poRect, this.poColor);
        }

        public override bool Compare(NodeBase pNode)
        {
            Debug.Assert(pNode != null);
            Sprite pComp = (Sprite)pNode;

            return (this.SpriteName == pComp.SpriteName);
        }
    }
}
