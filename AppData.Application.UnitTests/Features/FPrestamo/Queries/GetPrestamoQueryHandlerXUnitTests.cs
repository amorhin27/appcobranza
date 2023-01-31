using AppData.Application.Contracts.IUnitWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.UnitTests.Features.FPrestamo.Queries
{
    public class GetPrestamoQueryHandlerXUnitTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GetPrestamoQueryHandlerXUnitTests(Mock<IUnitOfWork> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
