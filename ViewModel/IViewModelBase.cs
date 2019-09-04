using Model;
namespace ViewModel
{
    public interface IViewModelBase<T> where T : BaseEntity, new()
    {
        T Model
        {
            get;
        }
        T GetModel();
        IViewModelBase<T> SetModel(T model);
        BaseEntity GetObjectModel();
    }

    public interface IViewModelBase
    {

    }
}
