namespace BookStore.Domain.Entities.Interface
{
    public interface IBase<T>
    {
        public T Id { get; set; }
    }
}