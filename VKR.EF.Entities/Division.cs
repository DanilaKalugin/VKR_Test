using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.EF.Entities
{
    public  class Division
    {
        public int Id { get; set; }
        public string DivisionTitle { get; set; }
        public League League { get; set; }
        public string LeagueId { get; set; }
        public virtual List<Team> Teams { get; set; } = new ();
    }
}
