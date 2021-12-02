using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext context;
        
        /// <summary>
        /// variavel que irá conter a tabela dbset é a mesma propriedade usada para mapear as tabelas em <see cref="MyContext"/>
        /// </summary>
        /// <remarks>
        /// facilita o uso, porque agora não é necessario utilizar toda vez 
        /// <example>
        /// <para>
        /// <c>var dbset = this.context.Set</c>
        /// </para>
        /// </example>
        /// </remarks>
        protected readonly DbSet<T> dataset;

        // MyContext sendo inserido como dependência
        public BaseRepository(MyContext context)
        {
            this.context = context;
            this.dataset = this.context.Set<T>();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                    item.Id = Guid.NewGuid();

                item.CreatedAt = DateTime.UtcNow;

                await this.dataset.AddAsync(item);
                await this.context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }

        public Task<T> SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}