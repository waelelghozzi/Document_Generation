using Generation_Documents.Entities;
using Microsoft.EntityFrameworkCore;
using Generation_Documents.DBContext;
using Generation_Documents.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Linq;
using System;

namespace Generation_Documents.Services
{



 
    public class DataRepository : IDataRepository
    {  
        private readonly DataContext _context;
        public DataRepository(DataContext context)
        {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<IEnumerable<Client>> GetClientAsync(string? name, string? searchQ)
        {
            var collection = _context.Clients as IQueryable<Client>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(P => P.ClientName == name);
            }
            if (!string.IsNullOrWhiteSpace(searchQ))
            {
                searchQ = searchQ.Trim();
                collection = collection.Where(P => P.ClientAdress.Contains(searchQ) && P.ClientAdress != null);
            }
            //var TotalItemCount = await collection.CountAsync();
            //var PaginationMetaData = new PaginationMetaData(TotalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(P => P.ClientName).ToListAsync();
            //.Skip(pageNumber * (pageNumber - 1)).
            //Take(pageSize).
            //ToListAsync();
            //return (collectionToReturn, PaginationMetaData);
            return (collectionToReturn);
        }
        public async Task<Client?> GetClientByIdAsync(int ClientID)
        {

            return await _context.Clients
                .Where(P => P.IdClient == ClientID)
                .FirstOrDefaultAsync();
        }

        public async Task AddAClientAsync(Client client)
        {
            if (client != null)
            {
                _context.Clients.Add(client);
            }
        }

        public async void DeleteAClientAsync(int ClientID)
        {
            var Client = await GetClientByIdAsync(ClientID);

            if (Client != null)
            {
                _context.Clients.Remove(Client);
            }
        }






        public Task AddAFeeAsync(int FeeId, AdditionalFee fee)
        {
            throw new NotImplementedException();
        }

        public Task AddAServiceAsync(int ServiceId, Service service)
        {
            throw new NotImplementedException();
        }

        public Task AddASupplierAsync(int SupplierId, Supplier client)
        {
            throw new NotImplementedException();
        }



        public void DeleteAFeeAsync(AdditionalFee fee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAServiceAsync(Service service)
        {
            throw new NotImplementedException();
        }

        public void DeleteASupplierAsync(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GenerateSalesInvoiceAsync(SalesInvoice invoice)
        {
            throw new NotImplementedException();
        }

       

        public Task<IEnumerable<Client>> GetListOfClientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdditionalFee>> GetListOfFeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Service>> GetListOfServicessAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetListOfSuppliersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> StoreSalesInvoiceAsync(SalesInvoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
