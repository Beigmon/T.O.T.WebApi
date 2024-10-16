using TOT.Models.Startgg.Stations;

namespace TOT.Services.ControllerServices.Interfaces
{
    public interface IStationService
    {
        public Task<List<Station>?> GetAllStationsAsync(int tournamentId, CancellationToken token);

        public Task<List<Station>?> SetStationForASetAsync(int tournamentId, Station station, CancellationToken token);
        public Task<List<Station>?> RemoveStationForASetAsync(int tournamentId, string setId, CancellationToken token);
    }
}
