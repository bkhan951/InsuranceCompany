namespace InsuranceCompany.Repositories.IRepository
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);

        Task<List<T>> List();
    }
}
