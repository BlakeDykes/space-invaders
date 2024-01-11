using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FallDagger : FallStrategy
    {
        private ImageProxy pImage1;
        private ImageProxy pImage2;
        private ImageProxy pImage3;
        private ImageProxy pImage4;


        public FallDagger()
        {
            this.StrategyName = FallStrategy.Name.Dagger;
            this.SpriteName = Sprite.Name.BombZigZag;

            // Get images to animate through
            this.pImage1 = new ImageProxy(ImageManager.Find(Image.Name.Bomb_Dagger1));
            this.pImage2 = new ImageProxy(ImageManager.Find(Image.Name.Bomb_Dagger2));
            this.pImage3 = new ImageProxy(ImageManager.Find(Image.Name.Bomb_Dagger3));
            this.pImage4 = new ImageProxy(ImageManager.Find(Image.Name.Bomb_Dagger4));

            // Set animation loop
            this.pImage1.pNext = pImage2;
            this.pImage2.pNext = pImage3;
            this.pImage3.pNext = pImage4;
            this.pImage4.pNext = pImage1;

            this.pCurImage = pImage1;
        }
     }
}
