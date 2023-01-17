using FluentValidation;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace Imi.Project.Mobile.ViewModels
{
    public abstract class BaseListInfoViewModel<C, CS, LS, N, U>: BaseInfoViewModel<C, CS, LS, N, U>
        where C : BaseInfo, new()
        where CS : IBaseService<C, N, U>
        where N : class, new()
        where U : BaseInfo, new()
    {
        public BaseListInfoViewModel(CS currentService, LS gameService, IValidator updateValidator, IValidator newValidator)
            : base(currentService, gameService, updateValidator, newValidator)
        { }

        #region Properties
        private bool enableGameList;
        public bool EnableGameList
        {
            get
            {
                return enableGameList;
            }

            set
            {
                enableGameList = value;
                RaisePropertyChanged(nameof(EnableGameList));
            }
        }

        private IEnumerable<GamesInfo> games;
        public IEnumerable<GamesInfo> Games
        {
            get
            {
                return games;
            }

            set
            {
                games = value;
                RaisePropertyChanged(nameof(Games));
            }
        }
        #endregion

        public override void InitAsync(object initData)
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