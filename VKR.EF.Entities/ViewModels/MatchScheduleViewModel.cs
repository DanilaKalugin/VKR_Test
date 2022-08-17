using System;

namespace VKR.EF.Entities
{
    public class MatchScheduleViewModel : MatchBaseClass
    {
        public bool IsPlayed;
        public int AwayTeamRuns;
        public int HomeTeamRuns;
        public int CurrentInning;
        public bool IsEnded;
        public string StadiumName;
        public string StadiumLocation;

        public MatchScheduleViewModel(bool isPlayed, bool isEnded, string awayTeamAbbreviation,
            string homeTeamAbbreviation, int currentInning, int awayTeamRuns,
            int homeTeamRuns, Stadium stadium, DateTime matchDate)
        {
            IsPlayed = isPlayed;
            IsEnded = isEnded;
            CurrentInning = currentInning;
            AwayTeamRuns = awayTeamRuns;
            HomeTeamRuns = homeTeamRuns;
            AwayTeamAbbreviation = awayTeamAbbreviation;
            HomeTeamAbbreviation = homeTeamAbbreviation;
            StadiumName = stadium.StadiumTitle;
            StadiumLocation = stadium.StadiumCity.CityLocation;
            MatchDate = matchDate;
        }

        public string MatchStatus
        {
            get
            {
                if (!IsEnded)
                    return $"{OrdinalNumerals.GetOrdinalNumeralFromQuantitive(CurrentInning)} inning";

                if (CurrentInning != 9)
                    return CurrentInning == 0 ? "" : $"Final/{CurrentInning}";

                return "Final";
            }
        }
    }
}