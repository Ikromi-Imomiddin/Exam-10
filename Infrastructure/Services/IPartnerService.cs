using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Infrastructure.Services
{
    public interface IPartnerService
    {
        Task<List<GetPartnerDto>> GetPartners();
        Task<GetPartnerDto> AddPartner(AddPartnerDto partner);
        Task<GetPartnerDto> UpdatePartner(AddPartnerDto partner);
        Task<bool> DeletePartner(int id);
        Task<GetPartnerDto?> GetPartnerById(int id);
    }
}