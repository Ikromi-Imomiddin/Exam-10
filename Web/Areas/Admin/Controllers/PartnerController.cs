using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers;

[Area("Admin")]
public class PartnerController : Controller
{
    private readonly IPartnerService _partnerService;

    public PartnerController(IPartnerService partnerService)
    {
        _partnerService = partnerService;
    }
    
        public async Task<IActionResult> Index()
        {
            return View(await _partnerService.GetPartners());
        }
        
        public IActionResult Create()
        {
            return View( new AddPartnerDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(AddPartnerDto partner)
        {
            if (ModelState.IsValid)
            {
                await _partnerService.AddPartner(partner);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            var partner = await _partnerService.GetPartnerById(id);
            return View(new AddPartnerDto()
            {
                Id = partner.Id,
                Title = partner.Title,
                Description = partner.Description,
                Image = partner.Description
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(AddPartnerDto partner)
        {
            if (ModelState.IsValid)
            {
                await _partnerService.UpdatePartner(partner);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            await _partnerService.DeletePartner(id);
            return RedirectToAction("Index");
        }
}