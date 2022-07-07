using BookStore.Application.Repositories.Queries;
using BookStore.Domain.Entities.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Application.Repositories.BaseRepository
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        /// <summary>
        /// CMS projesindeki GetFilteredList metodu 4 tane parametre aliyordu bu parametrelerin çok daha profesyonel ve yonetilebilir hali olan QueryOptions icerisinde yonetecegiz.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> List(QueryOptions<T> options);
        /// <summary>
        /// Bir sorgu kac satir sonuc dondugunu tutacak
        /// </summary>
        int Count { get; }
        /// <summary>
        /// CMS deki GetFilteredFirstOrDefault() metodunun karsiligidir.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<T> Get(QueryOptions<T> options);
        Task<T> Get(int id);
        Task<T> Get(string id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}