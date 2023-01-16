using FluentValidation;
using FreshMvvm;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public abstract class BaseInfoViewModel<C, CS, LS, N, U>: FreshBasePageModel
                where CS : IBaseService<C, N, U>
                where C : BaseInfo, new()
                where N : class, new()
                where U : BaseInfo, new()
    {
        protected CS CurrentService;
        protected LS ListService;
        protected IValidator UpdateValidator;
        protected IValidator NewValidator;
        protected C CurrentItem;
        protected N NewItem;
        protected U UpdateItem;

        public BaseInfoViewModel(CS currentService, LS listService, IValidator validatorUpdate, IValidator validatorNew)
        {
            CurrentService = currentService;
            ListService = listService;
            UpdateValidator = validatorUpdate;
            NewValidator = validatorNew;
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                ErrorAPI = null;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                NameError = null;
                ErrorAPI = null;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private string nameError;
        public string NameError
        {
            get
            {
                return nameError;
            }

            set
            {
                nameError = value;
                ErrorAPI = null;
                RaisePropertyChanged(nameof(NameError));
            }
        }

        private bool visableAdd;
        public bool VisableAdd
        {
            get
            {
                return visableAdd;
            }

            set
            {
                visableAdd = value;
                RaisePropertyChanged(nameof(VisableAdd));
            }
        }

        private bool visableCancel;
        public bool VisableCancel
        {
            get
            {
                return visableCancel;
            }

            set
            {
                visableCancel = value;
                RaisePropertyChanged(nameof(VisableCancel));
            }
        }

        private bool visableEdit;
        public bool VisableEdit
        {
            get
            {
                return visableEdit;
            }

            set
            {
                visableEdit = value;
                RaisePropertyChanged(nameof(VisableEdit));
            }
        }

        private bool visableDelete;
        public bool VisableDelete
        {
            get
            {
                return visableDelete;
            }

            set
            {
                visableDelete = value;
                RaisePropertyChanged(nameof(VisableDelete));
            }
        }

        private bool visableSave;
        public bool VisableSave
        {
            get
            {
                return visableSave;
            }

            set
            {
                visableSave = value;
                RaisePropertyChanged(nameof(VisableSave));
            }
        }

        private bool enableEditData;
        public bool EnableEditData
        {
            get
            {
                return enableEditData;
            }

            set
            {
                enableEditData = value;
                RaisePropertyChanged(nameof(EnableEditData));
            }
        }

        public virtual ICommand AddCommand
        {
            get
            {
                return new Command(() =>
                {
                    if(Name == null)
                    {
                        Name = string.Empty;
                    }
                });
            }
        }

        public virtual ICommand EditCommand
        {
            get
            {
                return new Command(() =>
                {
                    SetEdit();
                });
            }
        }

        public virtual ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if(DeviceInfo.Platform == DevicePlatform.Android)
                    {
                        Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
                    }

                    await CurrentService.Delete(CurrentItem.Id);
                    await CoreMethods.PopPageModel(new C(), false, true);
                });
            }
        }

        public abstract ICommand SaveCommand { get; }

        public virtual ICommand CancelCommand
        {
            get
            {
                return new Command(() =>
                {
                    SetRead();
                });
            }
        }

        public abstract bool Validate(N validate);
        public abstract bool Validate(U validate);

        private string errorAPI;
        public string ErrorAPI
        {
            get
            {
                return errorAPI;
            }

            set
            {
                errorAPI = value;
                RaisePropertyChanged(nameof(ErrorAPI));
            }
        }

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

        protected async Task<ApiResponse<C>> AddItem(N item)
        {
            ApiResponse<C> apiResponse = new ApiResponse<C>() { IsSuccess = false };
            if(Validate(item))
            {
                apiResponse = await CurrentService.Add(item);
                if(apiResponse.IsSuccess)
                {
                    await CoreMethods.PopPageModel(item, false, true);
                }
            }
            return apiResponse;
        }

        protected async Task<ApiResponse<C>> SaveItem(U item)
        {
            ApiResponse<C> apiResponse = new ApiResponse<C>() { IsSuccess = false };
            if(Validate(item))
            {
                apiResponse = await CurrentService.Update(item);
                if(apiResponse.IsSuccess)
                {
                    await CoreMethods.PopPageModel(item, false, true);
                }
            }

            return apiResponse;
        }
    }
}