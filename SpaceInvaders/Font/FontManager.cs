using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FontManager : ManagerBase
    {
        private static FontManager instance = null;
        private Font pCompFont;

        public enum ScreenFont
        {
            Attract,
            Select,
            GamePlay,
            GameOver
        }

        public FontManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved) 
            : base(active, reserved, deltaGrow, initialReserved)
        {
            pCompFont = new Font();
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved)
        {
            Debug.Assert(instance == null);

            if (instance == null)
            {
                instance = new FontManager(active, reserved, deltaGrow, initialReserved);
            }
        }

        public static Font Add(Font.Name name, Glyph.Name glyphName, SpriteBatch.Name batchName, string pMessage, float xStart, float yStart, Azul.Color color)
        {
            FontManager inst = FontManager.GetInstance();

            Font pFont = (Font)inst.BaseAdd();

            pFont.Set(name, pMessage, glyphName, xStart, yStart, color);

            SpriteBatch pSpriteBatch = SpriteBatchManager.Find(batchName);
            pSpriteBatch.Attach(name);

            return pFont;
        }

        public static Font Add(Font.Name name, Glyph.Name glyphName, SpriteBatch spriteBatch, string pMessage, float xStart, float yStart, Azul.Color color)
        {
            FontManager inst = FontManager.GetInstance();

            Font pFont = (Font)inst.BaseAdd();

            pFont.Set(name, pMessage, glyphName, xStart, yStart, color);

            spriteBatch.Attach(name);

            return pFont;
        }

        public static Font Find(Font.Name name)
        {
            FontManager inst = FontManager.GetInstance();

            inst.pCompFont.FontName = name;

            return (Font)inst.BaseFind(inst.pCompFont);
        }

        public static SpriteFont FindSpriteFont(Font.Name name)
        {
            FontManager inst = FontManager.GetInstance();

            inst.pCompFont.FontName = name;

            Font pFont = (Font)inst.BaseFind(inst.pCompFont);

            return pFont.poSpriteFont;
        }

        public static void LoadScreenFont(SpriteBatch pSpriteBatch, FontManager.ScreenFont screenFont)
        {
            FontManager inst = FontManager.GetInstance();

            switch (screenFont)
            {
                case FontManager.ScreenFont.Attract:
                    inst.GenerateAttractFont(pSpriteBatch);
                    break;
                case FontManager.ScreenFont.GamePlay:
                    inst.GenerateGameplayFont(pSpriteBatch);
                    break;
                case FontManager.ScreenFont.Select:
                    inst.GenerateSelectFont(pSpriteBatch);
                    break;
                case FontManager.ScreenFont.GameOver:
                    inst.GenerateGameOverFont(pSpriteBatch);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }


        private void GenerateAttractFont(SpriteBatch pSpriteBatch)
        {
            // Reset player scores
            ScoreManager.ResetScore(Score.Name.Player1);

            FontManager.Add(Font.Name.Select_Play, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_PLAY, Constants.SELECT_PLAY_X, Constants.SELECT_PLAY_Y, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Select_Title, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_TITLE, Constants.SELECT_PLAY_X - 155.0f, Constants.SELECT_PLAY_Y - 100.0f, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Select_ScoreBreakdown_Title, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_SCOREBREAKDOWN_TITLE, Constants.SELECT_PLAY_X - 250.0f, Constants.SELECT_PLAY_Y - 230.0f, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Select_ScoreBreakdown_UFO, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_SCOREBREAKDOWN_UFO, Constants.SELECT_PLAY_X - 60.0f, Constants.SELECT_PLAY_Y - 305.0f, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Select_ScoreBreakdown_Squid, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_SCOREBREAKDOWN_SQUID, Constants.SELECT_PLAY_X - 60.0f, Constants.SELECT_PLAY_Y - 370.0f, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Select_ScoreBreakdown_Crab, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_SCOREBREAKDOWN_CRAB, Constants.SELECT_PLAY_X - 60.0f, Constants.SELECT_PLAY_Y - 435.0f, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Select_ScoreBreakdown_Octo, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_SCOREBREAKDOWN_OCTO, Constants.SELECT_PLAY_X - 60.0f, Constants.SELECT_PLAY_Y - 500.0f, Constants.GREEN);
            FontManager.Add(Font.Name.GamePlay_Credits, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.GAMEPLAY_CREDITS, Constants.GAMEPLAY_CREDIT_X, Constants.GAMEPLAY_CREDIT_Y, Constants.DEFAULT_SPRITE_COLOR);

            // Reset player scores
            ScoreManager.SetFont(Score.Name.HiScore, Font.Name.Gameplay_Hi_Score);
            ScoreManager.SetFont(Score.Name.Player1, Font.Name.Gameplay_Score_1);

            ScoreManager.RefreshScore(Score.Name.HiScore);
            ScoreManager.RefreshScore(Score.Name.Player1);
        }

        private void GenerateSelectFont(SpriteBatch pSpriteBatch)
        {
            FontManager.Add(Font.Name.Select_Coin_Title, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_INSERT_COIN, Constants.SELECT_INSERT_TITLE_X, Constants.SELECT_INSERT_TITLE_Y, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Select_Coin_1_or_2, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_1_OR_2_TITLE, Constants.SELECT_INSERT_TITLE_X - 45.0f, Constants.SELECT_INSERT_TITLE_Y - 145.0f, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Select_Coin_1, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_1_PLAYER_COIN, Constants.SELECT_INSERT_TITLE_X - 60.0f, Constants.SELECT_INSERT_TITLE_Y - 225.0f, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Select_Coin_2, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.SELECT_2_PLAYER_COIN, Constants.SELECT_INSERT_TITLE_X - 70.0f, Constants.SELECT_INSERT_TITLE_Y - 305.0f, Constants.GREEN);
        }

        private void GenerateGameplayFont(SpriteBatch pSpriteBatch)
        {
            FontManager.Add(Font.Name.Gameplay_Top, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.GAMEPLAY_TOP, Constants.GAMEPLAY_TOP_TEXT_X, Constants.GAMEPLAY_TOP_TEXT_Y, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Gameplay_Score_1, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.GAMEPLAY_SCORE, Constants.GAMEPLAY_TOP_TEXT_X + 50.0f, Constants.GAMEPLAY_TOP_TEXT_Y - 50.0f, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.Gameplay_Hi_Score, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.GAMEPLAY_SCORE, Constants.GAMEPLAY_TOP_TEXT_X + 340.0f, Constants.GAMEPLAY_TOP_TEXT_Y - 50.0f, Constants.DEFAULT_SPRITE_COLOR);
            FontManager.Add(Font.Name.GamePlay_Credits, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.GAMEPLAY_CREDITS, Constants.GAMEPLAY_CREDIT_X, Constants.GAMEPLAY_CREDIT_Y, Constants.DEFAULT_SPRITE_COLOR);

            // Reset player scores
            ScoreManager.SetFont(Score.Name.HiScore, Font.Name.Gameplay_Hi_Score);
            ScoreManager.SetFont(Score.Name.Player1, Font.Name.Gameplay_Score_1);

            ScoreManager.RefreshScore(Score.Name.HiScore);
            ScoreManager.RefreshScore(Score.Name.Player1);

        }

        private void GenerateGameOverFont(SpriteBatch pSpriteBatch)
        {
            FontManager.Add(Font.Name.Game_Over, Glyph.Name.Consolas36pt, pSpriteBatch, Constants.GAME_OVER_TEXT, Constants.GAME_OVER_TEXT_X, Constants.GAME_OVER_TEXT_Y, Constants.RED);
        }

        public static void Clear()
        {
            FontManager inst = FontManager.GetInstance();
            inst.BaseClear();
        }

        private static FontManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        protected override NodeBase DerivedCreateNode()
        {
            return new Font();
        }
    }
}
