using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneStateGameOver : SceneState
    {
        TimerManager poTimerManager;

        public SceneStateGameOver()
        {
            this.mStateName = StateName.GameOver;
        }
        public override void Draw()
        {
            SpriteBatchManager.RenderAll();
        }
        public override void Initialize(float systemTime)
        {
            SceneManager.ResetLevel();
            this.poTimerManager = new TimerManager(new DLinkManager(), new DLinkManager(), 5, 10, 0.0f);
            TimerManager.SetActive(this.poTimerManager, systemTime);

            TimerManager.Add(TimerEvent.Name.TransitionToSelect, 5.0f, new CommandTransitionToSelect());

            SpriteBatch textBatch = SpriteBatchManager.Find(SpriteBatch.Name.Text);
            FontManager.LoadScreenFont(textBatch, FontManager.ScreenFont.GameOver);
        }
        public override void Transition(float systemTime)
        {
            this.Initialize(systemTime);
            InputManager.SetState(InputState.State.GameOver);
        }
        public override void Update(float systemTime)
        {
            Simulation.Update(systemTime);

            if (Simulation.GetTimeStep() > 0.0f)
            {
                TimerManager.Update(Simulation.GetTotalTime());

                GameObjectNodeManager.UpdateAll();

                ColPairManager.Update();

                DelayedEventManager.Process();
            }
        }
     }
}
