using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Glyph : DLink
    {

        public Glyph.Name GlyphName;
        public int Key;
        private Azul.Rect poRect;
        private Texture pTexture;

        public enum Name
        {
            Consolas36pt,

            Null_Object,
            Uninitialized
        }


        public Glyph()
        {
            this.GlyphName = Name.Uninitialized;
            this.Key = 0;
            this.poRect = new Azul.Rect();
            this.pTexture = null;
        }

        public void Set(Glyph.Name glyphName, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            this.GlyphName = glyphName;
            this.Key = key;
            this.pTexture = TextureManager.Find(textName);

            this.poRect.Set(x, y, width, height);
        }

        public override bool Compare(NodeBase pNode)
        {
            Glyph pComp = (Glyph)pNode;
            if(this.GlyphName == pComp.GlyphName && this.Key == pComp.Key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Azul.Rect GetRect()
        {
            return this.poRect;
        }

        public Azul.Texture GetTexture()
        {
            return this.pTexture.poAzulTexture;
        }

        public override void Wash()
        {
            this.PrivClear();
        }

        private void PrivClear()
        {
            this.GlyphName = Name.Uninitialized;
            this.pTexture = null;
            this.poRect.Set(0.0f, 0.0f, 0.0f, 0.0f);
            this.Key = 0;
        }
    }
}
