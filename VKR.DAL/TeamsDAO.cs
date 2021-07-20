using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Entities;
using System.Drawing;
using System.Linq;

namespace VKR.DAL
{
    public class TeamsDAO : DAO
    {
        public TeamsDAO()
        {
            InitConnection();
        }

        public IEnumerable<Team> GetStandings(DateTime date)
        {
            List<Team> teams = new List<Team>();
            using (SqlCommand command = new SqlCommand("GetStandings", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Date", SqlDbType.Date);
                command.Prepare();
                command.Parameters[0].Value = date;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Abbreviation = (string)reader["TeamAbbreviation"];
                        string Name = (string)reader["TeamName"];
                        string League = (string)reader["LeagueID"];
                        int W = (int)reader["W"];
                        int L = (int)reader["L"];
                        string Division = (string)reader["DivisionTitle"];
                        int HW = (int)reader["HW"];
                        int HL = (int)reader["HL"];
                        int AW = (int)reader["AW"];
                        int AL = (int)reader["AL"];
                        teams.Add(new Team(Abbreviation, Name, W, L, League, Division, HW, HL, AW, AL));
                    }
                }
            }
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].TeamColor = GetAllColorsForThisTeam(teams[i].TeamAbbreviation).ToList();
                teams[i].RunsScored = GetRunsScoredByTeamAfterThisDate(teams[i], date);
                teams[i].RunsAllowed = GetRunsAllowedByTeamAfterThisDate(teams[i], date);
            }
            return teams;
        }

        public int GetRunsScoredByTeamAfterThisDate(Team team, DateTime date)
        {
            using (SqlCommand command = new SqlCommand("GetRunsScoredByTeamBAfterThisDate", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@Date", SqlDbType.Date);
                command.Prepare();
                command.Parameters[0].Value = team.TeamAbbreviation;
                command.Parameters[1].Value = date;

                return (int)command.ExecuteScalar();
            }
        }

        public int GetRunsAllowedByTeamAfterThisDate(Team team, DateTime date)
        {
            using (SqlCommand command = new SqlCommand("GetRunsAllowedByTeamBAfterThisDate", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@Date", SqlDbType.Date);
                command.Prepare();
                command.Parameters[0].Value = team.TeamAbbreviation;
                command.Parameters[1].Value = date;

                return (int)command.ExecuteScalar();
            }
        }

        public IEnumerable<Team> GetList()
        {
            List<Team> teams = new List<Team>(); 
            using (SqlCommand command = new SqlCommand("GetAllTeams", _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Abbreviation = (string)reader["TeamAbbreviation"];
                        string City = (string)reader["TeamCity"];
                        string Name = (string)reader["TeamName"];
                        int stadium = (int)reader["TeamStadium"];
                        int SZ = (int)reader["StrikeZoneProbability"];
                        int Swing_SZ = (int)reader["SwingInStrikeZoneProbability"];
                        int Swing_NotSZ = (int)reader["SwingOutsideStrikeZoneProbability"];
                        int Hitting = (int)reader["HittingProbability"];
                        int Foul = (int)reader["FoulProbability"];
                        int Single = (int)reader["SingleProbability"];
                        int Double = (int)reader["DoubleProbability"];
                        int HomeRun = (int)reader["HomeRunProbability"];
                        int PopoutOnFoul = (int)reader["PopoutOnFoulProbability"];
                        int FlyoutOnHR = (int)reader["FlyoutOnHomerunProbability"];
                        int Groundout = (int)reader["GroundoutProbability"];
                        int Flyout = (int)reader["FlyoutProbability"];
                        int SF = (int)reader["SacrificeFlyProbability"];
                        int DoublePlay = (int)reader["DoublePlayProbability"];
                        int SuccesfullSB = (int)reader["StealingBaseSuccessfulAttemptProbability"];
                        int Bunt = (int)reader["SuccessfulBuntAttemptProbability"];
                        bool DHRule = (bool)reader["LeagueDHRule"];
                        int W = (int)reader["W"];
                        int L = (int)reader["L"];
                        int HBP = (int)reader["HitByPitchProbability"];
                        int SB = (int)reader["StealingBaseProbability"];
                        teams.Add(new Team(Abbreviation, City, Name, SZ, Swing_SZ, Swing_NotSZ,
                                              Hitting, Foul, Single, Double, HomeRun, PopoutOnFoul,
                                              FlyoutOnHR, Groundout, Flyout, SF, DoublePlay, SuccesfullSB,
                                              Bunt, stadium, DHRule, W, L, HBP, SB));
                    }
                }
            }
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].TeamColor = GetAllColorsForThisTeam(teams[i].TeamAbbreviation).ToList();
                teams[i].TeamManager = GetManagerForThisTeam(teams[i]).First();
            }
            return teams;
        }

        public IEnumerable<Team> UpdateBalanceForThisTeam(Team team)
        {
            List<Team> teams = new List<Team>();
            using (SqlCommand command = new SqlCommand("UpdateBalanceForThisTeam", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = team.TeamAbbreviation;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Abbreviation = (string)reader["TeamAbbreviation"];
                        string City = (string)reader["TeamCity"];
                        string Name = (string)reader["TeamName"];
                        int stadium = (int)reader["TeamStadium"];
                        int SZ = (int)reader["StrikeZoneProbability"];
                        int Swing_SZ = (int)reader["SwingInStrikeZoneProbability"];
                        int Swing_NotSZ = (int)reader["SwingOutsideStrikeZoneProbability"];
                        int Hitting = (int)reader["HittingProbability"];
                        int Foul = (int)reader["FoulProbability"];
                        int Single = (int)reader["SingleProbability"];
                        int Double = (int)reader["DoubleProbability"];
                        int HomeRun = (int)reader["HomeRunProbability"];
                        int PopoutOnFoul = (int)reader["PopoutOnFoulProbability"];
                        int FlyoutOnHR = (int)reader["FlyoutOnHomerunProbability"];
                        int Groundout = (int)reader["GroundoutProbability"];
                        int Flyout = (int)reader["FlyoutProbability"];
                        int SF = (int)reader["SacrificeFlyProbability"];
                        int DoublePlay = (int)reader["DoublePlayProbability"];
                        int StealingBase = (int)reader["StealingBaseSuccessfulAttemptProbability"];
                        int Bunt = (int)reader["SuccessfulBuntAttemptProbability"];
                        bool DHRule = (bool)reader["LeagueDHRule"];
                        int W = (int)reader["W"];
                        int L = (int)reader["L"];
                        int HBP = (int)reader["HitByPitchProbability"];
                        int SB = (int)reader["StealingBaseProbability"];
                        teams.Add(new Team(Abbreviation, City, Name, SZ, Swing_SZ, Swing_NotSZ,
                                              Hitting, Foul, Single, Double, HomeRun, PopoutOnFoul,
                                              FlyoutOnHR, Groundout, Flyout, SF, DoublePlay, StealingBase,
                                              Bunt, stadium, DHRule, W, L, HBP, SB));
                    }
                }
            }
            return teams;
        }

        public IEnumerable<Pitcher> GetPitcherByID(int id)
        {
            using (SqlCommand command = new SqlCommand("UpdatePitcherStats", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Player", SqlDbType.Int);
                command.Prepare();
                command.Parameters[0].Value = id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int _id = (int)reader["PlayerID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        int Games = (int)reader["G"];
                        int Strikeouts = (int)reader["K"];
                        int Outs = (int)reader["Outs"];
                        int Runs = (int)reader["R"];
                        int Walks = (int)reader["BB"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int BattersFaced = (int)reader["TBF"];
                        int HitByPitch = (int)reader["HBP"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int QualityStarts = (int)reader["QS"];
                        int CompleteGames = (int)reader["CG"];
                        int Shutouts = (int)reader["SHO"];
                        int Wins = (int)reader["W"];
                        int Losses = (int)reader["L"];
                        int Saves = (int)reader["SV"];
                        int Holds = (int)reader["HLD"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        yield return new Pitcher(_id, FirstName, SecondName, number, Games, Strikeouts, Outs, 
                                                 Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, 
                                                 QualityStarts, Shutouts, CompleteGames, Wins, Losses, Holds, Saves, 
                                                 HitByPitch, Single, Double, Triple, HomeRun, Runs, Batting, Pitching);
                    }
                }
            }
        }

        public IEnumerable<Batter> GetCurrentLineupForThisMatch(string team, int Match)
        {
            using (SqlCommand command = new SqlCommand("GetCurrentLineupForThisMatch", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Prepare();
                command.Parameters[0].Value = team;
                command.Parameters[1].Value = Match;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        int PositionInLineup = (int)reader["NumberInLineup"];
                        string Position = (string)reader["PlayerPosition"];
                        int Games = (int)reader["G"];
                        int Strikeouts = (int)reader["K"];
                        int Walks = (int)reader["BB"];
                        int HitByPitch = (int)reader["HBP"];
                        int Flyout = (int)reader["AO"];
                        int Groundout = (int)reader["GO"];
                        int Popout = (int)reader["PO"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int Runs = (int)reader["R"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int RBI = (int)reader["RBI"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        yield return new Batter(id, FirstName, SecondName, number, Games, Single, Double, Triple, 
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing, 
                                                Runs, Walks, Position, PositionInLineup, Strikeouts, Groundout, Flyout, 
                                                Popout, Batting, Pitching);
                    }
                }
            }
        }

        public IEnumerable<Pitcher> GetStartingPitcherForThisTeam(Team team, int matchID)
        {
            using (SqlCommand command = new SqlCommand("GetStartingPitcherForThisTeam", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = matchID;
                command.Parameters[1].Value = team.TeamAbbreviation;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        int Games = (int)reader["G"];
                        int Strikeouts = (int)reader["K"];
                        int Outs = (int)reader["Outs"];
                        int Runs = (int)reader["R"];
                        int Walks = (int)reader["BB"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int BattersFaced = (int)reader["TBF"];
                        int HitByPitch = (int)reader["HBP"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int QualityStarts = (int)reader["QS"];
                        int CompleteGames = (int)reader["CG"];
                        int Shutouts = (int)reader["SHO"];
                        int Wins = (int)reader["W"];
                        int Losses = (int)reader["L"];
                        int Saves = (int)reader["SV"];
                        int Holds = (int)reader["HLD"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        int PositionInLineup = (int)reader["PlayerPositionInLineup"];
                        yield return new Pitcher(id, FirstName, SecondName, number, Games, Strikeouts, Outs, 
                                                 Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, 
                                                 QualityStarts, Shutouts, CompleteGames, Wins, Losses, Saves, Holds, 
                                                 HitByPitch, Single, Double, Triple, HomeRun, Runs, PositionInLineup, 
                                                 Batting, Pitching);
                    }
                }
            }
        }
        
        public IEnumerable<Pitcher> UpdateStatsForThisPitcher(Pitcher pitcher)
        {
            using (SqlCommand command = new SqlCommand("UpdatePitcherStats", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Player", SqlDbType.Int);
                command.Prepare();
                command.Parameters[0].Value = pitcher.id;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        int Games = (int)reader["G"];
                        int Strikeouts = (int)reader["K"];
                        int Outs = (int)reader["Outs"];
                        int Runs = (int)reader["R"];
                        int Walks = (int)reader["BB"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int BattersFaced = (int)reader["TBF"];
                        int HitByPitch = (int)reader["HBP"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int QualityStarts = (int)reader["QS"];
                        int CompleteGames = (int)reader["CG"];
                        int Shutouts = (int)reader["SHO"];
                        int Wins = (int)reader["W"];
                        int Losses = (int)reader["L"];
                        int Saves = (int)reader["SV"];
                        int Holds = (int)reader["HLD"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        yield return new Pitcher(id, FirstName, SecondName, number, Games, Strikeouts, Outs, 
                                                 Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, 
                                                 QualityStarts, Shutouts, CompleteGames, Wins, Losses, Saves, Holds, 
                                                 HitByPitch, Single, Double, Triple, HomeRun, Runs, Batting, Pitching);
                    }
                }
            }
        }

        public IEnumerable<Color> GetAllColorsForThisTeam(string abbreviation)
        {
            List<Color> colors = new List<Color>();
            using (SqlCommand command = new SqlCommand("GetColorsForThisTeam", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = abbreviation;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Red = (int)reader["RedComponent"];
                        int Green = (int)reader["GreenComponent"];
                        int Blue = (int)reader["BlueComponent"];
                        colors.Add(Color.FromArgb(Red, Green, Blue));
                    }
                }
            }
            return colors;
        }

        public IEnumerable<Manager> GetManagerForThisTeam(Team team)
        {
            using (SqlCommand command = new SqlCommand("GetManagerForThisTeam", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = team.TeamAbbreviation;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["ManagerID"];
                        string FirstName = (string)reader["ManagerFirstName"];
                        string SecondName = (string)reader["ManagerSecondName"];
                        string PlaceOfBirth = (string)reader["PlaceOfBirth"];
                        DateTime dob = (DateTime)reader["ManagerDateOfBirth"];
                        yield return new Manager(id, FirstName, SecondName, PlaceOfBirth, dob);
                    }
                }
            }
        }

        public IEnumerable<Pitcher> GetAvailablePitchers(Match match, Team team)
        {
            using (SqlCommand command = new SqlCommand("GetAvailablePitchersForSubstitution", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = match.MatchID;
                command.Parameters[1].Value = team.TeamAbbreviation;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        int Games = (int)reader["G"];
                        int Strikeouts = (int)reader["K"];
                        int Outs = (int)reader["Outs"];
                        int Runs = (int)reader["R"];
                        int Walks = (int)reader["BB"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int BattersFaced = (int)reader["TBF"];
                        int HitByPitch = (int)reader["HBP"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int QualityStarts = (int)reader["QS"];
                        int CompleteGames = (int)reader["CG"];
                        int Shutouts = (int)reader["SHO"];
                        int Wins = (int)reader["W"];
                        int Losses = (int)reader["L"];
                        int Saves = (int)reader["SV"];
                        int Holds = (int)reader["HLD"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        yield return new Pitcher(id, FirstName, SecondName, number, Games, Strikeouts, Outs, 
                                                 Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, 
                                                 QualityStarts, Shutouts, CompleteGames, Wins, Losses, Saves, Holds, 
                                                 HitByPitch, Single, Double, Triple, HomeRun, Runs, Batting, Pitching);
                    }
                }
            }
        }

        public void SubstitutePitcher(Match match, Team team, Pitcher pitcher)
        {
            using (SqlCommand command = new SqlCommand("SubstitutePitcher", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Match", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Team", SqlDbType.NVarChar, 3));
                command.Parameters.Add(new SqlParameter("@NewPitcher", SqlDbType.Int));

                command.Prepare();

                command.Parameters[0].Value = match.MatchID;
                command.Parameters[1].Value = team.TeamAbbreviation;
                command.Parameters[2].Value = pitcher.id;

                var result = command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Batter> GetAvailableBatters(Match match, Team team, Batter batter)
        {
            using (SqlCommand command = new SqlCommand("GetAvailableBattersForSubstitution", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@Position", SqlDbType.NVarChar, 2);
                command.Prepare();
                command.Parameters[0].Value = match.MatchID;
                command.Parameters[1].Value = team.TeamAbbreviation;
                command.Parameters[2].Value = batter.PositionForThisMatch;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        int Games = (int)reader["G"];
                        int Strikeouts = (int)reader["K"];
                        int Walks = (int)reader["BB"];
                        int HitByPitch = (int)reader["HBP"];
                        int Flyout = (int)reader["AO"];
                        int Groundout = (int)reader["GO"];
                        int Popout = (int)reader["PO"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int Runs = (int)reader["R"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int RBI = (int)reader["RBI"];
                        string Batting = (string)reader["PlayerBattingHand"];
                        string Pitching = (string)reader["PlayerPitchingHand"];
                        yield return new Batter(id, FirstName, SecondName, number, Games, Single, Double, Triple, 
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing, 
                                                Runs, Walks, batter.PositionForThisMatch, batter.NumberInBattingLineup, 
                                                Strikeouts, Groundout, Flyout, Popout, Batting, Pitching);
                    }
                }
            }
        }

        public void SubstituteBatter(Match match, Team team, Batter oldBatter, Batter newBatter)
        {
            using (SqlCommand command = new SqlCommand("SubstituteBatter", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Match", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Team", SqlDbType.NVarChar, 3));
                command.Parameters.Add(new SqlParameter("@NewPitcher", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Position", SqlDbType.NVarChar, 2));
                command.Parameters.Add(new SqlParameter("@Number", SqlDbType.Int));

                command.Prepare();

                command.Parameters[0].Value = match.MatchID;
                command.Parameters[1].Value = team.TeamAbbreviation;
                command.Parameters[2].Value = newBatter.id;
                command.Parameters[3].Value = oldBatter.PositionForThisMatch;
                command.Parameters[4].Value = oldBatter.NumberInBattingLineup;

                var result = command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Team> ReturnTeamBattingStats()
        {
            List<Team> teams = new List<Team>();
            using (SqlCommand command = new SqlCommand("ReturnTeamBattingStats", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string team = (string)reader["TeamAbbreviation"];
                        string Name = (string)reader["TeamName"];
                        int TGP = (int)reader["TGP"];
                        int Strikeouts = (int)reader["K"];
                        int Walks = (int)reader["BB"];
                        int HitByPitch = (int)reader["HBP"];
                        int Flyout = (int)reader["AO"];
                        int Groundout = (int)reader["GO"];
                        int Popout = (int)reader["PO"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int Runs = (int)reader["R"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int RBI = (int)reader["RBI"]; ;
                        int PA = (int)reader["PA"];
                        int GIDP = (int)reader["GIDP"];
                        teams.Add(new Team(team, Name, TGP, Single, Double, Triple, HomeRun, 
                                           SacFlies, Bunts, RBI, HitByPitch, StolenBase, 
                                           CaughtStealing, Runs, Walks, Strikeouts, Groundout, 
                                           Flyout, Popout, PA, GIDP));
                    }
                }
            }
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].TeamColor = GetAllColorsForThisTeam(teams[i].TeamAbbreviation).ToList();
                teams[i].TeamManager = GetManagerForThisTeam(teams[i]).First();
            }
            return teams;
        }

        public IEnumerable<Team> ReturnTeamPitchingStats()
        {
            List<Team> teams = new List<Team>();
            using (SqlCommand command = new SqlCommand("ReturnTeamPitchingStats", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string team = (string)reader["TeamAbbreviation"];
                        string Name = (string)reader["TeamName"];
                        int TGP = (int)reader["TGP"];
                        int Strikeouts = (int)reader["K"];
                        int Outs = (int)reader["Outs"];
                        int Runs = (int)reader["R"];
                        int Walks = (int)reader["BB"];
                        int Single = (int)reader["1B"];
                        int Double = (int)reader["2B"];
                        int Triple = (int)reader["3B"];
                        int HomeRun = (int)reader["HR"];
                        int BattersFaced = (int)reader["TBF"];
                        int HitByPitch = (int)reader["HBP"];
                        int SacFlies = (int)reader["SF"];
                        int Bunts = (int)reader["SAC"];
                        int StolenBase = (int)reader["SB"];
                        int CaughtStealing = (int)reader["CS"];
                        int DoublePlay = (int)reader["GIDP"];
                        int QualityStarts = (int)reader["QS"];
                        int CompleteGames = (int)reader["CG"];
                        int Shutouts = (int)reader["SHO"];
                        int Flyout = (int)reader["AO"];
                        int Groundout = (int)reader["GO"];
                        int Wins = (int)reader["W"];
                        int Losses = (int)reader["L"];
                        int Saves = (int)reader["SV"];
                        int Holds = (int)reader["HLD"];
                        teams.Add(new Team(team, Name, TGP, Strikeouts, Outs, Walks, Bunts, SacFlies, 
                                           StolenBase, CaughtStealing, BattersFaced, QualityStarts, 
                                           Shutouts, CompleteGames, Wins, Losses, Saves, Holds, 
                                           HitByPitch, Single, Double, Triple, HomeRun, Runs, 
                                           DoublePlay, Groundout, Flyout));
                    }
                }
            }
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].TeamColor = GetAllColorsForThisTeam(teams[i].TeamAbbreviation).ToList();
                teams[i].TeamManager = GetManagerForThisTeam(teams[i]).First();
            }
            return teams;
        }
    }
}