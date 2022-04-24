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
        public TeamsDAO() : base() { }

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
                        int Triple = (int)reader["TripleProbability"];
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
                        string League = (string)reader["League"];
                        teams.Add(new Team(Abbreviation, City, Name, SZ, Swing_SZ, Swing_NotSZ,
                                              Hitting, Foul, Single, Double, HomeRun, PopoutOnFoul,
                                              FlyoutOnHR, Groundout, Flyout, SF, DoublePlay, SuccesfullSB,
                                              Bunt, stadium, DHRule, W, L, HBP, SB, Triple, League));
                    }
                }
            }
            for (int i = 0; i < teams.Count; i++)
            {
                teams[i].TeamColor = GetAllColorsForThisTeam(teams[i].TeamAbbreviation).ToList();
                teams[i].TeamManager = GetManagerForThisTeam(teams[i]).First();
                teams[i].battingStats = ReturnTeamBattingStats(teams[i].TeamAbbreviation).First();
                teams[i].pitchingStats = ReturnTeamPitchingStats(teams[i].TeamAbbreviation).First();
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
                        int Triple = (int)reader["TripleProbability"];
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
                                              Bunt, stadium, DHRule, W, L, HBP, SB, Triple));
                    }
                }
            }
            return teams;
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
                command.Parameters[2].Value = pitcher.Id;

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
                        string firstName = (string)reader["PlayerFirstName"];
                        string secondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        string placeOfBirth = (string)reader["PlaceOfBirth"];
                        DateTime dateOfBirth = (DateTime)reader["PlayerDateOfBirth"];
                        string battingHand = (string)reader["PlayerBattingHand"];
                        string pitchingHand = (string)reader["PlayerPitchingHand"];
                        string teamID = (string)reader["TeamID"];
                        bool inActiveRoster = (bool)reader["InActiveRoster"];
                        int PositionInLineup = (int)reader["NumberInLineup"];
                        string Position = (string)reader["PlayerPosition"];

                        int Games = (int)reader["BatterG"];
                        int Strikeouts = (int)reader["BatterK"];
                        int Walks = (int)reader["BatterBB"];
                        int HitByPitch = (int)reader["BatterHBP"];
                        int Flyout = (int)reader["BatterAO"];
                        int Groundout = (int)reader["BatterGO"];
                        int Popout = (int)reader["BatterPO"];
                        int Single = (int)reader["Batter1B"];
                        int Double = (int)reader["Batter2B"];
                        int Triple = (int)reader["Batter3B"];
                        int HomeRun = (int)reader["BatterHR"];
                        int StolenBase = (int)reader["BatterSB"];
                        int CaughtStealing = (int)reader["BatterCS"];
                        int Runs = (int)reader["BatterR"];
                        int SacFlies = (int)reader["BatterSF"];
                        int Bunts = (int)reader["BatterSAC"];
                        int RBI = (int)reader["BatterRBI"];
                        int PA = (int)reader["BatterPA"];
                        int GIDP = (int)reader["BatterGIDP"];
                        int TGP = (int)reader["BatterTGP"];
                        var batting = new BattingStats(Games, Single, Double, Triple,
                                                HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing,
                                                Runs, Walks, Strikeouts, Groundout, Flyout, Popout, PA, GIDP, TGP);

                        int PitcherG = (int)reader["PitcherG"];
                        int PitcherGS = (int)reader["PitcherGS"];
                        int PitcherK = (int)reader["PitcherK"];
                        int PitcherOuts = (int)reader["PitcherOuts"];
                        int PitcherR = (int)reader["PitcherR"];
                        int PitcherBB = (int)reader["PitcherBB"];
                        int Pitcher1B = (int)reader["Pitcher1B"];
                        int Pitcher2B = (int)reader["Pitcher2B"];
                        int Pitcher3B = (int)reader["Pitcher3B"];
                        int PitcherHR = (int)reader["PitcherHR"];
                        int PitcherTBF = (int)reader["PitcherTBF"];
                        int PitcherHBP = (int)reader["PitcherHBP"];
                        int PitcherSF = (int)reader["PitcherSF"];
                        int PitcherSAC = (int)reader["PitcherSAC"];
                        int PitcherSB = (int)reader["PitcherSB"];
                        int PitcherCS = (int)reader["PitcherCS"];
                        int PitcherGIDP = (int)reader["PitcherGIDP"];
                        int PitcherQS = (int)reader["PitcherQS"];
                        int PitcherCG = (int)reader["PitcherCG"];
                        int PitcherSHO = (int)reader["PitcherSHO"];
                        int PitcherAO = (int)reader["PitcherAO"];
                        int PitcherGO = (int)reader["PitcherGO"];
                        int PitcherW = (int)reader["PitcherW"];
                        int PitcherL = (int)reader["PitcherL"];
                        int PitcherSV = (int)reader["PitcherSV"];
                        int PitcherHLD = (int)reader["PitcherHLD"];
                        var pitching = new PitchingStats(PitcherG, PitcherGS, PitcherK, PitcherOuts,
                                                 PitcherBB, PitcherSAC, PitcherSF, PitcherSB, PitcherCS, PitcherTBF,
                                                 PitcherQS, PitcherSHO, PitcherCG, PitcherW, PitcherL, PitcherSV, PitcherHLD,
                                                 PitcherHBP, Pitcher1B, Pitcher2B, Pitcher3B, PitcherHR, PitcherR, PitcherGIDP,
                                                 PitcherGO, PitcherAO, TGP);

                        yield return new Batter(id, firstName, secondName, number, placeOfBirth, dateOfBirth, battingHand, pitchingHand, teamID, inActiveRoster, Position, PositionInLineup, batting, pitching);
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
                command.Parameters[2].Value = newBatter.Id;
                command.Parameters[3].Value = oldBatter.PositionForThisMatch;
                command.Parameters[4].Value = oldBatter.NumberInBattingLineup;

                var result = command.ExecuteNonQuery();
            }
        }

        public IEnumerable<BattingStats> ReturnTeamBattingStats(string code)
        {
            using (SqlCommand command = new SqlCommand("ReturnBattingStatsByTeamCode", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 3));
                command.Prepare();

                command.Parameters[0].Value = code;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
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
                        yield return new BattingStats(TGP, Single, Double, Triple, HomeRun, 
                                           SacFlies, Bunts, RBI, HitByPitch, StolenBase, 
                                           CaughtStealing, Runs, Walks, Strikeouts, Groundout, 
                                           Flyout, Popout, PA, GIDP, TGP);
                    }
                }
            }
        }

        public IEnumerable<PitchingStats> ReturnTeamPitchingStats(string code)
        {
            using (SqlCommand command = new SqlCommand("ReturnTeamPitchingStats", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 3));
                command.Prepare();
                command.Parameters[0].Value = code;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
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
                        yield return new PitchingStats(TGP, TGP, Strikeouts, Outs, Walks, Bunts, SacFlies, 
                                           StolenBase, CaughtStealing, BattersFaced, QualityStarts, 
                                           Shutouts, CompleteGames, Wins, Losses, Saves, Holds, 
                                           HitByPitch, Single, Double, Triple, HomeRun, Runs, 
                                           DoublePlay, Groundout, Flyout, TGP);
                    }
                }
            }
        }
    }
}