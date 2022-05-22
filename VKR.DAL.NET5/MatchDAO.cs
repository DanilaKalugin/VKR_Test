using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entities.NET5;

namespace VKR.DAL.NET5
{
    public class MatchDAO : DAO
    {
        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults)
        {
            using var command = new SqlCommand("AddMatchResultsForThisPitcher", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Match", SqlDbType.Int);
            command.Parameters.Add("@Team", SqlDbType.NVarChar, 3);
            command.Parameters.Add("@Player", SqlDbType.Int);
            command.Parameters.Add("@isQS", SqlDbType.Bit);
            command.Parameters.Add("@isCG", SqlDbType.Bit);
            command.Parameters.Add("@isSHO", SqlDbType.Bit);
            command.Parameters.Add("@matchResult", SqlDbType.Int);

            command.Prepare();
            command.Parameters[0].Value = pitcherResults.Match;
            command.Parameters[1].Value = pitcherResults.Team;
            command.Parameters[2].Value = pitcherResults.Pitcher;
            command.Parameters[3].Value = pitcherResults.IsQualityStart;
            command.Parameters[4].Value = pitcherResults.IsCompleteGame;
            command.Parameters[5].Value = pitcherResults.IsShutout;
            command.Parameters[6].Value = (int)pitcherResults.MatchResult;

            command.ExecuteNonQuery();
        }

        public void DeleteThisMatch(int matchNumberForDelete)
        {
            using var command = new SqlCommand("DeleteMatch", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Match", SqlDbType.Int);

            command.Prepare();
            command.Parameters[0].Value = matchNumberForDelete;
            command.ExecuteNonQuery();
        }

        public int GetNumberOfMatchesPlayed(Match newMatch)
        {
            using var command = new SqlCommand("GetNumberOfMatchesPlayed", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@QuickMatch", SqlDbType.Bit);

            var matchId = new SqlParameter("@MatchID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Prepare();
            command.Parameters[0].Value = newMatch.IsQuickMatch;
            command.Parameters.Add(matchId);
            _ = command.ExecuteNonQuery();
            return (int)matchId.Value;
        }

        public void StartNewMatch(Match newMatch)
        {
            using var command = new SqlCommand("StartNewMatch", _connection);
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
            command.Parameters[2].Value = newMatch.Stadium.StadiumId;
            command.Parameters[3].Value = newMatch.DHRule;
            command.Parameters[4].Value = newMatch.MatchDate;
            command.Parameters[5].Value = newMatch.IsQuickMatch;
            command.ExecuteNonQuery();
        }

        public void FinishMatch(Match newMatch)
        {
            using var command = new SqlCommand("FinishMatch", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Match", SqlDbType.Int);

            command.Prepare();
            command.Parameters[0].Value = newMatch.MatchID;
            command.ExecuteNonQuery();
        }

        public void AddNewAtBat(AtBat atbat)
        {
            using var command = new SqlCommand("AddNewAtBat", _connection);
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
            command.Parameters[6].Value = atbat.Outs;
            command.Parameters[7].Value = atbat.RBI;
            command.Parameters[8].Value = atbat.Inning;

            command.ExecuteNonQuery();
        }

        public IEnumerable<Match> GetResultsForAllMatches()
        {
            using var command = new SqlCommand("GetResultsForAllMatches", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var MatchID = (int)reader["MatchID"];
                var AwayTeam = (string)reader["AwayTeam"];
                var AwayRuns = (int)reader["AwayRuns"];
                var HomeRuns = (int)reader["HomeRuns"];
                var HomeTeam = (string)reader["HomeTeam"];
                var Stadium = (int)reader["Stadium"];
                var Winner = (string)reader["Winner"];
                var Inning = (int)reader["Inning"];
                var Date = (DateTime)reader["MatchDate"];
                yield return new Match(MatchID, AwayTeam, AwayRuns, HomeRuns, HomeTeam, Stadium, Winner, Inning, Date);
            }
        }

        public IEnumerable<Match> GetSchedule()
        {
            using var command = new SqlCommand("GetSchedule", _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var MatchID = (int)reader["MatchID"];
                var AwayTeam = (string)reader["AwayTeam"];
                var HomeTeam = (string)reader["HomeTeam"];
                var Stadium = (int)reader["TeamStadium"];
                var Date = (DateTime)reader["MatchDate"];
                yield return new Match(MatchID, AwayTeam, HomeTeam, Stadium, Date);
            }
        }

        public DateTime GetDateForNextMatch()
        {
            using var command = new SqlCommand("GetDateForNextMatch", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Prepare();

            return (DateTime)command.ExecuteScalar();
        }

        public IEnumerable<Match> GetMatchesForThisDay(DateTime date)
        {
            using var command = new SqlCommand("GetAvailibleMatchesForThisDay", _connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Date", SqlDbType.Date);

            command.Prepare();
            command.Parameters[0].Value = date;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var MatchID = (int)reader["MatchID"];
                var AwayTeam = (string)reader["AwayTeam"];
                var HomeTeam = (string)reader["HomeTeam"];
                var Date = (DateTime)reader["MatchDate"];
                yield return new Match(MatchID, AwayTeam, HomeTeam, Date);
            }
        }
    }
}