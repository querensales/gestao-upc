using AppService.Domain.Registration.Response;
using Bogus;
using Bogus.Extensions.Brazil;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuerenController : ControllerBase
{
    [HttpGet("buscar-por-id/{Id}")]
    public IActionResult GetById(Guid Id)
    {
        return Ok(Pessoa);
    }


    [HttpGet("buscar-por-cpf/{cpf}")]
    public IActionResult GetByCpf(long cpf)
    {
        if (cpf == 0)
        {
            return NotFound("meteu o loko, passa outro CPF");
        }

        if (!IsCpfValid(cpf.ToString()))
        {
            return NotFound("Meteu o loko, cpf inválido");
        }
        return Ok(Pessoa);
    }

    [HttpGet("buscar-todos")]
    public IActionResult GetAll()
    {
        return Ok(Pessoas);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] PessoaResponse pessoa)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { errorMessage = "Valicação" });
        }

        if (pessoa.Id != null)
        {
            return BadRequest("Como um registro novo já tem ID seu mané?");
        }

        if (!IsCpfValid(pessoa.Cpf.ToString()))
        {
            return BadRequest("CPF inválido KCT");
        }

        return Created();
    }

    [HttpPut("update")]
    public IActionResult Up([FromBody] PessoaResponse pessoa)
    {
        return Accepted();
    }

    public static bool IsCpfValid(string cpf)
    {
        // 1. Remove non-digit characters
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        // 2. Check for length
        if (cpf.Length != 11)
            return false;

        // 3. Check for all digits being the same (e.g., "111.111.111-11")
        if (new string(cpf[0], 11) == cpf)
            return false;

        // 4. Calculate the first verification digit
        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += int.Parse(cpf[i].ToString()) * (10 - i);

        int remainder = sum % 11;
        int firstDigit = remainder < 2 ? 0 : 11 - remainder;

        // 5. Check the first verification digit
        if (int.Parse(cpf[9].ToString()) != firstDigit)
            return false;

        // 6. Calculate the second verification digit
        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += int.Parse(cpf[i].ToString()) * (11 - i);

        remainder = sum % 11;
        int secondDigit = remainder < 2 ? 0 : 11 - remainder;

        // 7. Check the second verification digit
        if (int.Parse(cpf[10].ToString()) != secondDigit)
            return false;

        return true;
    }

    private List<PessoaResponse> Pessoas
    {
        get
        {
            var faker = new Faker<PessoaResponse>("pt_BR")
                        .RuleFor(p => p.Id, f=>f.Random.Guid())
                        .RuleFor(p => p.Nome, f => f.Person.FullName)
                        .RuleFor(p => p.Cpf, f => long.Parse(f.Person.Cpf(false)))
                        .RuleFor(p => p.DataNascimento, f => f.Person.DateOfBirth);

            return faker.Generate(100);
        }
    }



    private PessoaResponse Pessoa
    {
        get
        {
            var faker = new Faker<PessoaResponse>("pt_BR")
                .RuleFor(p => p.Id, Guid.NewGuid())
                .RuleFor(p => p.Nome, f => f.Person.FullName)
                .RuleFor(p => p.Cpf, f => long.Parse(f.Person.Cpf(false)))
                .RuleFor(p => p.DataNascimento, f => f.Person.DateOfBirth);
            return faker.Generate();
        }
    }

}
