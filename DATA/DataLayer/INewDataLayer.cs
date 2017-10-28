using NHibernate;

namespace Data
{
    public interface INewDataLayer
    {
        ISession GetSession();
    }
}