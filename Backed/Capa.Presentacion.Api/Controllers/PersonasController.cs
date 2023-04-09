using Capa.Conexion.Models;
using Capa.Presentacion.Api.Models;
using Capa.Repository.Repositorio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Presentacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        #region Property  
        [System.Obsolete]
        private IHostingEnvironment _hostingEnvironment;
        #endregion
        private PersonaRepository personaRepository;
        private readonly ILogger<PersonasController> _logger;

        [System.Obsolete]
        public PersonasController(ILogger<PersonasController> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Metodo para mostrar dastos en la tabla Alumno
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            personaRepository = new PersonaRepository(_hostingEnvironment);
            return personaRepository.GetAll().ToArray();
        }


        [HttpGet("/{id}")]
        public Persona GetById(int id)
        {
            personaRepository = new PersonaRepository(_hostingEnvironment);
            return personaRepository.GetById(id);
        }

        [HttpPut()]
        public IActionResult Update([FromBodyAttribute] Persona entity)
        {
            _logger.LogInformation("Update : " + entity);
            personaRepository = new PersonaRepository(_hostingEnvironment);
            Persona Persona = entity;
            personaRepository.Modify(Persona);
            return Ok(Persona);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] PersonaModels personaModels)
        {
            Persona Persona = new Persona();
            List<Persona> listPersona= new List<Persona>();
            personaRepository = new PersonaRepository(_hostingEnvironment);
            Persona entity = new Persona();
            _logger.LogInformation("Add : " + personaModels);
            if (personaModels.Nombre  == null)
            {
                return BadRequest(new PersonaModels { Success = false, ErrorCode = "S01", ErrorMessage = "Invalid persona request" });
               

            }
            if (personaModels.file != null)
            {
                entity = new Persona()
                {

                    Id = personaModels.Id,
                    Nombre = personaModels.Nombre,
                    Apellido = personaModels.Apellido,
                    FechaNacimiento = personaModels.FechaNacimiento,
                    EstadoCivil = personaModels.EstadoCivil,
                    TieneHermanod = personaModels.TieneHermanod,
                };
                //Ajunto los datos para la imagen
                listPersona.Add(entity);
                foreach (var item in listPersona)
                {
                  
                    _logger.LogInformation("file uploaded : " + item);
                    var respuestaFoto = await personaRepository.WriteFile(personaModels.file, entity);//Se ira almacenar
                    entity = new Persona()
                    {

                        Id = item.Id,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        FechaNacimiento = item.FechaNacimiento,
                        Foto = respuestaFoto,
                        EstadoCivil = item.EstadoCivil,
                        TieneHermanod = item.TieneHermanod,

                    };

                }
                Persona = personaRepository.Add(entity);//Alamacena foto
            }
            else
            {
                return BadRequest(new PersonaModels { Success = false, ErrorCode = "S02", ErrorMessage = "Invalida foto de la persona request" });
               
            }
            
           

            return Ok(Persona);
        }


    }
}
