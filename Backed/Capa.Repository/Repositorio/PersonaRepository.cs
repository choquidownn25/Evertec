using Capa.Conexion.Models;
using Capa.Domain.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


namespace Capa.Repository.Repositorio
{
    public class PersonaRepository : IBaseRepository<Persona>
    {
        EmpleadoContext empleadoContext = new EmpleadoContext();
        private bool disposed = false; //Para detectar 
        private TextReader reader;
        Persona resp ;
        public IHostingEnvironment _webHostEnvironment;

        #region Constructor  
        public PersonaRepository(IHostingEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion
        public Persona Add(Persona entity)
        {
            Persona entrada = new Persona()
            {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Apellido = entity.Apellido,
                    FechaNacimiento = entity.FechaNacimiento,
                    Foto = entity.Foto,
                    EstadoCivil = entity.EstadoCivil,
                    TieneHermanod = entity.TieneHermanod
            };

            var response = empleadoContext.Persona.Add(entrada);
           
            if (response != null)
            {
                empleadoContext.SaveChanges();
                using (var ctx = new EmpleadoContext())
                {
                    DateTime date = entity.FechaNacimiento;
                    var personas = ctx.Persona.Where(s => s.FechaNacimiento == date)
                                  .LastOrDefault<Persona>();
                    resp = new Persona()
                    {

                        Id = personas.Id,
                        Nombre = personas.Nombre,
                        Apellido = personas.Apellido,
                        FechaNacimiento = personas.FechaNacimiento,
                        Foto = personas.Foto,
                        EstadoCivil = personas.EstadoCivil,
                        TieneHermanod = personas.TieneHermanod,

                    };
                }
                
                return resp;
            }
            else
                throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            try
            {
                Persona persona = empleadoContext.Persona.Find(id);
                empleadoContext.Persona.Remove(persona);
                empleadoContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  :  " + ex.Message.ToString());
            }
           
        }

        public void Dispose()
        {
            // Elimine los recursos no administrados.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }
                disposed = true;
            }
        }

        public IEnumerable<Persona> GetAll()
        {
            try
            {
                List<Persona> lstObj = new List<Persona>();
                var result = (from item in empleadoContext.Persona
                              select new
                              {
                                  item.Id,
                                  item.Nombre,
                                  item.Apellido,
                                  item.FechaNacimiento,
                                  item.Foto,
                                  item.EstadoCivil,
                                  item.TieneHermanod

                              }).ToList();

                foreach (var item in result)
                {
                    Persona item1 = new Persona();

                    item1.Id = item.Id;
                    item1.Nombre = item.Nombre;
                    item1.Apellido = item.Apellido;
                    item1.FechaNacimiento= item.FechaNacimiento;
                    item1.Foto= item.Foto;
                    item1.EstadoCivil = item.EstadoCivil;
                    item1.TieneHermanod= item.TieneHermanod;

                    lstObj.Add(item1);
                }

                return lstObj;
            }
            catch (Exception e)
            {
                throw new Exception(
                "Entity Validation Failed - errors follow:\n" +
                e.ToString(), e
                ); // Add the original exception as the innerException

            }
        }

        public Persona GetById(int id)
        {
            var consulta = (from r in empleadoContext.Persona where r.Id == id select r).FirstOrDefault();
            if(consulta == null)
                throw new Exception("Entity Validation Failed - errors follow:\n"); // Add 
            else
            return consulta;
            
        }
        public Persona Modify(Persona entity)
        {
            List<Persona> listPersona = new List<Persona>();
            empleadoContext.Entry(entity).State = EntityState.Modified;
            //empleadoContext.SaveChanges();

            empleadoContext.SaveChanges();
            using (var ctx = new EmpleadoContext())
            {
                //string name = entity.Nombre;
                var personas = ctx.Persona.Where(s => s.Id == entity.Id)
                              .LastOrDefault<Persona>();
                listPersona.Add(personas);
                foreach (Persona persona in listPersona)
                {
                    persona.Id = personas.Id;
                    persona.Nombre = personas.Nombre;
                    persona.Apellido = personas.Apellido;
                    persona.FechaNacimiento = personas.FechaNacimiento;
                    persona.Foto = personas.Foto;
                    personas.EstadoCivil = personas.EstadoCivil;
                    persona.TieneHermanod = personas.TieneHermanod;
                    resp = new Persona()
                    {

                        Id = persona.Id,
                        Nombre = persona.Nombre,
                        Apellido = persona.Apellido,
                        FechaNacimiento = persona.FechaNacimiento,
                        Foto = persona.Foto,
                        EstadoCivil = persona.EstadoCivil,
                        TieneHermanod = persona.TieneHermanod,

                    };
                }
            }
            if (resp != null)
                return resp;
            else
                throw new Exception("Entity Validation Failed - errors follow:\n"); // Add 

        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> WriteFile(IFormFile file, Persona entity)
        {
            string fileName;
            try
            {
                var extension = "." + entity.Nombre.Split('\\')[entity.Apellido.Split('\\').Length - 1] + entity.Nombre.Split('.')[entity.Apellido.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension+file.FileName; //Create a new Name 
                                                                  //for the file due to security reasons.
                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Imagen\\"))
                {
                    Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Imagen\\");
                }
                using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Imagen\\" + fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return "\\Imagen\\" + fileName;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            //return fileName;
        }
    }
}
