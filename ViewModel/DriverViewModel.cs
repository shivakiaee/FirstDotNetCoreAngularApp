using Model;

namespace ViewModel
{
    public class DriverViewModel : ViewModelBase<Driver>
    {
        public DriverViewModel()
            : base()
        {

        }
        public DriverViewModel(Driver model)
            : base(model)
        {
          
        }
        public int Id
        {
            get { return _model.Id; }
            set { _model.Id = value; }
        }
        public string FirstName
        {
            get { return _model.FirstName; }
            set { _model.FirstName = value; }
        }
        public string LastName
        {
            get { return _model.LastName; }
            set { _model.LastName = value; }
        }
        public string FatherName
        {
            get { return _model.FatherName; }
            set { _model.FatherName = value; }
        }
        public string PhoneNumber {
            get { return _model.PhoneNumber; }
            set { _model.PhoneNumber = value; }
        }
        public int CityId
        {
            get { return _model.CityId; }
            set { _model.CityId = value; }
        }
        private string _cityName;
        public string CityName
        {
            get
            {
                if (string.IsNullOrEmpty(_cityName))
                    return _model.City != null ? _model.City.Name : null;
                return _cityName;
            }
            set
            {
                _cityName = value;
            }
        }
        public string Address
        {
            get { return _model.Address; }
            set { _model.Address = value; }
        }
        public string PostalCode
        {
            get { return _model.PostalCode; }
            set { _model.PostalCode = value; }
        }
        public string NationalCode
        {
            get { return _model.NationalCode; }
            set { _model.NationalCode = value; }
        }
        public string Sheba
        {
            get { return _model.Sheba; }
            set { _model.Sheba = value; }
        }
        public string Email
        {
            get { return _model.Email; }
            set { _model.Email = value; }
        }
    }
}
