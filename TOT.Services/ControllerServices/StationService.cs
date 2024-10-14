using System.Text.Json;
using TOT.Models.Startgg.Stations;
using TOT.Services.Caching.Interfaces;
using TOT.Services.ControllerServices.Interfaces;

namespace TOT.Services.ControllerServices
{
    public class StationService(ICachingService cachingService) : IStationService
    {
        private const string Prefix = "station";
        public async Task<List<Station>?> GetAllStationsAsync(int tournamentId, CancellationToken token)
        {
            var key = $"{Prefix}_{tournamentId}";
            return await cachingService.GetAsync<List<Station>>(key, token);
        }

        public async Task<List<Station>?> SetStationForASetAsync(int tournamentId, string setId, int stationId, CancellationToken token)
        {
            var key = $"{Prefix}_{tournamentId}";
            var stations = await GetAllStationsAsync(tournamentId, token);
            stations ??= [];

            var station = stations.FirstOrDefault(s => s.Id == stationId);
            if (station == null)
            {
                var newStation = new Station
                {
                    Id = stationId
                };
                stations.Add(newStation);
                station = stations.FirstOrDefault(s => s.Id == stationId);
            }

            station!.SetId = setId;
            var content = JsonSerializer.Serialize(stations);
            await cachingService.SetAsync(key, content, 24, token);
            return stations;
        }
    }
}
