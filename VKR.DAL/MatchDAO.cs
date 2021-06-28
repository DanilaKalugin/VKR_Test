using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VKR.DAL
{
    public class MatchDAO : DAO
    {
        public MatchDAO()
        {
            InitConnection();
        }

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults)
        {
            using (SqlCommand command = new SqlCommand("AddMatchResultsForThisPitcher", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);
                command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
                command.Parameters.Add("@Player", SqlDbType.Int);
                command.Parameters.Add("@isQS", SqlDbType.Bit);
                command.Parameters.Add("@isCG", SqlDbType.Bit);
                command.Parameters.Add("@isSHO", SqlDbType.Bit);
                command.Parameters.Add("@isW", SqlDbType.Bit);
                command.Parameters.Add("@isL", SqlDbType.Bit);

                command.Prepare();
                command.Parameters[0].Value = pitcherResults.Match;
                command.Parameters[1].Value = pitcherResults.Team;
                command.Parameters[2].Value = pitcherResults.Pitcher;
                command.Parameters[3].Value = pitcherResults.IsQualityStart;
                command.Parameters[4].Value = pitcherResults.IsCompleteGame;
                command.Parameters[5].Value = pitcherResults.IsShutout;
                command.Parameters[6].Value = pitcherResults.IsWin;
                command.Parameters[7].Value = pitcherResults.IsLoss;
                var result = command.ExecuteNonQuery();
            }
        }

        public void DeleteThisMatch(int matchNumberForDelete)
        {
            using (SqlCommand command = new SqlCommand("DeleteMatch", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Match", SqlDbType.Int);

                command.Prepare();
                command.Parameters[0].Value = matchNumberForDelete;
                var result = command.ExecuteNonQuery();
            }
        }

        public int GetNumberOfMatchesPlayed(Match newMatch)
        {
            using (SqlCommand command = new SqlCommand("GetNumberOfMatchesPlayed", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@QuickMatch", SqlDbType.Bit);

                SqlParameter _MatchID = new SqlParameter("@MatchID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Prepare();
                command.Parameters[0].Value = newMatch.IsQuickMatch;
                command.Parameters.Add(_MatchID);
                _ = command.ExecuteNonQuery();
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
                command.Parameters.Add("@Date", SqlDbType.Date);
                command.Parameters.Add("@QuickMatch", SqlDbType.Bit);

                command.Prepare();
                command.Parameters[0].Value = newMatch.AwayTeam.TeamAbbreviation;
                command.Parameters[1].Value = newMatch.HomeTeam.TeamAbbreviation;
                command.Parameters[2].Value = newMatch.stadium.stadiumId;
                command.Parameters[3].Value = newMatch.DHRule;
                command.Parameters[4].Value = newMatch.MatchDate;
                command.Parameters[5].Value = newMatch.IsQuickMatch;
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

        public IEnumerable<Match> GetResultsForAllMatches()
        {
            using (SqlCommand command = new SqlCommand("GetResultsForAllMatches", _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int MatchID = (int)reader["MatchID"];
                        string AwayTeam = (string)reader["AwayTeam"];
                        int AwayRuns = (int)reader["AwayRuns"];
                        int HomeRuns = (int)reader["HomeRuns"];
                        string HomeTeam = (string)reader["HomeTeam"];
                        int Stadium = (int)reader["Stadium"];
                        string Winner = (string)reader["Winner"];
                        int Inning = (int)reader["InningNumber"];
                        DateTime Date = (DateTime)reader["MatchDate"];
                        yield return new Match(MatchID, AwayTeam, AwayRuns, HomeRuns, HomeTeam, Stadium, Winner, Inning, Date);
                    }
                }
            }
        }

        public DateTime GetDateForNextMatch()
        {
            using (SqlCommand command = new SqlCommand("GetDateForNextMatch", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Prepare();

                return (DateTime)command.ExecuteScalar();
            }
        }

        public IEnumerable<Match> GetMatchesForThisDay(DateTime date)
        {
            using (SqlCommand command = new SqlCommand("GetAvailibleMatchesForThisDay", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Date", SqlDbType.Date);

                command.Prepare();
                command.Parameters[0].Value = date;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int MatchID = (int)reader["MatchID"];
                        string AwayTeam = (string)reader["AwayTeam"];
                        string HomeTeam = (string)reader["HomeTeam"];
                        DateTime Date = (DateTime)reader["MatchDate"];
                        yield return new Match(MatchID, AwayTeam, HomeTeam, Date);
                    }
                }
            }
        }
    }
}