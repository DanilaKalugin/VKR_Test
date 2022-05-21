using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using Entities;

namespace VKR.DAL
{
    public class TeamsDAO : DAO
    {
        public IEnumerable<Team> GetStandings(DateTime date)
        {
            using (var command = new SqlCommand("GetStandings", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Date", SqlDbType.Date);
                command.Prepare();
                command.Parameters[0].Value = date;
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var Abbreviation = (string)reader["TeamAbbreviation"];
                        var Name = (string)reader["TeamName"];
                        var League = (string)reader["LeagueID"];
                        var Division = (string)reader["DivisionTitle"];
                        var HW = (int)reader["HW"];
                        var HL = (int)reader["HL"];
                        var AW = (int)reader["AW"];
                        var AL = (int)reader["AL"];
                        var streak = (int)reader["Streak"];
                        yield return new Team(Abbreviation, Name, League, Division, HW, HL, AW, AL, streak);
                    }
            }
        }

        public int GetRunsScoredByTeamAfterThisDate(Team team, DateTime date)
        {
            using (var command = new SqlCommand("GetRunsScoredByTeamBAfterThisDate", _connection))
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
            using (var command = new SqlCommand("GetRunsAllowedByTeamBAfterThisDate", _connection))
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
            var teams = new List<Team>(); 
            using (var command = new SqlCommand("GetAllTeams", _connection))
            {
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var Abbreviation = (string)reader["TeamAbbreviation"];
                        var City = (string)reader["TeamCity"];
                        var Name = (string)reader["TeamName"];
                        var stadium = (int)reader["TeamStadium"];
                        var SZ = (int)reader["StrikeZoneProbability"];
                        var Swing_SZ = (int)reader["SwingInStrikeZoneProbability"];
                        var Swing_NotSZ = (int)reader["SwingOutsideStrikeZoneProbability"];
                        var Hitting = (int)reader["HittingProbability"];
                        var Foul = (int)reader["FoulProbability"];
                        var Single = (int)reader["SingleProbability"];
                        var Double = (int)reader["DoubleProbability"];
                        var HomeRun = (int)reader["HomeRunProbability"];
                        var Triple = (int)reader["TripleProbability"];
                        var PopoutOnFoul = (int)reader["PopoutOnFoulProbability"];
                        var FlyoutOnHR = (int)reader["FlyoutOnHomerunProbability"];
                        var Groundout = (int)reader["GroundoutProbability"];
                        var Flyout = (int)reader["FlyoutProbability"];
                        var SF = (int)reader["SacrificeFlyProbability"];
                        var DoublePlay = (int)reader["DoublePlayProbability"];
                        var SuccesfullSB = (int)reader["StealingBaseSuccessfulAttemptProbability"];
                        var Bunt = (int)reader["SuccessfulBuntAttemptProbability"];
                        var DHRule = (bool)reader["LeagueDHRule"];
                        var W = (int)reader["W"];
                        var L = (int)reader["L"];
                        var HBP = (int)reader["HitByPitchProbability"];
                        var SB = (int)reader["StealingBaseProbability"];
                        var League = (string)reader["League"];
                        teams.Add(new Team(Abbreviation, City, Name, SZ, Swing_SZ, Swing_NotSZ,
                            Hitting, Foul, Single, Double, HomeRun, PopoutOnFoul,
                            FlyoutOnHR, Groundout, Flyout, SF, DoublePlay, SuccesfullSB,
                            Bunt, stadium, DHRule, W, L, HBP, SB, Triple, League));
                    }
            }
            foreach (var team in teams)
            {
                team.TeamColor = GetAllColorsForThisTeam(team.TeamAbbreviation).ToList();
                team.TeamManager = GetManagerForThisTeam(team).First();
                team.BattingStats = ReturnTeamBattingStats(team.TeamAbbreviation).First();
                team.PitchingStats = ReturnTeamPitchingStats(team.TeamAbbreviation).First();
            }
            return teams;
        }

        public IEnumerable<(int, int)> UpdateBalanceForThisTeam(Team team)
        {
            using (var command = new SqlCommand("UpdateBalanceForThisTeam", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = team.TeamAbbreviation;
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var W = (int)reader["W"];
                        var L = (int)reader["L"];

                        yield return ValueTuple.Create(W, L);
                    }
            }
        }

