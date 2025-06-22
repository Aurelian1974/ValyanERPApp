using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Valyan.API.Interfaces;


namespace Valyan.API.Repositories

{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly string _connectionString;

        public PartnerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public (int PartnerId, Guid PartnerGUID) InsertPartner(Partner partner)
        {
            using var conn = new SqlConnection(_connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@PartnerCode", partner.PartnerCode);
            parameters.Add("@PartnerName", partner.PartnerName);
            parameters.Add("@E_Mail", partner.E_Mail);
            parameters.Add("@Remark", partner.Remark);
            parameters.Add("@HoldingId", partner.HoldingId);
            parameters.Add("@GroupId", partner.GroupId);
            parameters.Add("@IsUE", partner.IsUE);
            parameters.Add("@IsNONUE", partner.IsNONUE);
            parameters.Add("@FiscalCode", partner.FiscalCode);
            parameters.Add("@FiscalAtribute", partner.FiscalAtribute);
            parameters.Add("@NewPartnerId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@NewPartnerGUID", dbType: DbType.Guid, direction: ParameterDirection.Output);

            conn.Execute("dbo.InsertPartner", parameters, commandType: CommandType.StoredProcedure);
            return (parameters.Get<int>("@NewPartnerId"), parameters.Get<Guid>("@NewPartnerGUID"));
        }

        public void InsertPartnerAddress(PartnerAddress address)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Execute("dbo.InsertPartnerAddress", new
            {
                PartnerId = address.PartnerId,
                CityId = address.CityId,
                IdJudet = address.IdJudet,
                JudetGuid = address.JudetGuid,
                PartnerGUID = address.PartnerGUID // <-- Add this parameter
            }, commandType: CommandType.StoredProcedure);
        }

        public bool ExistsWithHoldingOrGroupId1()
        {
            using var conn = new SqlConnection(_connectionString);
            // Procedura stocată returnează 1 dacă există, altfel 0
            var result = conn.QueryFirstOrDefault<int>(
                "dbo.ExistsPartnerWithHoldingOrGroupId1",
                commandType: CommandType.StoredProcedure);
            return result == 1;
        }
    }
}