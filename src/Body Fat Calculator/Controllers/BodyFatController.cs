using Microsoft.AspNetCore.Mvc;
using System;

namespace BodyFatCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyFatController : ControllerBase
    {
        [HttpGet]
        public ActionResult<double> Get(double peso, double altura, int idade, char sexo)
        {
            // Validação de entrada
            if (peso <= 0 || altura <= 0 || idade <= 0)
            {
                return BadRequest("Peso, altura e idade devem ser maiores que zero.");
            }

            if (sexo != 'M' && sexo != 'm' && sexo != 'F' && sexo != 'f')
            {
                return BadRequest("Sexo deve ser 'M' para masculino ou 'F' para feminino.");
            }

            double imc = peso / Math.Pow(altura / 100, 2);
            double porcentagemGordura;

            if (sexo == 'M' || sexo == 'm')
            {
                porcentagemGordura = (1.20 * imc) + (0.23 * idade) - 16.2;
            }
            else
            {
                porcentagemGordura = (1.20 * imc) + (0.23 * idade) - 5.4;
            }

            return porcentagemGordura;
        }
    }
}
