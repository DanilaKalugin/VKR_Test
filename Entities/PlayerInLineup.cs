﻿using System;

namespace Entities
{
    public class PlayerInLineup : Player
    {
        public int LineupType;
        public string Team;
        public string Position;
        public int NumberInLineup;

        public PlayerInLineup(int _id, string _FirstName, string _SecondName, DateTime dob, string _PlaceOfBirth, int Number, int _LineupType, string _Team, int _NumberInLineup)
        {
            id = _id;
            FirstName = _FirstName;
            SecondName = _SecondName;
            DateOfBirth = dob;
            PlaceOfBirth = _PlaceOfBirth;
            PlayerNumber = Number;
            LineupType = _LineupType;
            Team = _Team;
            NumberInLineup = _NumberInLineup;
        }

        public PlayerInLineup(int _id, string _FirstName, string _SecondName, DateTime dob, string _PlaceOfBirth, int Number, int _LineupType, string _Team, string _Position, int _NumberInLineup)
        {
            id = _id;
            FirstName = _FirstName;
            SecondName = _SecondName;
            DateOfBirth = dob;
            PlaceOfBirth = _PlaceOfBirth;
            PlayerNumber = Number;
            LineupType = _LineupType;
            Team = _Team;
            Position = _Position;
            NumberInLineup = _NumberInLineup;
        }
    }
}