using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class FallStrategyFactory
    {
        public static FallStrategy CreateStrategy(FallStrategy.Name name)
        {
            switch (name)
            {
                case (FallStrategy.Name.Straight):
                    return new FallStraight();
                case (FallStrategy.Name.Dagger):
                    return new FallDagger();
                case (FallStrategy.Name.ZigZag):
                    return new FallZigZag();
                default:
                    Debug.Assert(false);
                    return null;
            }
        }
    }
}
