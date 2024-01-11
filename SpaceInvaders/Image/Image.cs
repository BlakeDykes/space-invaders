using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Image : DLink
    {
        //---------------------------------------------
        // Data
        //---------------------------------------------
        public Name ImageName;
        public Azul.Rect poRect;
        public Texture poTexture;

        //---------------------------------------------
        // Enum
        //---------------------------------------------
        public enum Name
        {
            Ship,                           // 2.0f, 14.0f, 13.0f, 8.0f
            Missle,                         // 2.0f, 29.0f, 1.0f, 4.0f

            Crab1,                          // 135.0f, 64.0f,  85.0f, 64.0f
            Crab2,                          // 252.0f, 64.0f,  85.0f, 64.0f
            Octo1,                          // 558.0f, 64.0f,  93.0f, 64.0f
            Octo2,                          // 27.0f,  200.0f, 93.0f, 64.0f
            Squid1,                         // 368.0f, 64.0f,  64.0f, 64.0f
            Squid2,                         // 463.0f, 64.0f,  64.0f, 64.0f

            UFO,                            // 99.0f, 4.0f, 16.0f, 7.0f

            Bomb_Straight1,                 // 65.0f, 26.0f, 3.0f, 7.0f
            Bomb_Straight2,                 // 70.0f, 26.0f, 3.0f, 7.0f
            Bomb_Straight3,                 // 80.0f, 26.0f, 3.0f, 7.0f
            Bomb_ZigZag1,                   // 18.0f, 26.0f, 3.0f, 7.0f
            Bomb_ZigZag2,                   // 24.0f, 26.0f, 3.0f, 7.0f
            Bomb_ZigZag3,                   // 30.0f, 26.0f, 3.0f, 7.0f
            Bomb_ZigZag4,                   // 36.0f, 26.0f, 3.0f, 7.0f
            Bomb_Dagger1,                   // 60.0f, 27.0f, 3.0f, 6.0f
            Bomb_Dagger2,                   // 54.0f, 27.0f, 3.0f, 6.0f
            Bomb_Dagger3,                   // 48.0f, 27.0f, 3.0f, 6.0f
            Bomb_Dagger4,                   // 42.0f, 27.0f, 3.0f, 6.0f

            Shield_Brick,                   // 119.0f, 37.0f, 3.0f, 2.0f
            Shield_Brick_SmallColumn,       // 119.0f, 37.0f, 2.0f, 2.0f
            Shield_Brick_LeftTop0,          // 114.0f, 34.0f, 2.0f, 3.0f
            Shield_Brick_LeftTop1,          // 116.0f, 31.0f, 3.0f, 2.0f
            Shield_Brick_LeftBottom,        // 119.0f, 43.0f, 2.0f, 3.0f
            Shield_Brick_RightTop0,         // 134.0f, 34.0f, 2.0f, 3.0f
            Shield_Brick_RightTop1,         // 131.0f, 31.0f, 3.0f, 2.0f
            Shield_Brick_RightBottom,       // 128.0f, 43.0f, 3.0f, 2.0f

            Explosion_Small,                // 86.0f, 25.0f, 6.0f, 8.0f
            Explosion_Large,                // 7.0f, 25.0f, 8.0f, 8.0f
            Explosion_Alien,                // 83.0f, 3.0f, 13.0f, 8.0f
            Explosion_Ship1,                // 20.0f, 14.0f, 15.0f, 8.0f
            Explosion_Ship2,                // 38.0f, 14.0f, 16.0f, 8.0f

            NullImage,
            Uninitialized
        }

        //---------------------------------------------
        // Constructors
        //---------------------------------------------
        public Image(Name name, Azul.Rect rect, Texture texture)
        {
            this.ImageName = name;
            this.poRect = rect;
            this.poTexture = texture;
        }

        public Image()
        {
            this.ImageName = Name.Uninitialized;

            // LTN - Image
            this.poRect = new Azul.Rect();
            this.poTexture = null;
        }

        //---------------------------------------------
        // Methods
        //---------------------------------------------
        public override void Wash()
        {
            base.Wash();
            this.Clear();
        }

        private void Clear()
        {
            Debug.Assert(this.poRect != null);
            this.poRect.Clear();
            
            this.poTexture = null;
            this.ImageName = Name.Uninitialized;

        }

        public void Set(Image.Name name, Texture texture, float x, float y, float width, float height)
        {
            this.ImageName = name;
            this.poRect.Set(x, y, width, height);
            this.poTexture = texture;
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.poTexture.poAzulTexture;
        }

        public Azul.Rect GetAzulRect()
        {
            return this.poRect;
        }
        public override bool Compare(NodeBase pNode)
        {
            Debug.Assert(pNode != null);

            Image compImage = (Image)pNode;

            return (this.ImageName == compImage.ImageName);
        }
    }
}
