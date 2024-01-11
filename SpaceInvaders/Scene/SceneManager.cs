using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneManager : Subject
    {
        private static SceneManager instance = null;

        SceneState pSceneState;
        SceneStateGameOver pGameOverState;
        SceneStatePlay pPlayState;
        SceneStateSelect pSelectState;

        SceneState.StateName CurrentState;

        private SceneManager()
        {
            this.CurrentState = SceneState.StateName.Select;
        }

        public static void Create()
        {
            Debug.Assert(instance == null);

            if(instance == null)
            {
                instance = new SceneManager();

                instance.pSelectState = new SceneStateSelect();
                instance.pPlayState = new SceneStatePlay();
                instance.pGameOverState = new SceneStateGameOver();

                instance.pSceneState = instance.pSelectState;
                instance.pSceneState.Transition(0.0f);
            }
        }

        public static SceneState.StateName GetStateName()
        {
            SceneManager inst = SceneManager.GetInstance();
            
            return inst.CurrentState;
        }

        public static void SetStateName(SceneState.StateName name)
        {
            SceneManager inst = SceneManager.GetInstance();

            inst.CurrentState = name;
        }

        public static SceneState GetState()
        {
            SceneManager inst = SceneManager.GetInstance();

            return inst.pSceneState;
        }

        public static void SetState(SceneState.StateName inScene, float systemTime)
        {
            SceneManager inst = SceneManager.GetInstance();

            switch (inScene)
            {
                case SceneState.StateName.Select:
                    inst.pSceneState = inst.pSelectState;
                    inst.CurrentState = SceneState.StateName.Select;
                    inst.pSceneState.Transition(systemTime);
                    break;
                case SceneState.StateName.Play:
                    if (SceneManager.GetStateName() != SceneState.StateName.Play)
                    {
                        inst.pSceneState = inst.pPlayState;
                        inst.CurrentState = SceneState.StateName.Play;
                        inst.pSceneState.Transition(systemTime);
                    }
                    break;
                case SceneState.StateName.GameOver:
                    inst.pSceneState = inst.pGameOverState;
                    inst.CurrentState = SceneState.StateName.GameOver;
                    inst.pSceneState.Transition(systemTime);
                    break;
            }
        }

        private static SceneManager GetInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static void ResetLevel()
        {
            SceneManager inst = SceneManager.GetInstance();

            inst.pPlayState.Level = 0;
        }

        public static int GetLevel()
        {
            SceneManager inst = SceneManager.GetInstance();

            return inst.pPlayState.Level;
        }

        public static void AdvanceLevel(float systemTime)
        {
            SceneManager inst = SceneManager.GetInstance();

            inst.pSceneState.Transition(systemTime);
        }
    }
}
