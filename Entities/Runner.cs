namespace Entities
{
    public class Runner
    {
        public int RunnerID;
        public string RunnerPosition;
        public int PitcherID;
        public bool IsBaseNotEmpty;
        public bool IsBaseStealingAttempt;

        public Runner()
        {
            RunnerID = 0;
            RunnerPosition = "";
            PitcherID = 0;
            IsBaseNotEmpty = false;
        }

        public Runner(Runner runnerOnFirst)
        {
            if (runnerOnFirst.IsBaseNotEmpty)
            {
                RunnerID = runnerOnFirst.RunnerID;
                RunnerPosition = runnerOnFirst.RunnerPosition;
                PitcherID = runnerOnFirst.PitcherID;
                IsBaseNotEmpty = true;
            }
            else
            {
                RunnerID = 0;
                RunnerPosition = "";
                PitcherID = 0;
                IsBaseNotEmpty = false;
            }
            IsBaseStealingAttempt = false;
        }

        public Runner(Batter batter, Pitcher pitcher)
        {
            RunnerID = batter.Id;
            RunnerPosition = batter.PositionForThisMatch;
            PitcherID = pitcher.Id;
            IsBaseNotEmpty = true;
        }
    }
}