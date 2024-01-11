using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Simulation
    {

        private static Simulation instance = null;

        private State SimState;
        private float StopWatch_tic;
        private float StopWatch_toc;
        private float WatchTotal;
        private float TimeStep;

        private const int SIM_NUM_WAKE_CYCLES = 0;
        private const float SIM_SINGLE_TIME_STEP = 0.016666f;

        private static bool OldKey = false;

        public enum State
        {
            Realtime,
            FixedStep,
            SingleStep,
            Pause
        }

        private Simulation()
        {
            this.SimState = State.Realtime;

            this.TimeStep = 0.0f;
            this.WatchTotal = 0.0f;
            this.StopWatch_tic = 0.0f;
            this.StopWatch_toc = 0.0f;
        }

        public static void Create()
        {
            Debug.Assert(instance == null);
            if(instance == null)
            {
                instance = new Simulation();
            }
        }


        public static void Update(float systemTime)
        {
            Simulation inst = Simulation.GetInstance();

            inst.ProcessInput();

            // Get the time that has passed
            inst.StopWatch_toc = systemTime - inst.StopWatch_tic;
            inst.StopWatch_tic = systemTime;

            if(inst.GetState() == State.FixedStep)
            {
                inst.TimeStep = SIM_SINGLE_TIME_STEP;
            }
            else if(inst.GetState() == State.Realtime)
            {
                inst.TimeStep = inst.StopWatch_toc;
            }
            else if(inst.GetState() == State.SingleStep)
            {
                inst.TimeStep = SIM_SINGLE_TIME_STEP;
                inst.SimState = State.Pause;
            }
            else
            {
                inst.TimeStep = 0.0f;
            }

            inst.WatchTotal += inst.TimeStep;
        }

        // --- Simulation controls ------------
        //   1 - single step
        //   2 - repeat step while holding
        //   3 - start simulation fixed step
        //   4 - start simulation realtime stepping
        private void ProcessInput()
        {
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_3) == true)
            {
                this.SimState = State.FixedStep;
            }
            else if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_4) == true)
            {
                this.SimState = State.Realtime;
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true && OldKey == false)
            {
                this.SimState = State.SingleStep;
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2) == true)
            {
                this.SimState = State.SingleStep;
            }

            OldKey = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1);
        }

        public static float GetTimeStep()
        {
            Simulation inst = Simulation.GetInstance();

            return inst.TimeStep;
        }

        public static float GetTotalTime()
        {
            Simulation inst = Simulation.GetInstance();

            return inst.WatchTotal;
        }

        public Simulation.State GetState()
        {
            return this.SimState;
        }

        private static Simulation GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }
    }
}
