namespace JustAnotherSimpleFormApplication.Core.Services.Abstract
{
    public interface IQueryBuilderFactory
    {
        IQueryBuilder<T> Create<T>();
    }
}
