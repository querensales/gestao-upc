using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Domain.Registration.Response;

public record PessoaResponse
{
    public Guid? Id { get; set; }

    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public long Cpf { get; set; }
}
