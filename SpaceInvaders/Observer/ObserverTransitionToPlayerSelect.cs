using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverTransitionToPlayerSelect : Observer
    {
        public override void Notify()
        {
            SpriteBatch pTextBatch = SpriteBatchManager.Find(SpriteBatch.Name.Text);
            SpriteBatch pSpriteBatch = SpriteBatchManager.Find(SpriteBatch.Name.Aliens);

            TimerManager.Clear();
            FontManager.Clear();
            pTextBatch.Clear();
            pSpriteBatch.Clear();

            FontManager.LoadScreenFont(pSpriteBatch, FontManager.ScreenFont.Select);
            FontManager.LoadScreenFont(pSpriteBatch, FontManager.ScreenFont.GamePlay);
        }
    }
}
