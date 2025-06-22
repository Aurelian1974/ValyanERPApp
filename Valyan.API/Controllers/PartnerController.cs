using Valyan.API.Interfaces;
using Valyan.Shared.Data;


namespace Valyan.API.Controllers
{
    public class PartnerController
    {
        private readonly IPartnerRepository _repo;

        public PartnerController(IPartnerRepository repo)
        {
            _repo = repo;
        }

        public (int PartnerId, Guid PartnerGUID) AddPartner(Partner partner)
        {
            return _repo.InsertPartner(partner);
        }

        public void AddPartnerAddress(PartnerAddress address)
        {
            _repo.InsertPartnerAddress(address);
        }

        public void AddPartnerWithAddress(Partner partner, string txtOras, Judet selectedJudet)
        {
            // După inserarea partenerului
            var (newPartnerId, newPartnerGuid) = AddPartner(partner); // ✔️ This is correct

            // Creezi adresa cu PartnerId și PartnerGUID setate corect
            var address = new PartnerAddress
            {
                PartnerId = newPartnerId,
                PartnerGUID = newPartnerGuid,
                CityId = int.TryParse(txtOras, out var cityId) ? cityId : null,
                IdJudet = selectedJudet?.IdJudet,
                JudetGuid = selectedJudet?.JudetGuid
            };

            AddPartnerAddress(address);
        }
    }
}