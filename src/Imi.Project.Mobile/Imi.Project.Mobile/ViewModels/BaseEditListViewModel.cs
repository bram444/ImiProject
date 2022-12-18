using FluentValidation;
using Imi.Project.Mobile.Domain.Model;
using Imi.Project.Mobile.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public abstract class BaseEditListViewModel<C, LI, CS, LS>: BaseInfoViewModel<C, CS, LS>
        where C : BaseInfo, new()
        where LI : BaseInfo, new()
        where CS : IBaseService<C>
        where LS : IBaseService<LI>
    {
        public BaseEditListViewModel(CS currentService, LS listService, IValidator validator)
            : base(currentService, listService, validator)
        { }

        #region Properties
        private string textPicker;
        public string TextPicker
        {
            get => textPicker;
            set
            {
                textPicker = value;
                RaisePropertyChanged(nameof(TextPicker));
            }
        }

        private string listError;
        public string ListError
        {
            get => listError;
            set
            {
                listError = value;
                RaisePropertyChanged(nameof(ListError));
            }
        }

        private bool createItem;
        public bool CreateItem
        {
            get => createItem;
            set
            {
                createItem = value;
                RaisePropertyChanged(nameof(CreateItem));
            }
        }

        private bool addListItem;
        public bool AddListItem
        {
            get => addListItem;
            set
            {
                addListItem = value;
                RaisePropertyChanged(nameof(AddListItem));
            }
        }

        private bool visibleList;
        public bool VisibleList
        {
            get => visibleList;
            set
            {
                visibleList = value;
                RaisePropertyChanged(nameof(VisibleList));
            }
        }

        private bool visibleAddList;
        public bool VisibleAddList
        {
            get => visibleAddList;
            set
            {
                visibleAddList = value;
                ColumnDelete = VisibleAddList ? 1 : 0;
                ColumnSpanDelete = VisibleAddList ? 1 : 2;
                RaisePropertyChanged(nameof(VisibleAddList));
            }
        }

        private bool visibleDeleteList;
        public bool VisibleDeleteList
        {
            get => visibleDeleteList;
            set
            {
                visibleDeleteList = value;
                ColumnSpanAdd = VisibleDeleteList ? 1 : 2;
                RaisePropertyChanged(nameof(VisibleDeleteList));
            }
        }

        private bool visibleSaveList;
        public bool VisibleSaveList
        {
            get => visibleSaveList;
            set
            {
                visibleSaveList = value;
                RaisePropertyChanged(nameof(VisibleSaveList));
            }
        }

        private int columnSpanAdd;
        public int ColumnSpanAdd
        {
            get => columnSpanAdd;
            set
            {
                columnSpanAdd = value;
                RaisePropertyChanged(nameof(ColumnSpanAdd));
            }
        }

        private int columnDelete;
        public int ColumnDelete
        {
            get => columnDelete;
            set
            {
                columnDelete = value;
                RaisePropertyChanged(nameof(ColumnDelete));
            }
        }

        private int columnSpanDelete;
        public int ColumnSpanDelete
        {
            get => columnSpanDelete;
            set
            {
                columnSpanDelete = value;
                RaisePropertyChanged(nameof(ColumnSpanDelete));
            }
        }

        private ObservableCollection<Guid> currentItemIdList;
        public ObservableCollection<Guid> CurrentItemIdList
        {
            get => currentItemIdList;
            set
            {
                currentItemIdList = value;
                RaisePropertyChanged(nameof(CurrentItemIdList));
            }
        }

        private ObservableCollection<LI> currentItemList;
        public ObservableCollection<LI> CurrentItemList
        {
            get => currentItemList;
            set
            {
                currentItemList = value;
                HeightList = currentItemList.Count() * 20;
                RaisePropertyChanged(nameof(CurrentItemList));
                RaisePropertyChanged(nameof(EnableList));
            }
        }

        private ObservableCollection<LI> pickListItem;
        public ObservableCollection<LI> PickListItem
        {
            get => pickListItem;
            set
            {
                pickListItem = new ObservableCollection<LI>(value);
                RaisePropertyChanged(nameof(PickListItem));
            }
        }

        private LI chosenListItem;
        public LI ChosenListItem
        {
            get => chosenListItem;
            set
            {
                chosenListItem = value;
                RaisePropertyChanged(nameof(ChosenListItem));
                ListError = string.Empty;
            }
        }

        private int heightList;
        public int HeightList
        {
            get => heightList;
            set
            {
                heightList = value;
                RaisePropertyChanged(nameof(HeightList));
            }
        }

        public bool EnableList => CurrentItemList.Any();

        public bool EnableAddListItem => Task.Run(async () => await ListService.GetAll()).Result.Count() != CurrentItemIdList.Count();
        #endregion

        public override void Init(object initData)
        {
            if(initData != null)
            {
                CurrentItem = initData as C;

                LoadState();
                SetRead();
            } else
            {
                SetAdd();
            }

            base.Init(initData);
        }

        public abstract void LoadState();

        protected void LoadList(List<LI> listItems)
        {
            foreach(LI item in Task.Run(async () => await ListService.GetAll()).Result)
            {
                listItems.Add(item);
            }

            CurrentItemList = new ObservableCollection<LI>(listItems.Where(item => CurrentItemIdList.Contains(item.Id)));
        }

        public override ICommand CancelCommand => new Command(() =>
        {
            LoadState();

            base.CancelCommand.Execute(null);
        });

        public virtual ICommand AddPickerItem => new Command((object item) =>
        {
            List<LI> list = item as List<LI>;

            foreach(LI listItem in Task.Run(async () => await ListService.GetAll()).Result)
            {
                if(!CurrentItemIdList.Contains(listItem.Id))
                {
                    list.Add(listItem);
                }
            }

            PickListItem = new ObservableCollection<LI>(list);

            ChosenListItem = list.First();

            AddListItem = true;
            VisibleList = true;
            VisableAdd = false;
            VisableSave = false;
            VisableCancel = false;
            VisibleAddList = false;
            VisibleDeleteList = false;
            VisibleSaveList = true;
        });

        public virtual ICommand DeletePickerItem => new Command((object item) =>
        {
            List<LI> list = item as List<LI>;

            foreach(LI listItem in Task.Run(async () => await ListService.GetAll()).Result)
            {
                if(CurrentItemIdList.Contains(listItem.Id))
                {
                    list.Add(listItem);
                }
            }

            PickListItem = new ObservableCollection<LI>(list);

            ChosenListItem = list.First();

            AddListItem = false;
            VisibleList = true;
            VisableAdd = false;
            VisableSave = false;
            VisableCancel = false;
            VisibleAddList = false;
            VisibleDeleteList = false;
            VisibleSaveList = true;
        });

        public ICommand SavePickerItem => new Command(() =>
        {
            if(ChosenListItem.Id != Guid.Empty)
            {
                ObservableCollection<LI> listItems = CurrentItemList;
                if(AddListItem)
                {
                    listItems.Add(ChosenListItem);
                    CurrentItemIdList.Add(ChosenListItem.Id);

                } else
                {
                    listItems.Remove(listItems.Where(item => item.Id == ChosenListItem.Id).Single());
                    CurrentItemIdList.Remove(ChosenListItem.Id);
                }

                CurrentItemList = new ObservableCollection<LI>(listItems.OrderBy(item => item.Id));

                if(CreateItem)
                {
                    VisableAdd = true;
                } else
                {
                    VisableCancel = true;
                    VisableSave = true;
                }

                VisibleList = false;
                VisibleSaveList = false;
                VisibleAddList = EnableAddListItem;
                VisibleDeleteList = EnableList;
            } else
            {
                ListError = "Pick a valid item";
            }
        });

        public ICommand CancelPickerItem => new Command(() =>
        {
            VisibleList = false;
            VisibleSaveList = false;
            VisibleAddList = EnableAddListItem;
            VisibleDeleteList = EnableList;

            if(CreateItem)
            {
                VisableAdd = true;
            } else
            {
                VisableCancel = true;
                VisableSave = true;
            }
        });

        public override void SetAdd()
        {
            CurrentItemIdList = new ObservableCollection<Guid>();
            CurrentItemList = new ObservableCollection<LI>();
            ChosenListItem = new LI();

            CreateItem = true;
            VisibleList = false;
            VisibleSaveList = false;
            VisibleDeleteList = EnableList;
            VisibleAddList = EnableAddListItem;

            base.SetAdd();
        }

        public override void SetRead()
        {
            CreateItem = false;
            VisibleList = false;
            VisibleSaveList = false;
            VisibleAddList = false;
            VisibleDeleteList = false;

            base.SetRead();
        }

        public override void SetEdit()
        {
            CreateItem = false;
            VisibleList = false;
            VisibleSaveList = false;
            VisibleAddList = EnableAddListItem;
            VisibleDeleteList = EnableList;

            base.SetEdit();
        }
    }
}