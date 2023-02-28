using Generation_Documents.Entities;
using Newtonsoft.Json.Linq;

namespace Generation_Documents.Services
{
    public interface IDataRepository
    {
        Task <bool> GenerateSalesInvoiceAsync(SalesInvoice invoice);
        Task <bool> StoreSalesInvoiceAsync(SalesInvoice invoice);

        Task <IEnumerable<Client>> GetListOfClientsAsync();
        Task<IEnumerable<Client>> GetClientAsync(string? name, string? searchQ);
        Task AddAClientAsync(Client client);
        void DeleteAClientAsync(int ClientID);

        Task<IEnumerable<Service>> GetListOfServicessAsync();
        Task AddAServiceAsync(int ServiceId, Service service);
        Task DeleteAServiceAsync(Service service);

        Task<IEnumerable<Supplier>> GetListOfSuppliersAsync();
        Task AddASupplierAsync(int SupplierId, Supplier client);
        void DeleteASupplierAsync(Supplier supplier);

        Task<IEnumerable<AdditionalFee>> GetListOfFeesAsync();
        Task AddAFeeAsync(int FeeId, AdditionalFee fee);
        void DeleteAFeeAsync(AdditionalFee fee);


        Task<bool> SaveChangesAsync();
    }
}
