﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewMatchResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW MatchResults AS
SELECT        MatchID, AwayTeam, HomeTeam, Sum(CASE WHEN Offense = AwayTeam THEN RBI ELSE 0 END) AS AwayRuns, 
            Sum(CASE WHEN Offense = HomeTeam THEN RBI ELSE 0 END) AS HomeRuns, AwayTeam AS Winner,
                HomeTeam AS Loser, MAX(Inning) AS Inning, Stadium, MatchDate, MatchType
                FROM(Matches LEFT JOIN ExpandedAtBats ON MatchID = Match)
            WHERE        MatchEnded = 1
            GROUP BY MatchID, AwayTeam, HomeTeam, Stadium, MatchDate, MatchType
            HAVING        Sum(CASE WHEN Offense = AwayTeam THEN RBI ELSE 0 END) > Sum(CASE WHEN Offense = HomeTeam THEN RBI ELSE 0 END)
            UNION
            SELECT        MatchID, AwayTeam, HomeTeam, Sum(CASE WHEN Offense = AwayTeam THEN RBI ELSE 0 END),
            Sum(CASE WHEN Offense = HomeTeam THEN RBI ELSE 0 END), '', '', ISNULL(MAX(Inning), 1),
            Stadium, MatchDate, MatchType
                FROM(Matches LEFT JOIN ExpandedAtBats ON MatchID = Match)
            WHERE        MatchEnded = 0
            GROUP BY MatchID, AwayTeam, HomeTeam, Stadium, MatchDate, MatchType
            UNION
            SELECT        MatchID, AwayTeam, HomeTeam, Sum(CASE WHEN Offense = AwayTeam THEN RBI ELSE 0 END),
            Sum(CASE WHEN Offense = HomeTeam THEN RBI ELSE 0 END), HomeTeam, AwayTeam, MAX(Inning),
            Stadium, MatchDate, MatchType
                FROM(Matches LEFT JOIN ExpandedAtBats ON MatchID = Match)
            WHERE        MatchEnded = 1
            GROUP BY MatchID, AwayTeam, HomeTeam, Stadium, MatchDate, MatchType
            HAVING        Sum(CASE WHEN Offense = AwayTeam THEN RBI ELSE 0 END) < Sum(CASE WHEN Offense = HomeTeam THEN RBI ELSE 0 END)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW MatchResults");
        }
    }
}
