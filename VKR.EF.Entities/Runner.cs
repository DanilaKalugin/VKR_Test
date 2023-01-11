using VKR.EF.Entities.ViewModels;

namespace VKR.EF.Entities
{
    public class Runner
    {
        public uint RunnerId;
        public string RunnerPosition;
        public uint PitcherId;
        public bool IsBaseNotEmpty => RunnerId > 0 && PitcherId > 0;
        public bool IsBaseStealingAttempt;
        public bool IsEarnedRun;

        public Runner()
        {
            RunnerId = 0;
            RunnerPosition = "";
            PitcherId = 0;
        }

        public Runner(Runner runnerOnFirst)
        {
            if (runnerOnFirst.IsBaseNotEmpty)
            {
                RunnerId = runnerOnFirst.RunnerId;
                RunnerPosition = runnerOnFirst.RunnerPosition;
                PitcherId = runnerOnFirst.PitcherId;
            }
            else
            {
                RunnerId = 0;
                RunnerPosition = "";
                PitcherId = 0;
            }
            IsBaseStealingAttempt = false;
            IsEarnedRun = runnerOnFirst.IsEarnedRun;
        }

        public Runner(Batter batter, Pitcher pitcher, bool isEarned)
        {
            RunnerId = batter.BatterId;
            RunnerPosition = batter.PositionForThisMatch;
            PitcherId = pitcher.PitcherId;
            IsEarnedRun = isEarned;
        }
    }
}