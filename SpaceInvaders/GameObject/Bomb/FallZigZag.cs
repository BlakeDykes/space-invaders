using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FallZigZag : FallStrategy
    {
        private ImageProxy pImage1;
        private ImageProxy pImage2;
        private ImageProxy pImage3;
        private ImageProxy pImage4;

        public FallZigZag()
        {
            this.StrategyName = FallStrategy.Name.ZigZag;
            this.SpriteName = Sprite.Name.BombZigZag;

            // Get images to animate through
            this.pImage1 = new ImageProxy(ImageManager.Find(Image.Name.Bomb_ZigZag1));
            this.pImage2 = new ImageProxy(ImageManager.Find(Image.Name.Bomb_ZigZag2));
            this.pImage3 = new ImageProxy(ImageManager.Find(Image.Name.Bomb_ZigZag3));
            this.pImage4 = new ImageProxy(ImageManager.Find(Image.Name.Bomb_ZigZag4));

            // Set animation loop
            this.pImage1.pNext = pImage2;
            this.pImage2.pNext = pImage3;
            this.pImage3.pNext = pImage4;
            this.pImage4.pNext = pImage1;

            this.pCurImage = pImage1;
        }
    }
}
