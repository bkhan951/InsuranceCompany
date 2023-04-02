namespace InsuranceCompany.Repositories.IRepository
{
    public interface IRepository<T>
    {
        T GetById(int id);

        List<T> List();
    }
}
