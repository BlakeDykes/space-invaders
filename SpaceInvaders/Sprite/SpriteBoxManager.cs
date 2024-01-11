using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBoxManager : ManagerBase
    {
        private static SpriteBoxManager instance = null;
        public static Azul.Color DefaultSpriteBoxColor;
        public static Azul.Color ClearSpriteBoxColor;
        private SpriteBox pCompSpriteBox;

        private SpriteBoxManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        : base(active, reserved, deltaGrow, initialReserved)
        {
            // LTN - SpriteBoxManager
            this.pCompSpriteBox = new SpriteBox();

            // LTN - SpriteBoxManager
            DefaultSpriteBoxColor = new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f);
            ClearSpriteBoxColor = new Azul.Color(0.0f, 0.0f, 0.0f, 0.0f);
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(instance == null);

            if(instance == null)
            {
                // LTN - the process
                instance = new SpriteBoxManager(active, reserved, deltaGrow, initialReserved);

                // Create collision box
                Add(SpriteBox.Name.ColBox, new Azul.Color(1.0f, 0.0f, 0.0f));
            }
        }

        private static SpriteBoxManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        public static SpriteBox Add(SpriteBox.Name _name, Azul.Color _color, float _x, float _y, float _width, float _height,
                        float _sx = 1.0f, float _sy = 1.0f, float _angle = 0.0f)
        {
            SpriteBoxManager inst = GetInstance();
            SpriteBox pSB = (SpriteBox)inst.BaseAdd();
            pSB.Set(_name, _color, _x, _y, _width, _height, _sx, _sy, _angle);
            Debug.Assert(pSB != null);
            return pSB;
        }

        public static SpriteBox Add(SpriteBox.Name _name, Azul.Color _color)
        {
            SpriteBoxManager inst = GetInstance();
            SpriteBox pSB = (SpriteBox)inst.BaseAdd();
            pSB.Set(_name, _color, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 0.0f);
            Debug.Assert(pSB != null);
            return pSB;
        }
        public static SpriteBox Remove(SpriteBox.Name name)
        {
            SpriteBoxManager inst = GetInstance();
            Debug.Assert(inst != null);

            SpriteBox pRem = Find(name);

            return (SpriteBox)inst.BaseRemove(pRem);
        }

        public static SpriteBox Find(SpriteBox.Name name)
        {
            SpriteBoxManager inst = GetInstance();
            Debug.Assert(inst != null);

            inst.pCompSpriteBox.SpriteName = name;

            return (SpriteBox)inst.BaseFind(inst.pCompSpriteBox);
        }
        protected override NodeBase DerivedCreateNode()
        {
            // LTN - SpriteBoxManager
            return new SpriteBox();
        }

        private IteratorBase GetIterator()
        {
            SpriteBoxManager inst = GetInstance();
            Debug.Assert(inst != null);

            return inst.poActive.GetIterator();
        }

        public static void DumpStats()
        {
            SpriteBoxManager inst = GetInstance();
            Debug.Assert(inst != null);

            Debug.WriteLine("SpriteBoxManager - ");
            inst.BaseDumpStats();
        }
    }
}
