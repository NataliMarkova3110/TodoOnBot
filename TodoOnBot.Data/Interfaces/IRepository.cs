namespace TodoOnBot.Data.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetById(long id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}