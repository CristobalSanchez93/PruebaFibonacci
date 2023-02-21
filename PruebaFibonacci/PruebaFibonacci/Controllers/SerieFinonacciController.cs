using Microsoft.AspNetCore.Mvc;

namespace PruebaFibonacci.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieFinonacciController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<SerieFinonacciController> _logger;

        public SerieFinonacciController(ILogger<SerieFinonacciController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetDigitoSerieFibonacci")]
        public SerieFibonacci Get(int posicion)
        {
            List<SerieFibonacci> list = new List<SerieFibonacci>();
            for (int i = 0; i <= posicion; i++)
            {
                SerieFibonacci nrep = new SerieFibonacci();
                if (i==0)
                {
                    nrep.Serie = i;
                    nrep.Posicion = i;
                    list.Add(nrep);
                }
                else if (i==1)
                {
                    nrep.Posicion = i;
                    nrep.Serie = i;
                    list.Add(nrep);
                }
                else
                {
                    nrep.Posicion = i;
                    nrep.Serie = list[i - 1].Serie + list[i - 2].Serie;
                    list.Add(nrep);
                }

            }
            return list[posicion];
        }
    }

    
}