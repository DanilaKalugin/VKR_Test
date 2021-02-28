using Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VKR.DAL
{
    public class MatchDAO : IDisposable
    {
        private SqlConnection _connection;

        public static string GetConnectionString()
        {
            var currentConnection = ConfigurationManager.AppSettings["CurrentConnectionString"];
            var connectionString = ConfigurationManager.ConnectionStrings[currentConnection].ConnectionString;
            return connectionString;
        }

        public MatchDAO()
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

        public void AddMatchResultForThisPitcher(int matchID, string teamAbbreviation, int playerID, Pitcher.PitcherResult PitcherResult)
        {
            using (SqlCommand command = new SqlCommand("AddMatchResultForThisPitcher", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@Player", SqlDbType.Int);
                command.Parameters.Add("@Result", SqlDbType.Int);

                command.Prepare();
                command.Parameters[0].Value = matchID;
                command.Parameters[1].Value = teamAbbreviation;
                command.Parameters[2].Value = playerID;
                command.Parameters[3].Value = PitcherResult;
                var result = command.ExecuteNonQuery();
            }
        }
        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults)
        {
            using (SqlCommand command = new SqlCommand("AddMatchResultForThisPitcher", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@Player", SqlDbType.Int);
                command.Parameters.Add("@isQS", SqlDbType.Bit);
                command.Parameters.Add("@isCG", SqlDbType.Bit);
                command.Parameters.Add("@isSHO", SqlDbType.Bit);

                command.Prepare();
                command.Parameters[0].Value = pitcherResults.Match;
                command.Parameters[1].Value = pitcherResults.Team;
                command.Parameters[2].Value = pitcherResults.Pitcher;
                command.Parameters[3].Value = pitcherResults.IsQualityStart;
                command.Parameters[4].Value = pitcherResults.IsCompleteGame;
                command.Parameters[5].Value = pitcherResults.IsShutout;
                var result = command.ExecuteNonQuery();
            }
        }


        public int GetNumberOfMatchesPlayed()
        {
            using (SqlCommand command = new SqlCommand("GetNumberOfMatchesPlayed", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter _MatchID = new SqlParameter("@MatchID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Prepare();
                command.Parameters.Add(_MatchID);
                var result = command.ExecuteNonQuery();
                return (int)_MatchID.Value;
                
            }
        }

        public void StartNewMatch(Match newMatch)
        {
            using (SqlCommand command = new SqlCommand("StartNewMatch", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@AwayTeam", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@HomeTeam", SqlDbType.NVarChar, 3);
                command.Parameters.Add("Stadium", SqlDbType.Int);
                command.Parameters.Add("DHRule", SqlDbType.Bit);

                command.Prepare();
                command.Parameters[0].Value = newMatch.AwayTeam.TeamAbbreviation;
                command.Parameters[1].Value = newMatch.HomeTeam.TeamAbbreviation;
                command.Parameters[2].Value = newMatch.stadium.stadiumId;
                command.Parameters[3].Value = newMatch.DHRule;
                var result = command.ExecuteNonQuery();
            }
        }
        
        public void FinishMatch(Match newMatch)
        {
            using (SqlCommand command = new SqlCommand("FinishMatch", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);

                command.Prepare();
                command.Parameters[0].Value = newMatch.MatchID;
                var result = command.ExecuteNonQuery();
            }
        }

        public void AddNewAtBat(AtBat atbat)
        {
            using (SqlCommand command = new SqlCommand("AddNewAtBat", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MatchID", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Offense", SqlDbType.NVarChar, 3));
                command.Parameters.Add(new SqlParameter("@Batter", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@AtBatResult", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Defense", SqlDbType.NVarChar, 3));
                command.Parameters.Add(new SqlParameter("@Pitcher", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Outs", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@RBI", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Inning", SqlDbType.Int));

                command.Prepare();

                command.Parameters[0].Value = atbat.MatchId;
                command.Parameters[1].Value = atbat.Offense;
                command.Parameters[2].Value = atbat.Batter;
                command.Parameters[3].Value = atbat.AtBatResult + 1;
                command.Parameters[4].Value = atbat.Defense;
                command.Parameters[5].Value = atbat.Pitcher;
                command.Parameters[6].Value = atbat.outs;
                command.Parameters[7].Value = atbat.RBI;
                command.Parameters[8].Value = atbat.Inning;

                var result = command.ExecuteNonQuery();
            }
        }
    }
}