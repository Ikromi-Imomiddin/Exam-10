using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PartnerService : IPartnerService
{
    private readonly DataContext _context;

    public PartnerService(DataContext  context)
    {
        _context = context;
    }
    
    public async Task<List<GetPartnerDto>> GetPartners()
    {
        return await _context.Partners.Select(p => new GetPartnerDto()
        {
            Id = p.Id,
            Title = p.Title,
            Image = p.Image,
            Description = p.Description
        }).ToListAsync();
    }
    
    //add partner
    public async Task<GetPartnerDto> AddPartner(AddPartnerDto partner)
    {
        var newPartner = new Partner()
        {
            Title = partner.Title,
            Description = partner.Description,
            Image = partner.Image

        };
        await _context.Partners.AddAsync(newPartner);
        await _context.SaveChangesAsync();
        return new GetPartnerDto()
        {
            Id = newPartner.Id,
            Title = newPartner.Title,
            Description = newPartner.Description,
            Image = newPartner.Image
        };
    }
    
    //update partner
    public async Task<GetPartnerDto> UpdatePartner(AddPartnerDto partner)
    {
        var updatepartner = await _context.Partners.FirstOrDefaultAsync(x => x.Id == partner.Id);
        if (updatepartner == null)
        {
            return null;
        }
        updatepartner.Title = partner.Title;
        updatepartner.Image = partner.Image;
        updatepartner.Description = partner.Description;
        await _context.SaveChangesAsync();
        return new GetPartnerDto()
        {
            Id = updatepartner.Id,
            Title = updatepartner.Title,
            Description = updatepartner.Description,
            Image = updatepartner.Image
        };
    }
    
    //delete partner
    public async Task<bool> DeletePartner(int id)
    {
        var deletepartner = await _context.Partners.FirstOrDefaultAsync(x => x.Id == id);
        if (deletepartner == null)
        {
            return false;
        }
        _context.Partners.Remove(deletepartner);
        await _context.SaveChangesAsync();
        return true;
    }
    
    //get partner by id
    public async Task<GetPartnerDto?> GetPartnerById(int id)
    {
        return await _context.Partners.Where(x => x.Id == id).Select(x => new GetPartnerDto()
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Image = x.Image
        }).FirstOrDefaultAsync();
    }
}