using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Entities;
using System.Drawing;
using System.Linq;

namespace VKR.DAL
{
    public class TeamsDAO : IDisposable
    {
        private SqlConnection _connection;

        public static string GetConnectionString()
        {
            var currentConnection = ConfigurationManager.AppSettings["CurrentConnectionString"];
            var connectionString = ConfigurationManager.ConnectionStrings[currentConnection].ConnectionString;
            return connectionString;
        }

        public TeamsDAO()
        {
            InitConnection();
        }

        private void InitConnection()
        {
            _connection = new SqlConnection(GetConnectionString());
            _connection.Open();
            _connection.StateChange += ConnectionStateChange;
        }

        void ConnectionStateChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Broken)
            {
                InitConnection();
            }
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
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
                        teams.Add(new Team(Abbreviation, Name, W, L, League, Division));
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
                        int StealingBase = (int)reader["StealingBaseSuccessfulAttemptProbability"];
                        int Bunt = (int)reader["SuccessfulBuntAttemptProbability"];
                        bool DHRule = (bool)reader["LeagueDHRule"];
                        int W = (int)reader["W"];
                        int L = (int)reader["L"];
                        teams.Add(new Team(Abbreviation, City, Name, SZ, Swing_SZ, Swing_NotSZ,
                                              Hitting, Foul, Single, Double, HomeRun, PopoutOnFoul,
                                              FlyoutOnHR, Groundout, Flyout, SF, DoublePlay, StealingBase,
                                              Bunt, stadium, DHRule, W, L));
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
                        yield return new Batter(id, FirstName, SecondName, number, Games, Single, Double, Triple, HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing, Runs, Walks, Position, PositionInLineup, Strikeouts, Groundout, Flyout, Popout);
                    }
                }
            }
        }

        public IEnumerable<Pitcher> GetStartingPitcherForThisTeam(Team team)
        {
            using (SqlCommand command = new SqlCommand("GetStartingPitcherForThisMatch", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Prepare();
                command.Parameters[0].Value = team.TeamAbbreviation;
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
                        int PositionInLineup = (int)reader["PlayerPositionInLineup"];
                        yield return new Pitcher(id, FirstName, SecondName, number, Games, Strikeouts, Outs, Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, QualityStarts, Shutouts, CompleteGames, 0, 0, 0, 0, HitByPitch, Single, Double, Triple, HomeRun, Runs, PositionInLineup);
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
                        yield return new Pitcher(id, FirstName, SecondName, number, Games, Strikeouts, Outs, Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, QualityStarts, Shutouts, CompleteGames, 0, 0, 0, 0, HitByPitch, Single, Double, Triple, HomeRun, Runs);
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

        public IEnumerable<Batter> GetStartingLineupForThisMatch(string Team, bool DHRule)
        {
            using (SqlCommand command = new SqlCommand("GetStartingLineupForThisTeam", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@DHRule", SqlDbType.Bit);
                command.Prepare();
                command.Parameters[0].Value = Team;
                command.Parameters[1].Value = DHRule;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["PlayerID"];
                        string FirstName = (string)reader["PlayerFirstName"];
                        string SecondName = (string)reader["PlayerSecondName"];
                        int number = (int)reader["PlayerNumber"];
                        int PositionInLineup = (int)reader["PlayerPositionInLineup"];
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
                        yield return new Batter(id, FirstName, SecondName, number, Games, Single, Double, Triple, HomeRun, SacFlies, Bunts, RBI, HitByPitch, StolenBase, CaughtStealing, Runs, Walks, Position, PositionInLineup, Strikeouts, Groundout, Flyout, Popout);
                    }
                }
            }
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
                        yield return new Pitcher(id, FirstName, SecondName, number, Games, Strikeouts, Outs, Walks, Bunts, SacFlies, StolenBase, CaughtStealing, BattersFaced, QualityStarts, Shutouts, CompleteGames, 0, 0, 0, 0, HitByPitch, Single, Double, Triple, HomeRun, Runs);
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
    }
}