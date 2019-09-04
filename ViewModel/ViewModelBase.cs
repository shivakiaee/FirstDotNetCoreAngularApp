using Model;
using System.Collections.Generic;

namespace ViewModel
{
    public class ViewModelBase<T> : IViewModelBase<T>, IViewModelBase where T : BaseEntity, new()
    {
        protected T _model;
        public T GetModel()
        {
            return _model;
        }

        public virtual IViewModelBase<T> SetModel(T model)
        {
            _model = model;
            return this;
        }

        public ViewModelBase(T model)
        {
            SetModel(model);
        }

        public ViewModelBase()
        {
            SetModel(new T());

        }
        public T Model
        {
            get
            {
                return _model;
            }
        }

        public BaseEntity GetObjectModel()
        {
            return this.Model;
        }

        public static IEnumerable<ViewModel> GetViewModels<ViewModel>(IEnumerable<T> models) where ViewModel : ViewModelBase<T>, new()
        {

            if (models != null)
                foreach (var model in models)
                {
                    yield return new ViewModel() { _model = model };
                }
        }
        public static ViewModel GetViewModel<ViewModel>(T model) where ViewModel : ViewModelBase<T>, new()
        {
            return new ViewModel() { _model = model };
        }

        BaseEntity IViewModelBase<T>.GetObjectModel()
        {
            throw new System.NotImplementedException();
        }
    }
}
