using System;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.ViewModels
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
                if (!IsPlayed)
                    return "Scheduled";

                if (!IsEnded)
                    return $"{OrdinalNumerals.GetOrdinalNumeralFromQuantitative(CurrentInning)} inning";

                return CurrentInning != 9 ? $"Final/{CurrentInning}" : "Final";
            }
        }
    }
}