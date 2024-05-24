﻿using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Hamoj.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hamoj.web.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> BindData()
        {
            var vendorbind = await _vendorService.GetAllAsync();

            return Json(new { data = vendorbind, status = true, });
        }
        

        public async Task<IActionResult> AddEdit(int id)
        {
            if(id>0)
            {
                var Edit = await _vendorService.GetDataById(id);
                return View(Edit);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(VendorDto dto)
        {
            var AddEdit = await _vendorService.AddEditVendor(dto);
            return RedirectToAction("Index");
        }
    }
}
