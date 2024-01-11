using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TextureManager : ManagerBase
    {
        private static TextureManager instance = null;
        private Texture pCompTexture; 

        private TextureManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
            :base(active, reserved, deltaGrow, initialReserved)
        {
            // LTN - TextureManager
            pCompTexture = new Texture();
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(instance == null);
            Debug.Assert(active != null);
            Debug.Assert(reserved != null);
            Debug.Assert(deltaGrow != 0);

            if (instance == null)
            {
                // LTN - TextureManager
                instance = new TextureManager(active, reserved, deltaGrow, initialReserved);

                TextureManager.Add(Texture.Name.Aliens, "SpaceInvaders.tga");
                TextureManager.Add(Texture.Name.Consolas, "Consolas36pt.tga");
            }

            // Default Texture
            Texture pDefault = TextureManager.Add(Texture.Name.NullTexture, "HotPink.tga");
            Debug.Assert(pDefault != null);
        }

        public static Texture Add(Texture.Name name, string textureName)
        {
            TextureManager inst = GetInstance();
            Debug.Assert(inst != null);

            Texture pTexture = (Texture)inst.BaseAdd();
            Debug.Assert(pTexture != null);

            pTexture.Set(name, textureName);

            return pTexture;
        }

        public static Texture Find(Texture.Name name)
        {
            TextureManager inst = GetInstance();
            Debug.Assert(instance != null);

            inst.pCompTexture.TextureName = name;

            return (Texture)inst.BaseFind(inst.pCompTexture);
        }

        private static TextureManager GetInstance()
        {
            return instance;
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - TextureManager
            return new Texture();
        }
        public static void DumpStats()
        {
            TextureManager inst = TextureManager.GetInstance();
            Debug.Assert(inst != null);

            Debug.WriteLine("TextureManager - ");
            inst.BaseDumpStats();
        }
    }
}
