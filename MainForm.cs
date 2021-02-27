using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKR_Test
{
    public partial class Form1 : Form
    {
        string team1 = "MIA";
        string team2 = "PIT";
        int runs;

        List<GameSituation> match;
        GameSituation newGameSituation;
        GameSituation previousSituation;

        public Form1()
        {
            InitializeComponent();
            match = new List<GameSituation>
            {
                new GameSituation(team1)
            };
            previousSituation = match.Last();
            newGameSituation = new GameSituation(team1);
            AwayTeam_Abbreviation.Text = team1;
            HomeTeam_Abbreviation.Text = team2;
            pitchesInLastAtBat = new List<GameSituation>();
            DisplayingCurrentSituation(match.Last());
        }

        private void DisplayingCurrentSituation(GameSituation gameSituation)
        {
            if (gameSituation.offense == team1)
            {
                label1.Text = "▲";
            }
            else
            {
                label1.Text = "▼";
            }
            label2.Text = gameSituation.inningNumber.ToString();
            label3.Text = gameSituation.outs.ToString();
            label4.Text = gameSituation.outs <= 1 ? "Out" : "Outs";
            label5.Text = $"{gameSituation.balls}-{gameSituation.strikes}";
            switch (Convert.ToInt32(gameSituation.RunnerOnFirst) + Convert.ToInt32(gameSituation.RunnerOnSecond) * 2 + Convert.ToInt32(gameSituation.RunnerOnThird) * 4)
            {
                case 0:
                    {
                        panel3.BackgroundImage = Properties.Resources._000;
                        break;
                    }
                case 1:
                    {
                        panel3.BackgroundImage = Properties.Resources._100;
                        break;
                    }
                case 2:
                    {
                        panel3.BackgroundImage = Properties.Resources._020;
                        break;
                    }
                case 3:
                    {
                        panel3.BackgroundImage = Properties.Resources._120;
                        break;
                    }
                case 4:
                    {
                        panel3.BackgroundImage = Properties.Resources._003;
                        break;
                    }
                case 5:
                    {
                        panel3.BackgroundImage = Properties.Resources._103;
                        break;
                    }
                case 6:
                    {
                        panel3.BackgroundImage = Properties.Resources._120;
                        break;
                    }
                case 7:
                    {
                        panel3.BackgroundImage = Properties.Resources._123;
                        break;
                    }
            }
            AwayTeam_RunsScored.Text = gameSituation.AwayTeamRuns.ToString();
            HomeTeam_RunsScored.Text = gameSituation.HomeTeamRuns.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pitch pitch = new Pitch(280, 20, 85, 526, 832, 1547, 1940, 1995, 635, 950, 220, 398, newGameSituation, 95, 30, match, team1);
            newGameSituation.id = previousSituation.id + 1;
            newGameSituation.result = pitch.pitchResult;
            newGameSituation.balls = newGameSituation.NumberOfBallsDetrmining(newGameSituation.result, previousSituation);
            newGameSituation.strikes = newGameSituation.NumberOfStrikesDetermining(newGameSituation.result, previousSituation);
            newGameSituation.outs = newGameSituation.NumberOfOutsDetermining(newGameSituation.result, previousSituation, newGameSituation.strikes);
            newGameSituation.RunnerOnFirst = newGameSituation.HavingARunnerOnFirstBase(newGameSituation.result, previousSituation, newGameSituation.balls);
            newGameSituation.RunnerOnSecond = newGameSituation.HavingARunnerOnSecondBase(newGameSituation.result, previousSituation, newGameSituation.balls);
            newGameSituation.RunnerOnThird = newGameSituation.HavingARunnerOnThirdBase(newGameSituation.result, previousSituation, newGameSituation.balls);
            runs = newGameSituation.NumberOfRunsScoredForLastPitch(newGameSituation.result, previousSituation, newGameSituation.balls);
            if (newGameSituation.offense == team1)
            {
                newGameSituation.AwayTeamRuns += runs;
            }
            else
            {
                newGameSituation.HomeTeamRuns += runs;
            }
            match.Add(newGameSituation);
            newGameSituation.PrepareForNextPitch(match.Last(), team1, team2);
            DisplayingCurrentSituation(newGameSituation);

            previousSituation = new GameSituation
            {
                inningNumber = newGameSituation.inningNumber,
                offense = newGameSituation.offense,
                result = newGameSituation.result,
                balls = newGameSituation.balls,
                strikes = newGameSituation.strikes,
                outs = newGameSituation.outs,
                RunnerOnFirst = newGameSituation.RunnerOnFirst,
                RunnerOnSecond = newGameSituation.RunnerOnSecond,
                RunnerOnThird = newGameSituation.RunnerOnThird,
                AwayTeamRuns = newGameSituation.AwayTeamRuns,
                HomeTeamRuns = newGameSituation.HomeTeamRuns,
                BatterNumber_AwayTeam = newGameSituation.BatterNumber_AwayTeam,
                BatterNumber_HomeTeam = newGameSituation.BatterNumber_HomeTeam
            };
        }
    }
}