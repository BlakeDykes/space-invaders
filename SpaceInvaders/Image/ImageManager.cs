using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageManager : ManagerBase
    {
        public static ImageManager instance = null;
        private Image pImageCompare;

        private ImageManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
            : base(active, reserved, deltaGrow, initialReserved)
        {
            // LTN - ImageManager
            pImageCompare = new Image();
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(instance == null);
            Debug.Assert(active != null);
            Debug.Assert(reserved != null);
            Debug.Assert(deltaGrow != 0);
            Debug.Assert(instance == null);

            if(instance == null)
            {
                // LTN - ImageManager
                instance = new ImageManager(active, reserved, deltaGrow, initialReserved);
            }

            Texture pNullTexture = TextureManager.Find(Texture.Name.NullTexture);
            Debug.Assert(pNullTexture != null);

            Image pNullImage = ImageManager.Add(Image.Name.NullImage, pNullTexture, 0, 0, 128, 128);
            Debug.Assert(pNullImage != null);
        }

        public static Image Add(Image.Name name, Texture texture, float x, float y, float width, float height)
        {
            Debug.Assert(texture != null);

            ImageManager inst = GetInstance();
            Debug.Assert(inst != null);

            Image pImage = (Image)inst.BaseAdd();
            Debug.Assert(pImage != null);

            pImage.Set(name, texture, x, y, width, height);

            return pImage;
        }

        public static Image Remove(Image pImage)
        {
            ImageManager inst = ImageManager.GetInstance();
            Debug.Assert(inst != null);

            return (Image)inst.BaseRemove(pImage);
        }

        public static Image Find(Image.Name name)
        {
            ImageManager inst = ImageManager.GetInstance();
            Debug.Assert(inst != null);

            inst.pImageCompare.ImageName = name;

            return (Image)inst.BaseFind(inst.pImageCompare);
        }

        private static ImageManager GetInstance()
        {
            return instance;
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - ImageManager
            return new Image();
        }

        public static void DumpStats()
        {
            ImageManager inst = ImageManager.GetInstance();
            Debug.Assert(inst != null);

            Debug.WriteLine("ImageManager - ");
            inst.BaseDumpStats();
        }
    }
}
