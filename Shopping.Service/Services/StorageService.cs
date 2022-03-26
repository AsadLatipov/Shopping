using Microsoft.EntityFrameworkCore;
using Shopping.Data.IRepositories;
using Shopping.Domain.Commons;
using Shopping.Domain.Entities.Storages;
using Shopping.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopping.Service.Services
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository storageRepository;
        public StorageService(IStorageRepository storageRepository) =>
            this.storageRepository = storageRepository;

        public async Task<BaseResponse<IEnumerable<Storage>>> GetAllAsync(Expression<Func<Storage, bool>> expression = null)
        {
            BaseResponse<IEnumerable<Storage>> baseResponse = new BaseResponse<IEnumerable<Storage>>();
            var entities = await storageRepository.GetAllAsync(expression);
            var temp = entities.Include(x => x.Product);
            baseResponse.Data = temp;
            return baseResponse;
        }
    }
}
