using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using traffic_management_system.Application.DTOs.Driver;
using traffic_management_system.Application.Interfaces;
using traffic_management_system.Application.Interfaces.Services;
using traffic_management_system.Domain.Entities;

namespace traffic_management_system.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepositoryProvider _repositoryProvider;

        public DriverService(IRepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }
        public async Task<DriverDto> AddDriverAsync(NewDriverRequest request)
        {
            var dbDriver = await _repositoryProvider.DriverRepository.GetDriverByLicenseNoAsync(request.LicenseNo);
            if (dbDriver != null)
            {
                //driver exists already

            }
            var driver = new Driver()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address
            };
            await _repositoryProvider.DriverRepository.AddDriverAsync(driver);
            await _repositoryProvider.SaveChangesAsync();
            var driverDto = new DriverDto()
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Address = driver.Address
            };
            return driverDto;
        }
    }
}
