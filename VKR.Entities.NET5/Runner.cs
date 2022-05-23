namespace Entities.NET5
{
    public class Runner
    {
        public int RunnerId;
        public string RunnerPosition;
        public int PitcherId;
        public bool IsBaseNotEmpty;
        public bool IsBaseStealingAttempt;

        public Runner()
        {
            RunnerId = 0;
            RunnerPosition = "";
            PitcherId = 0;
            IsBaseNotEmpty = false;
        }

        public Runner(Runner runnerOnFirst)
        {
            if (runnerOnFirst.IsBaseNotEmpty)
            {
                RunnerId = runnerOnFirst.RunnerId;
                RunnerPosition = runnerOnFirst.RunnerPosition;
                PitcherId = runnerOnFirst.PitcherId;
                IsBaseNotEmpty = true;
            }
            else
            {
                RunnerId = 0;
                RunnerPosition = "";
                PitcherId = 0;
                IsBaseNotEmpty = false;
            }
            IsBaseStealingAttempt = false;
        }

        public Runner(Batter batter, Pitcher pitcher)
        {
            RunnerId = batter.Id;
            RunnerPosition = batter.PositionForThisMatch;
            PitcherId = pitcher.Id;
            IsBaseNotEmpty = true;
        }
    }
}