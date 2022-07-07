using BookStore.Application.Repositories.BaseRepository;
using BookStore.Application.Repositories.Queries;
using BookStore.Domain.Entities.Interface;
using BookStore.Persistence.Context;
using BookStore.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories.Abstract
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly AppDbContext _context;
        protected DbSet<T> _table;

        public BaseRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
            _table = _context.Set<T>(); // --> _table = _context.Books / _context.Authors ...
        }

        private int? _count;
        public int Count => _count ?? _table.Count();

        public void Delete(T entity)
        {
        }

        public async Task<T> Get(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> Get(string id)
        {
            return await _table.FindAsync(id);
        }

        public void Insert(T entity)
        {
            _table.Add(entity);
        }

        public async Task<IEnumerable<T>> List(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return await query.ToListAsync();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

        /// <summary>
        /// Bu yardimci method bana query teslim edecek ve teslim edecegi query IQueryable tipinde olacak.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private IQueryable<T> BuildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = _table;
            foreach (string include in options.GetInclude())
            {
                query = query.Include(include);
            }

            if (options.HasWhere)
            {
                foreach (var clause in options.WhereClauses)
                {
                    query = query.Where(clause);
                }
                // Where sorgulari sonunda bana donecek olan satir sayisida belli olur.
                _count = query.Count();
            }

            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")
                {
                    query = query.OrderBy(options.OrderBy);
                }
                else
                {
                    query = query.OrderByDescending(options.OrderBy);
                }
            }

            if (options.HasPaging)
            {
                // PageBy extension metodu, sayfalama icin kullanilacaktir.
                query = query.PageBy(options.PageNumber, options.PageSize);
            }
            return query;
        }
    }
}