﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTOs;

namespace Services
{
    internal sealed class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CustomerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public CustomerDto Create(CustomerCreationDto customerCreationDto)
        {
            var customer = _mapper.Map<Customer>(customerCreationDto);

            _repository.CustomerRepository.Create(customer);
            _repository.Save();

            return _mapper.Map<CustomerDto>(customer);
        }

        public void DeleteCustomer(Guid Id, bool trackChanges)
        {
            var customer = _repository.CustomerRepository.GetById(Id, trackChanges);
            if (customer == null) { throw new ResourceNotFoundException(Id); }

            _repository.CustomerRepository.DeleteCustomer(customer);
            _repository.Save();
        }

        public IEnumerable<CustomerDto> GetAll(bool trackChanges)
        {
            var customers = _repository.CustomerRepository.GetAll(trackChanges);
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public CustomerDto GetById(Guid Id, bool trackChanges)
        {
            var customer = _repository.CustomerRepository.GetById(Id, trackChanges);
            if (customer == null) { throw new ResourceNotFoundException(Id); }
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}