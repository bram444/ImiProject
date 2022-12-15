using FluentValidation;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public abstract class BaseListInfoViewModel<C, CS, LS>: BaseInfoViewModel<C, CS, LS>
        where C : BaseInfo, new()
        where CS : IBaseService<C>
    {
        public BaseListInfoViewModel(CS currentService, LS gameService, IValidator validator)
            : base(currentService, gameService, validator)
        { }

        #region Properties
        private bool enableGameList;
        public bool EnableGameList
        {
            get => enableGameList;
            set
            {
                enableGameList = value;
                RaisePropertyChanged(nameof(EnableGameList));
            }
        }

        private IEnumerable<GamesInfo> games;
        public IEnumerable<GamesInfo> Games
        {
            get => games;
            set
            {
                games = value;
                RaisePropertyChanged(nameof(Games));
            }
        }
        #endregion

        public override void Init(object initData)
        {
            if(initData != null)
            {
                CurrentItem = initData as C;

                SetRead();
            } else
            {
                SetAdd();
            }

            base.Init(initData);
        }

        public override void SetAdd()
        {
            EnableGameList = false;
            base.SetAdd();
        }

        public override void SetRead()
        {
            EnableGameList = Games.Count() != 0;

            base.SetRead();
        }
    }
}