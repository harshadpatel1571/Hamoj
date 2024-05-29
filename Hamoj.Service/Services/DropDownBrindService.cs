﻿using Hamoj.DB.Context;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class DropDownBrindService : IDropDownBrindService
{
    private readonly HamojDBContext _context;
    public DropDownBrindService(HamojDBContext context)
    {
        _context = context;

    }

    public async Task<List<DropDownDto>>BrindCategoryDropDown()
    {
        var data = await _context.Category.Select(x => new DropDownDto
        {
            Id = x.Id,
            Name = x.Name,
        }).ToListAsync();
        return data;
    }

}
