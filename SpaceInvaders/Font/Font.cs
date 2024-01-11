using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Font : DLink
    {
        public Font.Name FontName;
        public SpriteFont poSpriteFont;

        public enum Name
        {
            Gameplay_Top,
            Gameplay_Score_1,
            Gameplay_Hi_Score,
            Gameplay_Score_2,
            GamePlay_Credits,
            Select_Play,
            Select_Title,
            Select_ScoreBreakdown_Title,
            Select_ScoreBreakdown_UFO,
            Select_ScoreBreakdown_Squid,
            Select_ScoreBreakdown_Crab,
            Select_ScoreBreakdown_Octo,
            Select_Coin_Title,
            Select_Coin_1_or_2,
            Select_Coin_1,
            Select_Coin_2,
            Game_Over,
            

            NullObject,
            Uninitialized
        }

        public Font()
        {
            this.FontName = Name.Uninitialized;
            this.poSpriteFont = new SpriteFont();
        }

        public void Set(Font.Name name, string pMessage, Glyph.Name glyphName, float xStart, float yStart, Azul.Color color)
        {
            Debug.Assert(pMessage != null);

            this.FontName = name;
            this.poSpriteFont.Set(name, pMessage, glyphName, xStart, yStart, color);
        }

        public void UpdateMessage(string pMessage)
        {
            Debug.Assert(pMessage != null);
            Debug.Assert(this.poSpriteFont != null);
            this.poSpriteFont.UpdateMessage(pMessage);
        }

        public override bool Compare(NodeBase pNode)
        {
            Font pComp = (Font)pNode;

            return this.FontName == pComp.FontName;
        }
    }
}
