using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Conexion.Models;
using Capa.Repository.Repositorio;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Capa.Test.Api.Api
{
    public class UnitTestPersonas
    {
        [Obsolete]
        private IHostingEnvironment _hostingEnvironment;
        private PersonaRepository personaRepository;

        [Obsolete]
        public UnitTestPersonas(IHostingEnvironment hostingEnvironment)
        {
        
            _hostingEnvironment = hostingEnvironment;
        }


        [Fact]
        [Obsolete]
        public void TestGetAll()
        {
            personaRepository = new PersonaRepository(_hostingEnvironment);
            //Arrange
            //Act
            var result = personaRepository.GetAll().ToArray(); 
            //Assert
            Assert.Equal(7, personaRepository.GetAll().Count());

        }


        [Fact]
        [Obsolete]
        public void TestGetByID()
        {
            personaRepository = new PersonaRepository(_hostingEnvironment);
            //Arrange
            //Act
            var completePersona = new Persona()
            {
                Id = 6,
                Nombre = "Title",
                Apellido = "Description",
                FechaNacimiento = new DateTime(2012, 12, 25, 10, 30, 50),
                Foto = "string",
                EstadoCivil = 0,
                TieneHermanod = true
            };

            var result = personaRepository.GetById(completePersona.Id);
            //Assert
            Assert.Equal(6, result.Id);
        }

        [Fact]
        [Obsolete]
        public void AddPersonaTest()
        {
            //OK RESULT TEST START
            personaRepository = new PersonaRepository(_hostingEnvironment);
            //Arrange
            var completePersona = new Persona()
            {
                Id = 7,
                Nombre = "Title",
                Apellido = "Description",
                FechaNacimiento = new DateTime(2012, 12, 25, 10, 30, 50),
                Foto = "string",
                EstadoCivil = 0,
                TieneHermanod = true
            };

            // Act
            personaRepository.Add(completePersona);

        }

        [Fact]
        public void UpdatePersonaTest()
        {
            //OK RESULT TEST START
            personaRepository = new PersonaRepository(_hostingEnvironment);
            //Arrange
            var completePersona = new Persona()
            {
                Id = 4,
                Nombre = "Titles",
                Apellido = "Descriptions",
                FechaNacimiento = new DateTime(2012, 12, 25, 10, 30, 50),
                Foto = "string",
                EstadoCivil = 0,
                TieneHermanod = true
            };

            // Act
            personaRepository.Modify(completePersona);


        }
    }
}
