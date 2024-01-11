using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteFont : SpriteBase
    {

        public Font.Name FontName;
        private Azul.Sprite poSprite;
        private Azul.Rect poRect;
        private Azul.Color poColor;

        private string pMessage;
        public Glyph.Name GlyphName;

        public float x;
        public float y;


        public SpriteFont()
        {
            this.poSprite = new Azul.Sprite();
            this.poRect = new Azul.Rect();
            this.poColor = Constants.DEFAULT_SPRITE_COLOR;
            this.pMessage = null;
            this.GlyphName = Glyph.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
        }

        public void Set(Font.Name name, string pMessage, Glyph.Name glyphName, float xStart, float yStart, Azul.Color color)
        {
            this.FontName = name;
            this.pMessage = pMessage;
            this.GlyphName = glyphName;
            this.x = xStart;
            this.y = yStart;
            this.poColor = color;
        }
        
        public void SetColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.poColor != null);
            this.poColor.Set(red, green, blue, alpha);
        }

        public override void Render()
        {
            Debug.Assert(this.poSprite != null);
            Debug.Assert(this.poColor != null);
            Debug.Assert(this.poRect != null);
            Debug.Assert(this.pMessage != null);
            Debug.Assert(this.pMessage.Length > 0);

            float xTemp = this.x;
            float yTemp = this.y;

            float xEnd = this.x;

            for(int i = 0; i < this.pMessage.Length; i++)
            {
                int key = Convert.ToByte(pMessage[i]);

                Glyph pGlyph = GlyphManager.Find(this.GlyphName, key);
                Debug.Assert(pGlyph != null);

                xTemp = xEnd + pGlyph.GetRect().width * 0.5f;
                this.poRect.Set(xTemp, yTemp, pGlyph.GetRect().width, pGlyph.GetRect().height);

                this.poSprite.Swap(pGlyph.GetTexture(), pGlyph.GetRect(), this.poRect, this.poColor);

                this.poSprite.Update();
                this.poSprite.Render();

                xEnd = pGlyph.GetRect().width * 0.5f + xTemp + 10.0f;
            }

        }

        public override void Update()
        {
            Debug.Assert(this.poSprite != null);
        }

        public void UpdateMessage(String pMessage)
        {
            Debug.Assert(pMessage != null);
            this.pMessage = pMessage;
        }

        public override void Wash()
        {
            throw new NotImplementedException();
        }

        public override bool Compare(NodeBase pNode)
        {
            Debug.Assert(pNode != null);

            SpriteFont pComp = (SpriteFont)pNode;

            return this.FontName == pComp.FontName;
        }
    }
}
