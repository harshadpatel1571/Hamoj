﻿

using Hamoj.DB.Context;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Hamoj.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly HamojDBContext _context;

        public LoginService(HamojDBContext context)
        {
            _context = context;
        }

        public async Task<CustomerDto> CheakCustomerLogin(LoginDto dto)
        {
            return await _context.Customer.Where(y => y.Email == dto.Email && y.Password == dto.Password).Select( y=> new CustomerDto
            {
                Id = y.Id,
                Email = y.Email,
                Password = y.Password,
                is_Active = y.is_Active,
                is_Delete = y.is_Delete
            }).FirstOrDefaultAsync();
            
        }

        public async Task<UserDto> CheakVendorLogin(LoginDto dto)
        {
            return await _context.Vendor.Where(x => x.Email == dto.Email && x.Password == dto.Password).Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                is_Active = x.is_Active,
                is_Delete = x.is_Delete
            }).FirstOrDefaultAsync();

        }
    }
}
