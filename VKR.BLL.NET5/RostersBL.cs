using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class RostersBL
    {
        public enum TypeOfRoster { Starters, Bench, ActivePlayers, Reserve, ActiveAndReserve }

        private readonly RostersEFDAO _rostersDao = new();
        private readonly TeamsEFDAO _teamsDao = new();
        public async Task<List<List<List<PlayerInLineupViewModel>>>> GetFreeAgents()
        {
            var allFreeAgents = await _rostersDao.GetFreeAgents().ConfigureAwait(false);
            var players = new List<List<List<PlayerInLineupViewModel>>> { new() };
            players[0].Add(allFreeAgents.OrderBy(player => player.SecondName).ThenBy(player => player.FirstName).ToList());
            return players;
        }

        public async Task<List<List<List<PlayerInLineupViewModel>>>> GetRoster(TypeOfRoster typeOfRoster)
        {
            var rosterFuncs = new Dictionary<TypeOfRoster, Func<Task<List<PlayerInLineupViewModel>>>>
            {
                { TypeOfRoster.Starters, _rostersDao.GetStartingLineups },
                { TypeOfRoster.Bench , _rostersDao.GetBench},
                { TypeOfRoster.ActivePlayers, _rostersDao.GetActivePlayers },
                { TypeOfRoster.Reserve, _rostersDao.GetReserves },
                { TypeOfRoster.ActiveAndReserve, _rostersDao.GetActiveAndReservePlayers }
            };

            var allPlayers = new List<PlayerInLineupViewModel>();

            if (rosterFuncs.TryGetValue(typeOfRoster, out var playersFunc)) 
                allPlayers = await playersFunc();

            var teams = await _teamsDao.GetListAsync();

            var lineups = allPlayers.Select(player => player.LineupNumber).OrderBy(number => number).Distinct().ToList();

            var players = new List<List<List<PlayerInLineupViewModel>>>();
            for (var i = 0; i < teams.Count; i++)
            {
                players.Add(new List<List<PlayerInLineupViewModel>>());
                foreach (var lineupType in lineups)
                    players[i].Add(allPlayers
                        .Where(player => player.TeamAbbreviation == teams[i].TeamAbbreviation && player.LineupNumber == lineupType)
                        .OrderBy(player => player.NumberInLineup)
                        .ThenBy(player => player.SecondName)
                        .ThenBy(player => player.FirstName).ToList());
            }

            return players;
        }

        public async Task<List<PlayerInLineupViewModel>> GetAllPlayers()
        {
            var activePlayersTask = _rostersDao.GetActiveAndReservePlayers();
            var freeAgentsTask = _rostersDao.GetFreeAgents();

            await Task.WhenAll(activePlayersTask, freeAgentsTask);

            var allPlayers = activePlayersTask.Result.Union(freeAgentsTask.Result);

            return allPlayers
                .OrderBy(vm => vm.SecondName)
                .ThenBy(vw => vw.FirstName)
                .ToList();
        }
    }
}