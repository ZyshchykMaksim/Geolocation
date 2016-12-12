using System;
using Prism.Mvvm;
using Xamarin.Forms;
using WorkSphere.Enums;

namespace WorkSphere.Models
{
    public class Coworker : BindableBase
    {
        private string _surName;
        private string _lastName;

        private Guid _id;
        private ImageSource _image;
        private CoworkerStatus _status;

        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public string SurName
        {
            get { return _surName; }
            set
            {
                SetProperty(ref _surName, value);
                OnPropertyChanged(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
                OnPropertyChanged(() => FullName);
            }
        }


        public string FullName
        {
            get
            {
                return $"{LastName} {SurName}";
            }
        }

        public ImageSource Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        public CoworkerStatus Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
    }
}
