using AppService.Domain.Registration.Request;
using AppService.Domain.Registration.Response;

namespace AppService.Domain;

public interface IRegistrationService
{
    Task AddAccountAsync(AddAccountRequest request);
    Task<List<AccountResponse>> GetAccountsAsync();

    Task AddCreditCardAsync(AddCreditCardRequest request);
    Task<List<CreditCardResponse>> GetCreditCardsAsync();

    Task AddCategoryAsync(AddCategoryRequest request);
    Task<List<CategoryResponse>> GetCategoriesAsync();
}
