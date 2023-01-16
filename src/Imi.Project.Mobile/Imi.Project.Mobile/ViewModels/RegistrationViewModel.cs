using FreshMvvm;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class RegistrationViewModel: FreshBasePageModel
    {
        private readonly IAuthenticationService _authenticationService;

        public RegistrationViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private string userName = "";
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
                RegisterError = null;
                RaisePropertyChanged(nameof(UserName));
            }
        }

        private string firstName = "";
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                RegisterError = null;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        private string lastName = "";
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
                RegisterError = null;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        private string email = "";
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                RegisterError = null;
                RaisePropertyChanged(nameof(Email));
            }
        }

        private string password = "";
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                RegisterError = null;
                RaisePropertyChanged(nameof(Password));
            }
        }

        private string passwordConfirm = "";
        public string PasswordConfirm
        {
            get
            {
                return passwordConfirm;
            }

            set
            {
                passwordConfirm = value;
                RegisterError = null;
                RaisePropertyChanged(nameof(PasswordConfirm));
            }
        }

        private bool isNotLoading = true;
        public bool IsNotLoading
        {
            get
            {
                return isNotLoading;
            }

            set
            {
                isNotLoading = value;
                RaisePropertyChanged(nameof(IsNotLoading));
            }
        }

        private string registerError = "";
        public string RegisterError
        {
            get
            {
                return registerError;
            }

            set
            {
                registerError = value;
                RaisePropertyChanged(nameof(RegisterError));
            }
        }

        private bool terms = false;
        public bool Terms
        {
            get
            {
                return terms;
            }

            set
            {
                terms = value;
                RegisterError = null;
                RaisePropertyChanged(nameof(Terms));
            }
        }

        public DateTime MaxDate = DateTime.Now;

        private DateTime bithday = DateTime.Now;
        public DateTime BirthDay
        {
            get
            {
                return bithday;
            }

            set
            {
                bithday = value;
                RegisterError = null;
                RaisePropertyChanged(nameof(BirthDay));
            }
        }

        public ICommand Register
        {
            get
            {
                return new Command(async () =>
                {

                    RegistrationInfo registration = new RegistrationInfo
                    {
                        Password = Password,
                        UserName = UserName,
                        ApprovedTerms = Terms,
                        BirthDay = BirthDay,
                        ConfirmPassword = PasswordConfirm,
                        Email = Email,
                        FirstName = FirstName,
                        LastName = LastName

                    };

                    IsNotLoading = false;
                    TokenResponse tokenResponse = await _authenticationService.Registration(registration);
                    if(tokenResponse.IsSuccess)
                    {
                        await CoreMethods.PopPageModel(tokenResponse.Token, false, true);
                    } else
                    {

                        RegisterError = string.Join(System.Environment.NewLine, tokenResponse.Messages);
                    }

                    IsNotLoading = true;
                });
            }
        }
    }
}
