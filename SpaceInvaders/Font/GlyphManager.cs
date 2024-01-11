using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GlyphManager : ManagerBase
    {
        private static GlyphManager instance = null;
        private readonly Glyph poNodeCompare;

        private GlyphManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
           : base(active, reserved, deltaGrow, initialReserved)
        {
            poNodeCompare = new Glyph();

            SpriteBoxManager.Add(SpriteBox.Name.Text, Constants.DEFAULT_SPRITE_COLOR);
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(instance == null);

            if (instance == null)
            {
                instance = new GlyphManager(active, reserved, deltaGrow, initialReserved);
            }
        }

        public static Glyph Add(Glyph.Name glyphName, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            GlyphManager inst = GlyphManager.GetInstance();

            Glyph pGlyph = (Glyph)inst.BaseAdd();

            pGlyph.Set(glyphName, key, textName, x, y, width, height);

            return pGlyph;
        }

        public static void AddXml(Glyph.Name glyphName, string assetName, Texture.Name textName)
        {
            int key = 0;
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;

            XmlDocument GlyphXML = new XmlDocument();

            try { GlyphXML.Load(assetName); }
            catch (System.IO.FileNotFoundException)
            {
                Debug.WriteLine("Glyph file not found");
            }

            XmlNode pCur = GlyphXML.DocumentElement.FirstChild;
            while (pCur != null)
            {
                key = Convert.ToInt32(pCur.Attributes["key"].InnerText);
                x = Convert.ToInt32(pCur["x"].InnerText);
                y = Convert.ToInt32(pCur["y"].InnerText);
                width = Convert.ToInt32(pCur["width"].InnerText);
                height = Convert.ToInt32(pCur["height"].InnerText);

                GlyphManager.Add(glyphName, key, textName, x, y, width, height);

                pCur = pCur.NextSibling;
            }
        }

        public static Glyph Find(Glyph.Name name, int key)
        {
            Debug.Assert(name != Glyph.Name.Uninitialized);
            Debug.Assert(key >= 0);

            GlyphManager inst = GlyphManager.GetInstance();

            inst.poNodeCompare.GlyphName = name;
            inst.poNodeCompare.Key = key;

            return (Glyph)inst.BaseFind(inst.poNodeCompare);
        }

        public static void Remove(Glyph pGlyph)
        {
            Debug.Assert(pGlyph != null);
            GlyphManager inst = GlyphManager.GetInstance();

            inst.BaseRemove(pGlyph);

        }

        private static GlyphManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        protected override NodeBase DerivedCreateNode()
        {
            return new Glyph();
        }
    }
}
