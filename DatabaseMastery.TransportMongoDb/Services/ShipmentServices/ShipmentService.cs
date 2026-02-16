using AutoMapper;
using DatabaseMastery.TransportMongoDb.Dtos.ShipmentDtos;
using DatabaseMastery.TransportMongoDb.Entities;
using DatabaseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabaseMastery.TransportMongoDb.Services.ShipmentServices
{
    public class ShipmentService:IShipmentService
    {
        private readonly IMongoCollection<Shipment> _ShipmentCollection;
        private readonly IMapper _mapper;
        public ShipmentService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ShipmentCollection = database.GetCollection<Shipment>(_databaseSettings.ShipmentCollectionName);
            _mapper = mapper;
        }
        public async Task CreateShipmentAsync(CreateShipmentDto createShipmentDto)
        {
            var value = _mapper.Map<Shipment>(createShipmentDto);
            await _ShipmentCollection.InsertOneAsync(value);
        }
        public async Task DeleteShipmentAsync(string id)
        {
            await _ShipmentCollection.DeleteOneAsync(x => x.ShipmentId == id);
        }
        public async Task<List<ResultShipmentDto>> GetAllShipmentAsync()
        {
            var values = await _ShipmentCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultShipmentDto>>(values);
        }
        public async Task<GetShipmentByIdDto> GetShipmentByIdAsync(string id)
        {
            var value = await _ShipmentCollection.Find(x => x.ShipmentId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetShipmentByIdDto>(value);
        }
        public async Task UpdateShipmentAsync(UpdateShipmentDto updateShipmentDto)
        {
            var values = _mapper.Map<Shipment>(updateShipmentDto);
            await _ShipmentCollection.FindOneAndReplaceAsync(x => x.ShipmentId == updateShipmentDto.ShipmentId, values);
        }
    }
}
