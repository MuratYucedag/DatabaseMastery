
using DatabaseMastery.DinnerMenuPostgreSQL.Context;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMastery.DinnerMenuPostgreSQL.Services.DashboardServices
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;
        public DashboardService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> GetApprovedReservationCountAsync()
        {
            return await _context.Reservations.CountAsync(x => x.Status == "Onaylandı");
        }
        public async Task<int> GetCancelledReservationCountAsync()
        {
            return await _context.Reservations.CountAsync(x => x.Status == "İptal Edildi");
        }
        public async Task<int> GetPendingReservationCountAsync()
        {
            return await _context.Reservations.CountAsync(x => x.Status == "Beklemede");
        }
        public Task<int> GetTodayOrderCountAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<int> GetTodayReservationCountAsync()
        {
            return await _context.Reservations.CountAsync(x => x.ReservationDate.Date == DateTime.Today);
        }
        public async Task<int> GetTotalCustomerCountAsync()
        {
            return await _context.Reservations.SumAsync(x => x.GuestCount);
        }
        public async Task<int> GetTotalMenuProductCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<int> GetTotalReservationCountAsync()
        {
            return await _context.Reservations.CountAsync();
        }
    }
}
