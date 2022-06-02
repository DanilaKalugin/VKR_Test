using System;
using System.Collections.Generic;

namespace VKR.EF.Entities
{
    public class Player : Man
    {
        public byte PlayerNumber {get; set;}
        public BattingHand BattingHand { get; set; }
        public BattingHandEnum PlayerBattingHand { get; set; }
    }
}