using VKR.EF.Entities.ViewModels;

namespace VKR.EF.Entities
{
    public class Runner
    {
        public uint RunnerId;
        public string RunnerPosition;
        public uint PitcherId;
        public string RunnerName;
        public uint RunnerPhotoId;
        public bool IsBaseNotEmpty => RunnerId > 0 && PitcherId > 0;
        public bool IsBaseStealingAttempt;
        public bool IsEarnedRun;

        public Runner()
        {
            RunnerId = 0;
            RunnerPosition = "";
            PitcherId = 0;
            RunnerName = "";
            RunnerPhotoId = 0;
        }

        public Runner(Runner runnerOnFirst)
        {
            if (runnerOnFirst.IsBaseNotEmpty)
            {
                RunnerId = runnerOnFirst.RunnerId;
                RunnerPosition = runnerOnFirst.RunnerPosition;
                PitcherId = runnerOnFirst.PitcherId;
                RunnerName = runnerOnFirst.RunnerName;
                RunnerPhotoId = runnerOnFirst.RunnerPhotoId;
            }
            else
            {
                RunnerId = 0;
                RunnerPosition = "";
                PitcherId = 0;
                RunnerPhotoId = 0;
                RunnerName = "";
            }
            IsBaseStealingAttempt = false;
            IsEarnedRun = runnerOnFirst.IsEarnedRun;
        }

        public Runner(Batter batter, Pitcher pitcher, bool isEarned)
        {
            RunnerId = batter.BatterId;
            RunnerPosition = batter.PositionForThisMatch;
            PitcherId = pitcher.PitcherId;
            RunnerName = batter.FullName;
            RunnerPhotoId = batter.Id;
            IsEarnedRun = isEarned;
        }
    }
}