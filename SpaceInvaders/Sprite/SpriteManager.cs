using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteManager : ManagerBase
    {
        private static SpriteManager instance = null;
        private Sprite pCompSprite;

        private SpriteManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        : base(active, reserved, deltaGrow, initialReserved)
        {
            // LTN - SpriteManager
            pCompSprite = new Sprite();
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(active != null);
            Debug.Assert(reserved != null);
            Debug.Assert(deltaGrow != 0);

            Debug.Assert(instance == null);

            if(instance == null)
            {
                // LTN - the process
                instance = new SpriteManager(active, reserved, deltaGrow, initialReserved);
            }

            Image pImage = ImageManager.Find(Image.Name.NullImage);
            Add(Sprite.Name.NullProxy, pImage, Constants.DEFAULT_SPRITE_COLOR, 0.0f, 0.0f);
        }

        public static Sprite Add(Sprite.Name _name, Image _image, Azul.Color _color, float _x, float _y, float _width, float _height,
                                    float _sx = 1.0f, float _sy = 1.0f, float _angle = 0.0f)
        {
            SpriteManager inst = SpriteManager.GetInstance();
            Debug.Assert(inst != null);

            Sprite pNew = (Sprite)inst.BaseAdd();
            Debug.Assert(pNew != null);

            pNew.Set(_name, _image, _color, _x, _y, _width, _height, _sx, _sy, _angle);

            return pNew;
        }

        public static Sprite Add(Sprite.Name _name, Image _image, Azul.Color _color, float _width, float _height)
        {
            SpriteManager inst = SpriteManager.GetInstance();
            Debug.Assert(inst != null);

            Sprite pNew = (Sprite)inst.BaseAdd();
            Debug.Assert(pNew != null);

            pNew.Set(_name, _image, _color, _width, _height);

            return pNew;
        }

        public static Sprite Find(Sprite.Name name)
        {
            SpriteManager inst = SpriteManager.GetInstance();
            Debug.Assert(inst != null);

            inst.pCompSprite.SpriteName = name;

            return (Sprite)inst.BaseFind(inst.pCompSprite);
        }

        public static Sprite Remove(Sprite pSprite)
        {
            SpriteManager inst = SpriteManager.GetInstance();
            Debug.Assert(inst != null);

            return (Sprite)inst.BaseRemove(pSprite);
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - SpriteManager
            return new Sprite();
        }

        private static SpriteManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        public static IteratorBase GetIterator()
        {
            SpriteManager inst = SpriteManager.GetInstance();
            Debug.Assert(instance != null);

            return inst.poActive.GetIterator();
        }

        public static void DumpStats()
        {
            SpriteManager inst = SpriteManager.GetInstance();
            Debug.Assert(inst != null);

            Debug.WriteLine("SpriteManager - ");
            inst.BaseDumpStats();
        }
    }
}
