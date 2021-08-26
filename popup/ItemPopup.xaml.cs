using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace MiniKi
{
    public partial class ItemPopup : DialogPage
    {
        private static ItemPopup instance;
        private bool isDrinkOptionCreated = false;
        private bool isExtraOptionCreated = false;

        private MenuItemView selectItem;
        private int sizeOption = 0;

        public ItemPopup()
        {
            InitializeComponent();
            ResetOptions();
            RemovedFromWindow += ItemPopup_RemovedFromWindow;
            orderButton.TransitionOptions = null;

            //Binding Data
            nameLabel.SetBinding(TextLabel.TextProperty, "NameLabel");
            priceLabel.SetBinding(TextLabel.TextProperty, "PriceLabel");
            descriptionLabel.SetBinding(TextLabel.TextProperty, "Description");
            MainImage.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
        }

        public static ItemPopup Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemPopup();
                    instance.Scrim.Size = new Size(Window.Instance.Size.Height, Window.Instance.Size.Width);
                }
                return instance;
            }
        }

        public void ResetOptions()
        {
            MainRoot.SizeHeight = 380;
            imageContainer.SizeHeight = 650;

            AdditonalOptionView.HeightSpecification = LayoutParamPolicies.WrapContent;

            drinkOptionView.Unparent();
            extrasView.Unparent();

            if (selectItem != null)
            {
                selectItem.MainButton.IsSelected = false;
                selectItem = (drinkOptionView.Children[0] as MenuItemView);
                selectItem.MainButton.IsSelected = true;
            }

            foreach (var item in extraLayoutView.Children)
            {
                if (item is MenuItemView menuItem)
                {
                    menuItem.MainButton.IsSelected = false;
                }
            }
            //Tizen.Log.Info("MiniKi", "ResetOptions() called");
        }

        public void AddDrinkOptions()
        {
            MainRoot.SizeHeight = 600;
            imageContainer.SizeHeight = 900;

            AdditonalOptionView.HeightSpecification = 480;
            AdditonalOptionView.Add(drinkOptionView);
            if (!isDrinkOptionCreated)
            {
                (string name, string res, string price)[] resPool = {
                    ("Small", "cup190.png", "1.10"),
                    ("Medium", "cup270.png", "1.20"),
                    ("Large", "cup370.png", "1.40"),
                };
                for (int i = 0; i < 3; i++)
                {
                    MenuItemView itemView = new MenuItemView()
                    {
                        Name = $"{i}",
                        Size = new Size(180, 180),
                        Margin = new Extents(5, 5, 0, 0),
                        PriceLabel = resPool[i].price,
                        NameLabel = resPool[i].name,
                        ItemImageUrl = $"{ApplicationHelper.ResoucePath}/images/cup/{resPool[i].res}",
                    };
                    itemView.ItemClicked += ItemView_ItemClicked;
                    itemView.MainButton.IsSelectable = true;
                    if (i == 0)
                    {
                        selectItem = itemView;
                        itemView.MainButton.IsSelected = true;
                    }
                    drinkOptionView.Add(itemView);
                }
                isDrinkOptionCreated = true;
            }
        }

        public void AddExtraOption()
        {
            MainRoot.SizeHeight = 950;
            imageContainer.SizeHeight = 1230;

            AdditonalOptionView.HeightSpecification = 750;
            AdditonalOptionView.Add(extrasView);

            if (!isExtraOptionCreated)
            {
                (string name, string res, string price)[] resPool = GetCoffeeItems();

                for (int i = 0; i < resPool.Length; i++)
                {
                    MenuItemView itemView = new MenuItemView()
                    {
                        Size = new Size(125, 125),
                        PriceLabel = resPool[i].price,
                        NameLabel = resPool[i].name,
                        ItemImageUrl = $"{ApplicationHelper.ResoucePath}/images/coffee_items/{resPool[i].res}",
                    };
                    itemView.MainButton.IsSelectable = true;
                    itemView.MainButton.Icon.Size = new Size(80, 80);
                    itemView.SetSmallItem();

                    extraLayoutView.Add(itemView);
                }
                isExtraOptionCreated = true;
            }

            //Temporary Fix
            if (nameLabel.Text == "Yasmine Green Tea" ||
                nameLabel.Text == "Roiboos")
            {
                foreach (var item in extraLayoutView.Children)
                {
                    if (item is MenuItemView menuItem)
                    {
                        if (menuItem.NameLabel == "Sugar"
                            || menuItem.NameLabel == "Dairy milk")
                        {
                            menuItem.Show();
                        }
                        else
                        {
                            menuItem.Hide();
                        }
                    }
                }
            }
            else
            {
                foreach (var item in extraLayoutView.Children)
                {
                    if (item is MenuItemView menuItem)
                    {
                        menuItem.Show();
                    }
                }
            }

        }

        private void ItemView_ItemClicked(object sender, ClickedEventArgs e)
        {
            if (sender is MenuItemView item)
            {
                if (item == selectItem)
                {
                    selectItem.MainButton.IsSelected = true;
                    return;
                }
                selectItem.MainButton.IsSelected = false;
                sizeOption = int.Parse(item.Name);
                selectItem = item;
            }
        }

        public void AddCakeOptions()
        {

        }

        private (string name, string res, string price)[] GetCoffeeItems()
        {
            (string name, string res, string price)[] resPool = {
                    ("Sugar", "sugar.png", "0.20"),
                    ("Dairy milk", "milk.png", "0.50"),
                    ("Extra espresso", "espresso.png", "1.00"),
                    ("Vanilla syrup", "vanilla.png", "0.50"),
                    ("Nugat syrup", "nugat.png", "0.50"),
                    ("Macadamia syrup", "macadamia.png", "0.50"),
                };
            return resPool;
        }

        public void SetItemTag(string mainTag, string imageTag)
        {
            MainTag = mainTag;
            ImageTag = imageTag;
        }

        public string MainTag
        {
            set
            {
                MainRoot.TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = value
                };
            }
        }

        public string ImageTag
        {
            set
            {
                MainImage.TransitionOptions = new TransitionOptions()
                {
                    TransitionTag = value
                };
            }
        }

        private bool MainRoot_TouchEvent(object source, TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                Navigator.PopWithTransition();
                //Navigator.Pop();  // hch
            }
            return false;
        }

        // orderButton 버튼 클릭.
        private void Button_Clicked(object sender, ClickedEventArgs e)
        {
            Navigator.PopWithTransition();
            
            OrderManager.Instance.GallerySource.Add(BindingContext as MenuItem);
        }

        private void ItemPopup_RemovedFromWindow(object sender, System.EventArgs e)
        {
            Tizen.Log.Info("MiniKi", "ItemPopup_RemovedFromWindow() called");
            ApplicationHelper.DeactivateBlur();
            ResetOptions();
        }

        //(add by hch, 2021/08/20, for test)
        public enum MenuType
        {
            HOT_DRINK = 0,
            COLD_DRINK = 1,
            DESSERTS = 2,
            CAKES = 3,
        }

        public void ShowPopup()
        {
            if (BindingContext is MenuItem context)
            {
                //(del by hch, 2021/08/20)
                //switch (context.MenuType)
                //{
                //    case Resources.MenuType.HOT_DRINK:
                //        AddDrinkOptions();
                //        AddExtraOption();
                //        break;
                //    case Resources.MenuType.COLD_DRINK:
                //        AddDrinkOptions();
                //        break;
                //    case Resources.MenuType.DESSERTS:
                //        break;
                //    case Resources.MenuType.CAKES:
                //        AddCakeOptions();
                //        break;
                //    default:
                //        break;
                //}

                switch ((MenuType)context.MenuType)
                {
                    case MenuType.HOT_DRINK:
                        AddDrinkOptions();
                        AddExtraOption();
                        break;
                    case MenuType.COLD_DRINK:
                        AddDrinkOptions();
                        break;
                    case MenuType.DESSERTS:
                        break;
                    case MenuType.CAKES:
                        AddCakeOptions();
                        break;
                    default:
                        break;
                }
               
            }

            //NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(view);
            NUIApplication.GetDefaultWindow().GetDefaultNavigator().PushWithTransition(this);
            //NUIApplication.GetDefaultWindow().GetDefaultNavigator().Push(this);
            //this.Navigator.PushWithTransition(this); // by hch
            ApplicationHelper.ActivateBlur();
        }
    }
}
