namespace EventManagementProject.Interfaces.Repository
{
    public interface IRepository<K, T> where T : class
    {
        public Task<T> GetById(K id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(T entity);

    }
}
