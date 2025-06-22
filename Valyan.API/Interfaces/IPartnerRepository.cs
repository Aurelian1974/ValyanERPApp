using System.Threading.Tasks;


namespace Valyan.API.Interfaces    
{
    public interface IPartnerRepository
    {
        (int PartnerId, Guid PartnerGUID) InsertPartner(Partner partner);
        void InsertPartnerAddress(PartnerAddress address);
        // Poți adăuga și alte metode (ex: Get, Update, Delete)
    }
}