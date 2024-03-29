﻿using System.Linq;
using VKR.EF.Entities.Tables;

namespace VKR.EF.Entities.RandomGenerators
{
    public class PitchBeforeBaseStealingGenerator : NormalPitchGenerator
    {
        public override Pitch CreatePitch(GameSituation situation, Match match)
        {
            var offense = situation.Offense;
            var defense = situation.Offense == match.AwayTeam ? match.HomeTeam : match.AwayTeam;

            var numberOfPitches = match.GameSituations.Count(gameSituation => gameSituation.Offense.TeamAbbreviation == situation.Offense.TeamAbbreviation && situation.Id > 0);
            var pitcherCoefficient = GetPitcherCoefficientForThisPitcher(defense);

            if (numberOfPitches > pitcherCoefficient) numberOfPitches += numberOfPitches - pitcherCoefficient;

            _newPitchGettingIntoStrikeZoneResult = GettingIntoStrikeZoneDefinition(defense.TeamRating.StrikeZoneProbability, defense.TeamRating.HitByPitchProbability, numberOfPitches, pitcherCoefficient, situation);
            _newPitchSwingResult = SwingDefinition(_newPitchGettingIntoStrikeZoneResult, offense.TeamRating.SwingInStrikeZoneProbability, offense.TeamRating.SwingOutsideStrikeZoneProbability, numberOfPitches, situation);
            NewPitchResult = PitchResultDefinition(_newPitchGettingIntoStrikeZoneResult, _newPitchSwingResult);
            return new Pitch(NewPitchResult);
        }
    }
}