﻿using MiCake.Uow.Easy;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MiCake.EFCore.Easy
{
    public class EFTransactionFeature : ITransactionFeature
    {
        private readonly DbContext _dbContext;

        public EFTransactionFeature(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {

        }

        public void Rollback()
        {

        }

        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            return Task.Delay(0);
        }
    }
}
