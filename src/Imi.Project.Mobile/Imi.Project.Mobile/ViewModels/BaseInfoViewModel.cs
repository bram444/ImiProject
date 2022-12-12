using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public abstract class BaseInfoViewModel<T> : FreshBasePageModel
    {
        protected IGameService GameService;
        protected T CurrentItem;

        public BaseInfoViewModel(IGameService gameService)
        {
            GameService = gameService;
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private string nameError;
        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                RaisePropertyChanged(nameof(NameError));
            }
        }

        private bool visableAdd;
        public bool VisableAdd
        {
            get => visableAdd;
            set
            {
                visableAdd = value;
                RaisePropertyChanged(nameof(VisableAdd));
            }
        }

        private bool visableCancel;
        public bool VisableCancel
        {
            get => visableCancel;
            set
            {
                visableCancel = value;
                RaisePropertyChanged(nameof(VisableCancel));
            }
        }

        private bool visableEdit;
        public bool VisableEdit
        {
            get => visableEdit;
            set
            {
                visableEdit = value;
                RaisePropertyChanged(nameof(VisableEdit));
            }
        }

        private bool visableDelete;
        public bool VisableDelete
        {
            get => visableDelete;
            set
            {
                visableDelete = value;
                RaisePropertyChanged(nameof(VisableDelete));
            }
        }

        private bool visableSave;
        public bool VisableSave
        {
            get => visableSave;
            set
            {
                visableSave = value;
                RaisePropertyChanged(nameof(VisableSave));
            }
        }

        protected IValidator InfoValidator;

        public abstract bool Validate(T validate);

        private bool enableEditData;
        public bool EnableEditData
        {
            get => enableEditData;
            set
            {
                enableEditData = value;
                RaisePropertyChanged(nameof(EnableEditData));
            }
        }

        public virtual ICommand DeleteCommand => new Command(() => {
            if(DeviceInfo.Platform == DevicePlatform.Android)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
            }
        });

        public virtual ICommand EditCommand => new Command(() => {
            SetEdit();
        });

        public virtual ICommand CancelCommand => new Command(() =>
        {
            SetRead();
        });

        public virtual void SetRead()
        {
            EnableEditData = false;

            VisableAdd = false;
            VisableCancel = false;
            VisableEdit = true;
            VisableDelete = true;
            VisableSave = false;
        }

        public virtual void SetAdd()
        {
            EnableEditData = true;

            VisableAdd = true;
            VisableCancel = false;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = false;
        }

        public virtual void SetEdit()
        {
            EnableEditData = true;
            VisableAdd = false;
            VisableCancel = true;
            VisableEdit = false;
            VisableDelete = false;
            VisableSave = true;
        }
    }
}