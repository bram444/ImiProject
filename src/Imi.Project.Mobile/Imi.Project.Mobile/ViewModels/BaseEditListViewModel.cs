using FluentValidation;
using Imi.Project.Mobile.Domain.Interface;
using Imi.Project.Mobile.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public abstract class BaseEditListViewModel<C, LI, CS, LS, N, U, LIN, LIU>: BaseInfoViewModel<C, CS, LS, N, U>
        where C : BaseInfo, new()
        where N : class, new()
        where U : BaseInfo, new()
        where LI : BaseInfo, new()
        where LIN : class, new()
        where LIU : BaseInfo, new()
        where CS : IBaseService<C, N, U>
        where LS : IBaseService<LI, LIN, LIU>
    {
        public BaseEditListViewModel(CS currentService, LS listService, IValidator validatorUpdate, IValidator validationNew)
            : base(currentService, listService, validatorUpdate, validationNew)
        { }

        #region Properties
        private string textPicker;
        public string TextPicker
        {
            get
            {
                return textPicker;
            }

            set
            {
                textPicker = value;
                RaisePropertyChanged(nameof(TextPicker));
            }
        }

        private string listError;
        public string ListError
        {
            get
            {
                return listError;
            }

            set
            {
                listError = value;
                RaisePropertyChanged(nameof(ListError));
            }
        }

        private bool createItem;
        public bool CreateItem
        {
            get
            {
                return createItem;
            }

            set
            {
                createItem = value;
                RaisePropertyChanged(nameof(CreateItem));
            }
        }

        private bool addListItem;
        public bool AddListItem
        {
            get
            {
                return addListItem;
            }

            set
            {
                addListItem = value;
                RaisePropertyChanged(nameof(AddListItem));
            }
        }

        private bool visibleList;
        public bool VisibleList
        {
            get
            {
                return visibleList;
            }

            set
            {
                visibleList = value;
                RaisePropertyChanged(nameof(VisibleList));
            }
        }

        private bool visibleAddList;
        public bool VisibleAddList
        {
            get
            {
                return visibleAddList;
            }

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
            get
            {
                return visibleDeleteList;
            }

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
            get
            {
                return visibleSaveList;
            }

            set
            {
                visibleSaveList = value;
                RaisePropertyChanged(nameof(VisibleSaveList));
            }
        }

        private int columnSpanAdd;
        public int ColumnSpanAdd
        {
            get
            {
                return columnSpanAdd;
            }

            set
            {
                columnSpanAdd = value;
                RaisePropertyChanged(nameof(ColumnSpanAdd));
            }
        }

        private int columnDelete;
        public int ColumnDelete
        {
            get
            {
                return columnDelete;
            }

            set
            {
                columnDelete = value;
                RaisePropertyChanged(nameof(ColumnDelete));
            }
        }

        private int columnSpanDelete;
        public int ColumnSpanDelete
        {
            get
            {
                return columnSpanDelete;
            }

            set
            {
                columnSpanDelete = value;
                RaisePropertyChanged(nameof(ColumnSpanDelete));
            }
        }

        private ObservableCollection<Guid> currentItemIdList;
        public ObservableCollection<Guid> CurrentItemIdList
        {
            get
            {
                return currentItemIdList;
            }

            set
            {
                currentItemIdList = value;
                RaisePropertyChanged(nameof(CurrentItemIdList));
            }
        }

        private ObservableCollection<LI> currentItemList;
        public ObservableCollection<LI> CurrentItemList
        {
            get
            {
                return currentItemList;
            }

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
            get
            {
                return pickListItem;
            }

            set
            {
                pickListItem = new ObservableCollection<LI>(value);
                RaisePropertyChanged(nameof(PickListItem));
            }
        }

        private LI chosenListItem;
        public LI ChosenListItem
        {
            get
            {
                return chosenListItem;
            }

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
            get
            {
                return heightList;
            }

            set
            {
                heightList = value;
                RaisePropertyChanged(nameof(HeightList));
            }
        }

        public bool EnableList
        {
            get
            {
                return CurrentItemList.Any();
            }
        }

        public bool EnableAddListItem
        {
            get
            {
                return Task.Run(async () => await ListService.GetAll()).Result.Count() != CurrentItemIdList.Count();
            }
        }
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

        public override ICommand CancelCommand
        {
            get
            {
                return new Command(() =>
                {
                    LoadState();

                    base.CancelCommand.Execute(null);
                });
            }
        }

        public virtual ICommand AddPickerItem
        {
            get
            {
                return new Command((object item) =>
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
            }
        }

        public virtual ICommand DeletePickerItem
        {
            get
            {
                return new Command((object item) =>
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
            }
        }

        public ICommand SavePickerItem
        {
            get
            {
                return new Command(() =>
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
            }
        }

        public ICommand CancelPickerItem
        {
            get
            {
                return new Command(() =>
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
            }
        }

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