using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Domain.Entities;
using WebMVC.Domain.Repositories.Abstract;

namespace WebMVC.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext _context;
        public EFServiceItemsRepository(AppDbContext context)
        {
            _context = context;
        }
        public void DeleteServiceItem(Guid id)
        {
            _context.Remove(new ServiceItem() { Id = id });
            _context.SaveChanges();
        }

        public ServiceItem GetServiceItemById(Guid id)
        {
            return _context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<ServiceItem> GetServiceItems()
        {
            return _context.ServiceItems;
        }

        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
