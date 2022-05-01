using AutoMapper;
using TrafficManagementSystem.Application.DTOs.Driver;
using TrafficManagementSystem.Application.Exceptions;
using TrafficManagementSystem.Application.Interfaces;
using TrafficManagementSystem.Application.Interfaces.Services;
using TrafficManagementSystem.Application.Wrappers;
using TrafficManagementSystem.Domain.Entities;

namespace TrafficManagementSystem.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IMapper _mapper;

        public DriverService(IRepositoryProvider repositoryProvider, IMapper mapper)
        {
            _repositoryProvider = repositoryProvider;
            _mapper = mapper;
        }
        public async Task<Response<DriverDto>> AddDriverAsync(NewDriverRequest request)
        {
            var driver = await _repositoryProvider.DriverRepository.GetDriverByLicenseNoAsync(request.LicenseNo);
            if (driver != null)
                throw new ApiException("Driver already exist.");
            driver = _mapper.Map<Driver>(request);
            await _repositoryProvider.DriverRepository.AddDriverAsync(driver);
            await _repositoryProvider.SaveChangesAsync();
            return new Response<DriverDto>(_mapper.Map<DriverDto>(driver));
        }

        public async Task DeleteDriverAsync(Guid id)
        {
            var driver = await _repositoryProvider.DriverRepository.GetDriverByIdAsync(id);
            if (driver == null)
                throw new NotFoundException("Driver not found!");
            _repositoryProvider.DriverRepository.DeleteDriver(driver);
            await _repositoryProvider.SaveChangesAsync();
        }

        public async Task<Response<IEnumerable<DriverDto>>> GetAllDrivers()
        {
            var drivers = await _repositoryProvider.DriverRepository.GetDriversAsync();
            return new Response<IEnumerable<DriverDto>>(_mapper.Map<IEnumerable<DriverDto>>(drivers));
        }

        public async Task<Response<DriverDto>> GetDriverById(Guid id)
        {
            var driver = await _repositoryProvider.DriverRepository.GetDriverByIdAsync(id);
            return driver == null ? throw new NotFoundException() : new Response<DriverDto>(_mapper.Map<DriverDto>(driver));
        }


    }
}
