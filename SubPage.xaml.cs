using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;


namespace MiniKi
{
    public partial class SubPage : ContentPage
    {
        //(ok)
        //public SubPage(int pageno)
        //{
        //    InitializeComponent();
        //    if( pageno == 0)
        //    {
        //        this.BackgroundColor = Color.White;
        //    }
        //    if (pageno == 1)
        //    {
        //        this.BackgroundColor = Color.DarkBlue;
        //    }
        //}

        //List<int> m = new List<int>();

        public SubPage(int pageno)
        {
            InitializeComponent();

            //(copied from sample soruce, 2021/08/20)
            ApplicationHelper.MainGaussianBlurView = contentView;

            //ItemPopup.Instance.BlurView = contentView;

            var MenuItems = new ObservableCollection<MenuItem>();
            //for (int j = 0; j < GroupPool[selectIndex].menu.Length; j++)
            //{
            //    var name = GroupPool[selectIndex].menu[j].name;
            //    var res = GroupPool[selectIndex].menu[j].res;
            //    var price = GroupPool[selectIndex].menu[j].price;
            //    MenuItems.Add(new MenuItem(0, j, name, res, price, "This is a short description of product. This is a short description of product. "));
            //}

            //-------------------------------------
            // mock data for testing(추후 제거)
            //-------------------------------------

            if(pageno == 0)
            {
                List<(string name, string res, string price)> menuList = new List<(string name, string res, string price)>()
                {
                    ("Espresso", "espresso.png", "1.50"),
                    ("Americano", "americano.png", "1.90"),
                    ("Flat white", "flat_white.png", "2.50"),
                    ("Cappuccino", "cappuccino.png", "3.20"),
                    ("CaffeLatte", "llatte.png", "4.00"),
                };
                for (int ix = 0; ix < menuList.Count; ix++)
                {
                    var name  = menuList[ix].name;
                    var res   = menuList[ix].res;
                    var price = menuList[ix].price;

                    MenuItems.Add(new MenuItem(0, ix, name, res, price, "This is a short description of product. This is a short description of product. "));
                }
            }
            else if(pageno == 1)
            {
                List<(string name, string res, string price)> menuList = new List<(string name, string res, string price)>()
                {
                    ("Black tea", "black_tea.png", "3.00"),
                    ("English breakfast", "english_breakfast.png", "3.00"),
                    ("Yasmine Green Tea", "green_tea.png", "3.00"),
                    ("Roiboos", "roibos_tea.png", "3.00")
                };
                for (int ix = 0; ix < menuList.Count; ix++)
                {
                    var name  = menuList[ix].name;
                    var res   = menuList[ix].res;
                    var price = menuList[ix].price;

                    MenuItems.Add(new MenuItem(0, ix, name, res, price, "This is a short description of product. This is a short description of product. "));
                }
            }

            CollectionView colView = new CollectionView()
            {
                HideScrollbar = false,

                ItemsSource = MenuItems,
                ItemsLayouter = new GridLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    //return new ItemView();
                    
                    var item = new ItemView(0.2f);
                    item.NameLabel.SetBinding(TextLabel.TextProperty, "NameLabel");
                    item.PriceLabel.SetBinding(TextLabel.TextProperty, "PriceLabel");
                    item.Image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                    return item;


                }),
                //(del by hch, 2021/08/19)
                //GroupHeaderTemplate = new DataTemplate(() =>
                //{
                //    DefaultTitleItem group = new DefaultTitleItem();
                //    group.BackgroundColor = Tizen.NUI.Color.Transparent;
                //    group.WidthSpecification = LayoutParamPolicies.MatchParent;

                //    group.Label.TextColor = new Tizen.NUI.Color("#7474FF");
                //    group.Label.PixelSize = 20;
                //    group.Label.SetBinding(TextLabel.TextProperty, "Title");
                //    group.Label.HeightSpecification = 60;
                //    group.Label.HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin;

                //    return group;
                //}),
                IsGrouped = false,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                SelectionMode = ItemSelectionMode.Single,
                Weight = 0.9f,
            };
            container.Add(colView);
        }

    }
}
