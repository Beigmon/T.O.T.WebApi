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
            try
            {
                var key = $"{Prefix}_{tournamentId}";
                var result = await cachingService.GetAsync<List<Station>>(key, token);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return [];
            }
        }

        public async Task<List<Station>?> SetStationForASetAsync(int tournamentId, Station station, CancellationToken token)
        {
            try
            {
                var key = $"{Prefix}_{tournamentId}";
                var stations = await GetAllStationsAsync(tournamentId, token);
                stations ??= [];

                var existingStation = stations.FirstOrDefault(s => s.Id == station?.Id);
                if (existingStation == null)
                {
                    stations.Add(station);
                    existingStation = stations.FirstOrDefault(s => s.Id == station.Id);
                }

                existingStation!.SetId = station.SetId;
                await cachingService.SetAsync(key, stations, 24, token);
                return stations;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return [];
            }
        }

        public async Task<List<Station>?> RemoveStationForASetAsync(int tournamentId, string setId, CancellationToken token)
        {
            var key = $"{Prefix}_{tournamentId}";
            var stations = await GetAllStationsAsync(tournamentId, token);
            stations ??= [];

            var existingStation = stations.FirstOrDefault(s => s.SetId == setId);
            if (existingStation == null)
                return stations;

            existingStation.SetId = string.Empty;
            await cachingService.SetAsync(key, stations, 24, token);
            return stations;
        }
    }
}
