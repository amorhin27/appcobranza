using AppData.Application.Contracts.Persistence.IPrestamo;
using AppData.Domain;
using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.UnitTests.Mocks
{
    public class MockPrestamoRepository
    {
        public static Mock<IPrestamoRepository> GetPrestamoRepository()
        {
            var fixture = new Fixture();
            var prestamo = fixture.CreateMany<Prestamo>().ToList();

            var mockRepository = new Mock<IPrestamoRepository>();
            //mockRepository.Setup(r=>r.GetPrestamo()).Returns(prestamo);
            return mockRepository;
        }
    }
}
