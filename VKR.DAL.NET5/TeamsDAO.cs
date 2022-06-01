using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using VKR.Entities.NET5;

namespace VKR.DAL.NET5
{
    public class TeamsDao : DAO
    {
        public IEnumerable<Team> GetStandings(DateTime date)
        {
            using var command = new SqlCommand("GetStandings", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Date", SqlDbType.Date);
            command.Prepare();
            command.Parameters[0].Value = date;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var abbreviation = (string)reader["TeamAbbreviation"];
                var name = (string)reader["TeamName"];
                var league = (string)reader["LeagueID"];
                var division = (string)reader["DivisionTitle"];
                var hw = (int)reader["HW"];
                var hl = (int)reader["HL"];
                var aw = (int)reader["AW"];
                var al = (int)reader["AL"];
                var streak = (int)reader["Streak"];
                yield return new Team(abbreviation, name, league, division, hw, hl, aw, al, streak);
            }
        }

        public int GetRunsScoredByTeamAfterThisDate(Team team, DateTime date)
        {
            using var command = new SqlCommand("GetRunsScoredByTeamBAfterThisDate", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Parameters.Add("@Date", SqlDbType.Date);
            command.Prepare();
            command.Parameters[0].Value = team.TeamAbbreviation;
            command.Parameters[1].Value = date;

            return (int)command.ExecuteScalar();
        }

        public int GetRunsAllowedByTeamAfterThisDate(Team team, DateTime date)
        {
            using var command = new SqlCommand("GetRunsAllowedByTeamBAfterThisDate", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Parameters.Add("@Date", SqlDbType.Date);
            command.Prepare();
            command.Parameters[0].Value = team.TeamAbbreviation;
            command.Parameters[1].Value = date;

            return (int)command.ExecuteScalar();
        }

        public IEnumerable<Team> GetList()
        {
            var teams = new List<Team>(); 
            using (var command = new SqlCommand("GetAllTeams", _connection))
            {
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var abbreviation = (string)reader["TeamAbbreviation"];
                    var city = (string)reader["TeamCity"];
                    var name = (string)reader["TeamName"];
                    var stadium = (int)reader["TeamStadium"];
                    var sz = (int)reader["StrikeZoneProbability"];
                    var swingSz = (int)reader["SwingInStrikeZoneProbability"];
                    var swingNotSz = (int)reader["SwingOutsideStrikeZoneProbability"];
                    var hitting = (int)reader["HittingProbability"];
                    var foul = (int)reader["FoulProbability"];
                    var single = (int)reader["SingleProbability"];
                    var @double = (int)reader["DoubleProbability"];
                    var homeRun = (int)reader["HomeRunProbability"];
                    var triple = (int)reader["TripleProbability"];
                    var popoutOnFoul = (int)reader["PopoutOnFoulProbability"];
                    var flyoutOnHr = (int)reader["FlyoutOnHomerunProbability"];
                    var groundout = (int)reader["GroundoutProbability"];
                    var flyout = (int)reader["FlyoutProbability"];
                    var sf = (int)reader["SacrificeFlyProbability"];
                    var doublePlay = (int)reader["DoublePlayProbability"];
                    var succesfullSb = (int)reader["StealingBaseSuccessfulAttemptProbability"];
                    var bunt = (int)reader["SuccessfulBuntAttemptProbability"];
                    var dhRule = (bool)reader["LeagueDHRule"];
                    var w = (int)reader["W"];
                    var l = (int)reader["L"];
                    var hbp = (int)reader["HitByPitchProbability"];
                    var sb = (int)reader["StealingBaseProbability"];
                    var league = (string)reader["League"];
                    teams.Add(new Team(abbreviation, city, name, sz, swingSz, swingNotSz,
                        hitting, foul, single, @double, homeRun, popoutOnFoul,
                        flyoutOnHr, groundout, flyout, sf, doublePlay, succesfullSb,
                        bunt, stadium, dhRule, w, l, hbp, sb, triple, league));
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
            using var command = new SqlCommand("UpdateBalanceForThisTeam", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Prepare();
            command.Parameters[0].Value = team.TeamAbbreviation;
            
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var w = (int)reader["W"];
                var l = (int)reader["L"];

                yield return ValueTuple.Create(w, l);
            }
        }

        public IEnumerable<Color> GetAllColorsForThisTeam(string abbreviation)
        {
            using var command = new SqlCommand("GetColorsForThisTeam", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Prepare();
            command.Parameters[0].Value = abbreviation;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var red = (int)reader["RedComponent"];
                var green = (int)reader["GreenComponent"];
                var blue = (int)reader["BlueComponent"];
                yield return Color.FromArgb(red, green, blue);
            }
        }

        public IEnumerable<Manager> GetManagerForThisTeam(Team team)
        {
            using var command = new SqlCommand("GetManagerForThisTeam", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Prepare();
            command.Parameters[0].Value = team.TeamAbbreviation;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = (int)reader["ManagerID"];
                var firstName = (string)reader["ManagerFirstName"];
                var secondName = (string)reader["ManagerSecondName"];
                var placeOfBirth = (string)reader["PlaceOfBirth"];
                var dob = (DateTime)reader["ManagerDateOfBirth"];
                yield return new Manager(id, firstName, secondName, placeOfBirth, dob);
            }
        }

        public void SubstitutePitcher(Match match, Team team, Pitcher pitcher)
        {
            using var command = new SqlCommand("SubstitutePitcher", _connection);
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

        public void SubstituteBatter(Match match, Team team, Batter oldBatter, Batter newBatter)
        {
            using var command = new SqlCommand("SubstituteBatter", _connection);

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

        public IEnumerable<BattingStats> ReturnTeamBattingStats(string code)
        {
            using var command = new SqlCommand("ReturnBattingStatsByTeamCode", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 3));
            command.Prepare();

            command.Parameters[0].Value = code;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var tgp = (int)reader["TGP"];
                var strikeouts = (int)reader["K"];
                var walks = (int)reader["BB"];
                var hitByPitch = (int)reader["HBP"];
                var flyout = (int)reader["AO"];
                var groundout = (int)reader["GO"];
                var popout = (int)reader["PO"];
                var single = (int)reader["1B"];
                var @double = (int)reader["2B"];
                var triple = (int)reader["3B"];
                var homeRun = (int)reader["HR"];
                var stolenBase = (int)reader["SB"];
                var caughtStealing = (int)reader["CS"];
                var runs = (int)reader["R"];
                var sacFlies = (int)reader["SF"];
                var bunts = (int)reader["SAC"];
                var rbi = (int)reader["RBI"];
                var pa = (int)reader["PA"];
                var gidp = (int)reader["GIDP"];
                yield return new BattingStats(tgp, single, @double, triple, homeRun,
                    sacFlies, bunts, rbi, hitByPitch, stolenBase,
                    caughtStealing, runs, walks, strikeouts, groundout,
                    flyout, popout, pa, gidp, tgp);
            }
        }

        public IEnumerable<PitchingStats> ReturnTeamPitchingStats(string code)
        {
            using var command = new SqlCommand("ReturnTeamPitchingStats", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 3));
            command.Prepare();
            command.Parameters[0].Value = code;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var tgp = (int)reader["TGP"];
                var strikeouts = (int)reader["K"];
                var outs = (int)reader["Outs"];
                var runs = (int)reader["R"];
                var walks = (int)reader["BB"];
                var single = (int)reader["1B"];
                var @double = (int)reader["2B"];
                var triple = (int)reader["3B"];
                var homeRun = (int)reader["HR"];
                var battersFaced = (int)reader["TBF"];
                var hitByPitch = (int)reader["HBP"];
                var sacFlies = (int)reader["SF"];
                var bunts = (int)reader["SAC"];
                var stolenBase = (int)reader["SB"];
                var caughtStealing = (int)reader["CS"];
                var doublePlay = (int)reader["GIDP"];
                var qualityStarts = (int)reader["QS"];
                var completeGames = (int)reader["CG"];
                var shutouts = (int)reader["SHO"];
                var flyout = (int)reader["AO"];
                var groundout = (int)reader["GO"];
                var wins = (int)reader["W"];
                var losses = (int)reader["L"];
                var saves = (int)reader["SV"];
                var holds = (int)reader["HLD"];
                yield return new PitchingStats(tgp, tgp, strikeouts, outs, walks, bunts, sacFlies,
                    stolenBase, caughtStealing, battersFaced, qualityStarts,
                    shutouts, completeGames, wins, losses, saves, holds,
                    hitByPitch, single, @double, triple, homeRun, runs,
                    doublePlay, groundout, flyout, tgp);
            }
        }
    }
}