using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputManager
    {
        private static InputManager instance = null;

        private InputSubject poSubjectArrowLeft;
        private InputSubject poSubjectArrowRight;
        private InputSubject poSubjectSpace;
        private InputSubject poSubjectEnter;

        private InputState poHeadState;
        private InputState poState;

        private bool LastSpacePress;

        private InputManager()
        {
            this.poSubjectArrowLeft = new InputSubject();
            this.poSubjectArrowRight = new InputSubject();
            this.poSubjectSpace = new InputSubject();
            this.poSubjectEnter = new InputSubject();

            this.LastSpacePress = false;
        }

        public static void Create()
        {
            Debug.Assert(instance == null);

            if(instance == null)
            {
                instance = new InputManager();

                instance.AttachState(InputState.State.Select);
                instance.AttachState(InputState.State.Play);
                instance.AttachState(InputState.State.GameOver);
            }
        }

        public static void Update()
        {
            InputManager inst = InputManager.GetInstance();

            if(Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true || Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_A) == true)
            {
                inst.NotifyLeftArrow();
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true || Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_D) == true)
            {
                inst.NotifyRightArrow();
            }
            bool curSpace = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
            if (curSpace == true && inst.LastSpacePress == false)
            {
                 inst.NotifyShoot();
            }
            if(Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_O) != false)
            {
                inst.NotifyEnter();
            }
            
            inst.LastSpacePress = curSpace;
        }

        public void AttachState(InputState.State inState)
        {
            InputManager inst = InputManager.GetInstance();

            if (InputManager.GetState(inState) == null)
            {
                InputState pState = InputStateFactory.CreateState(inState);
                pState.pNext = inst.poHeadState;
                inst.poHeadState = pState;
            }
        }

        public static InputState GetState(InputState.State inState)
        {
            InputManager inst = InputManager.GetInstance();

            InputState pState = inst.poHeadState;

            while(pState != null && pState.StateName != inState)
            {
                pState = (InputState)pState.pNext;
            }

            return pState;
        }

        public static void SetState(InputState.State inState)
        {
            InputManager inst = InputManager.GetInstance();

            inst.poState = inst.poHeadState;

            while (inst.poState != null && inst.poState.StateName != inState)
            {
                inst.poState = (InputState)inst.poState.pNext;
            }

            if(inst.poState == null)
            {
                inst.AttachState(inState);
                inst.poState = inst.poHeadState;
            }
        }


        public static InputSubject GetSubjectArrowRight()
        {
            InputManager inst = InputManager.GetInstance();
            return inst.poSubjectArrowRight;
        }

        public static InputSubject GetSubjectArrowLeft()
        {
            InputManager inst = InputManager.GetInstance();
            return inst.poSubjectArrowLeft;
        }

        public static InputSubject GetSubjectSpace()
        {
            InputManager inst = InputManager.GetInstance();
            return inst.poSubjectSpace;
        }

        public static InputSubject GetSubjectEnter()
        {
            InputManager inst = InputManager.GetInstance();
            return inst.poSubjectEnter;
        }

        public void NotifyRightArrow()
        {
            InputManager inst = InputManager.GetInstance();

            inst.poState.NotifyRight(inst.poSubjectArrowRight);
        }

        public void NotifyLeftArrow()
        {
            InputManager inst = InputManager.GetInstance();

            inst.poState.NotifyLeft(inst.poSubjectArrowLeft);
        }

        public void NotifyShoot()
        {
            InputManager inst = InputManager.GetInstance();

            inst.poState.NotifyShoot(inst.poSubjectSpace);
        }

        public void NotifyEnter()
        {
            InputManager inst = InputManager.GetInstance();
            inst.poState.NotifyEnter(inst.poSubjectEnter);
        }

        private static InputManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }
    }
}
