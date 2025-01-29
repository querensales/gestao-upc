﻿using AppService.Domain;
using AppService.Domain.Registration.Request;
using AppService.Domain.Registration.Response;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entity;

namespace AppService.Application;

public class RegistrationService : IRegistrationService
{
    private readonly AppDbContext _appDbContext;
    public RegistrationService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddAccountAsync(AddAccountRequest request)
    {
        await _appDbContext.Account.AddAsync(new Account
        {
            Active = true,
            Name = request.Name,
        });

        await _appDbContext.SaveChangesAsync();

    }

    public async Task AddCategoryAsync(AddCategoryRequest request)
    {
        await _appDbContext.Category.AddAsync(new Category
        {
            Name = request.Name,
        });
        await _appDbContext.SaveChangesAsync();

    }

    public async Task AddCreditCardAsync(AddCreditCardRequest request)
    {
        await _appDbContext.CreditCard.AddAsync(new CreditCard
        {
            Name = request.Name
        });

        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<AccountResponse>> GetAccountsAsync()
    {
        return await _appDbContext.Account.Select(a => new AccountResponse
        {
            Id = a.Id,
            Name = a.Name,
        }).ToListAsync();
    }

    public async Task<List<CategoryResponse>> GetCategoriesAsync()
    {
        return await _appDbContext.Category.Select(c => new CategoryResponse
        {
            Id = c.Id,
            Name = c.Name
        }).ToListAsync();
    }

    public async Task<List<CreditCardResponse>> GetCreditCardsAsync()
    {
        return await _appDbContext.CreditCard.Select(cc => new CreditCardResponse
        {
            Id = cc.Id,
            Name = cc.Name
        }).ToListAsync();
    }
}