        public IEnumerable<Color> GetAllColorsForThisTeam(string abbreviation)
        {
            using (var command = new SqlCommand("GetColorsForThisTeam", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = abbreviation;

                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var Red = (int)reader["RedComponent"];
                        var Green = (int)reader["GreenComponent"];
                        var Blue = (int)reader["BlueComponent"];
                        yield return Color.FromArgb(Red, Green, Blue);
                    }
            }
        }

        public IEnumerable<Manager> GetManagerForThisTeam(Team team)
        {
            using (var command = new SqlCommand("GetManagerForThisTeam", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = team.TeamAbbreviation;
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var id = (int)reader["ManagerID"];
                        var FirstName = (string)reader["ManagerFirstName"];
                        var SecondName = (string)reader["ManagerSecondName"];
                        var PlaceOfBirth = (string)reader["PlaceOfBirth"];
                        var dob = (DateTime)reader["ManagerDateOfBirth"];
                        yield return new Manager(id, FirstName, SecondName, PlaceOfBirth, dob);
                    }
            }
        }

        public void SubstitutePitcher(Match match, Team team, Pitcher pitcher)
        {
            using (var command = new SqlCommand("SubstitutePitcher", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Match", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Team", SqlDbType.NVarChar, 3));
                command.Parameters.Add(new SqlParameter("@NewPitcher", SqlDbType.Int));

                command.Prepare();

                command.Parameters[0].Value = match.MatchID;
                command.Parameters[1].Value = team.TeamAbbreviation;
                command.Parameters[2].Value = pitcher.Id;

                command.ExecuteNonQuery();
            }
        }

        public void SubstituteBatter(Match match, Team team, Batter oldBatter, Batter newBatter)
        {
            using (var command = new SqlCommand("SubstituteBatter", _connection))
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

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<BattingStats> ReturnTeamBattingStats(string code)
        {
            using (var command = new SqlCommand("ReturnBattingStatsByTeamCode", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 3));
                command.Prepare();

                command.Parameters[0].Value = code;

                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var TGP = (int)reader["TGP"];
                        var Strikeouts = (int)reader["K"];
                        var Walks = (int)reader["BB"];
                        var HitByPitch = (int)reader["HBP"];
                        var Flyout = (int)reader["AO"];
                        var Groundout = (int)reader["GO"];
                        var Popout = (int)reader["PO"];
                        var Single = (int)reader["1B"];
                        var Double = (int)reader["2B"];
                        var Triple = (int)reader["3B"];
                        var HomeRun = (int)reader["HR"];
                        var StolenBase = (int)reader["SB"];
                        var CaughtStealing = (int)reader["CS"];
                        var Runs = (int)reader["R"];
                        var SacFlies = (int)reader["SF"];
                        var Bunts = (int)reader["SAC"];
                        var RBI = (int)reader["RBI"];
                        var PA = (int)reader["PA"];
                        var GIDP = (int)reader["GIDP"];
                        yield return new BattingStats(TGP, Single, Double, Triple, HomeRun,
                            SacFlies, Bunts, RBI, HitByPitch, StolenBase,
                            CaughtStealing, Runs, Walks, Strikeouts, Groundout,
                            Flyout, Popout, PA, GIDP, TGP);
                    }
            }
        }

        public IEnumerable<PitchingStats> ReturnTeamPitchingStats(string code)
        {
            using (var command = new SqlCommand("ReturnTeamPitchingStats", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 3));
                command.Prepare();
                command.Parameters[0].Value = code;

                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var TGP = (int)reader["TGP"];
                        var Strikeouts = (int)reader["K"];
                        var Outs = (int)reader["Outs"];
                        var Runs = (int)reader["R"];
                        var Walks = (int)reader["BB"];
                        var Single = (int)reader["1B"];
                        var Double = (int)reader["2B"];
                        var Triple = (int)reader["3B"];
                        var HomeRun = (int)reader["HR"];
                        var BattersFaced = (int)reader["TBF"];
                        var HitByPitch = (int)reader["HBP"];
                        var SacFlies = (int)reader["SF"];
                        var Bunts = (int)reader["SAC"];
                        var StolenBase = (int)reader["SB"];
                        var CaughtStealing = (int)reader["CS"];
                        var DoublePlay = (int)reader["GIDP"];
                        var QualityStarts = (int)reader["QS"];
                        var CompleteGames = (int)reader["CG"];
                        var Shutouts = (int)reader["SHO"];
                        var Flyout = (int)reader["AO"];
                        var Groundout = (int)reader["GO"];
                        var Wins = (int)reader["W"];
                        var Losses = (int)reader["L"];
                        var Saves = (int)reader["SV"];
                        var Holds = (int)reader["HLD"];
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