﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Runner
    {
        public int runnerID;
        public string runnerPosition;
        public int pitcherID;
        public bool IsBaseNotEmpty;

        public Runner()
        {
            runnerID = 0;
            runnerPosition = "";
            pitcherID = 0;
            IsBaseNotEmpty = false;
        }

        public Runner(Runner runnerOnFirst)
        {
            if (runnerOnFirst.IsBaseNotEmpty)
            {
                runnerID = runnerOnFirst.runnerID;
                runnerPosition = runnerOnFirst.runnerPosition;
                pitcherID = runnerOnFirst.pitcherID;
                IsBaseNotEmpty = true;
            }
            else
            {
                runnerID = 0;
                runnerPosition = "";
                pitcherID = 0;
                IsBaseNotEmpty = false;
            }
        }

        public Runner(Batter batter, Pitcher pitcher)
        {
            runnerID = batter.id;
            runnerPosition = batter.PositionForThisMatch;
            pitcherID = pitcher.id;
            IsBaseNotEmpty = true;
        }
    }
}
