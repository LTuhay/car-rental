﻿using Car_rental.Models.Domain;
using Car_rental.Models.Repository;

namespace Car_rental.Models.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _carRepository.GetByIdAsync(id);
        }

        public async Task AddCarAsync(Car car)
        {
            await _carRepository.AddAsync(car);
        }

        public async Task UpdateCarAsync(Car car)
        {
            await _carRepository.UpdateAsync(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate)
        {
            return await _carRepository.GetAvailableCarsAsync(startDate, endDate);
        }
    }
}
