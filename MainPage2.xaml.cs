using System.Collections.Generic;
using Tizen.Applications;
using System.Collections.ObjectModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace MiniKi
{
    public partial class MainPage2 : ContentPage
    {
        private int totalCount = 0;
        private int index = 0;

        public MainPage2()
        {
            InitializeComponent();
            gradientBG.AddVisual("Linear_Gradient", new MyGradientVisual());
            LoadAllResources();
            // add orderlist page, 2021/08/25
            orderArea.Add(new OrderListPage());
        }

        private void LoadAllResources()
        {
            //(ori, 2021/08/25)
            //System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo($"{Application.Current.DirectoryInfo.Resource}/images/poster/");

            //foreach (System.IO.FileInfo File in directoryInfo.GetFiles())
            //{
            //    if (File.Extension.ToLower().CompareTo(".png") == 0)
            //    {
            //        ImageView imgView = new ImageView()
            //        {
            //            ResourceUrl = File.FullName,
            //            Size = new Size(600, 900),
            //        };
            //        myScroll.Add(imgView);
            //        totalCount++;
            //    }
            //    //@ pagination.IndicatorCount = totalCount;
            //}
            //(chg)
            var MenuItems = new ObservableCollection<MenuItem>();
            ObservableCollection<ObservableCollection<MenuItem>> MenuItemsGroup = new ObservableCollection<ObservableCollection<MenuItem>>();
        
            List<(string name, string res, string price)> menuList = new List<(string name, string res, string price)>()
                {
                    ("Americano", "americano.png", "1.90"),
                    ("Espresso", "espresso.png", "1.50"),
                    ("Flat white", "flat_white.png", "2.50"),
                    ("Cappuccino", "cappuccino.png", "3.20"),
                    ("CaffeLatte", "llatte.png", "4.00"),
                };
            MenuItemsGroup.Clear();
            ObservableCollection<MenuItem> tempList;
            MenuItem tempMenu;
            int ix;
            for (ix = 0; ix < menuList.Count; ix++)
            {
                string name = menuList[ix].name;
                string res = menuList[ix].res;
                string price = menuList[ix].price;

                tempList = new ObservableCollection<MenuItem>();
                tempList.Clear();

                tempMenu = new MenuItem(0, ix, name, res, price, "This is a short description of product. This is a short description of product. ");
                tempList.Add(tempMenu);
                
                //MenuItems.Add(new MenuItem(0, ix, name, res, price, "This is a short description of product. This is a short description of product. "));
                MenuItemsGroup.Add(tempList);
            }

            myScroll.RemoveAll();

            ObservableCollection<MenuItem> tmpGrp;
            //for(int ix = 0; ix < menuList.Count; ix++)
            for (ix = 0; ix < MenuItemsGroup.Count; ix++)
            //for (ix = 0; ix < 2; ix++)
            {
                tmpGrp = MenuItemsGroup[ix];
                CollectionView colView = new CollectionView()
                {
                    HideScrollbar = false,

                    ItemsSource = tmpGrp,
                    ItemsLayouter = new GridLayouter(),
                    ItemTemplate = new DataTemplate(() =>
                    {
                        //return new ItemView();

                        var item = new ItemView(0.5f);
                        item.NameLabel.SetBinding(TextLabel.TextProperty, "NameLabel");
                        item.PriceLabel.SetBinding(TextLabel.TextProperty, "PriceLabel");
                        item.Image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                        return item;
                    }),

                    IsGrouped = false,
                    ScrollingDirection = ScrollableBase.Direction.Vertical,
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    SelectionMode = ItemSelectionMode.Single,
                    Weight = 0.9f,
                };
                //####################################################
                // ScrollView에 CollectionView를 직접 올릴 수 없어서
                // 임시 View를 생성하고 여기에 CollectionView를 올려 
                // 다시 임시 View를 ScrollView에 올림.(2021/08/25)
                View stubView = new View()
                {
                    //WidthSpecification = 600,
                    //HeightSpecification = 1000,

                    //PivotPoint = Position.PivotPointCenter,
                    //ParentOrigin = Position.ParentOriginCenter,
                    //PositionUsesPivotPoint = true,

                    //Size = new Size(600, 1000),
                    //WidthSpecification = LayoutParamPolicies.MatchParent,
                    //HeightSpecification = LayoutParamPolicies.MatchParent,
                    Size = new Size(600, 1000)
                };
                stubView.Add(colView);
                myScroll.Add(stubView);
                totalCount++;
            }
  
            /**
            CollectionView colView = new CollectionView()
                {
                    HideScrollbar = false,

                    ItemsSource = MenuItemsGroup[0],
                    ItemsLayouter = new GridLayouter(),
                    ItemTemplate = new DataTemplate(() =>
                    {
                        //return new ItemView();

                        var item = new ItemView(0.5f);
                        item.NameLabel.SetBinding(TextLabel.TextProperty, "NameLabel");
                        item.PriceLabel.SetBinding(TextLabel.TextProperty, "PriceLabel");
                        item.Image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                        return item;
                    }),

                    IsGrouped = false,
                    ScrollingDirection = ScrollableBase.Direction.Vertical,
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    SelectionMode = ItemSelectionMode.Single,
                    Weight = 0.9f,
                };
                // ScrollView에 CollectionView를 직접 올릴 수 없어서
                // 임시 View를 생성하고 여기에 CollectionView를 올려 
                // 다시 임시 View를 ScrollView에 올림.(2021/08/25)
                View stubView = new View()
                {
                    WidthSpecification = 600,
                    HeightSpecification = 1000,
                    PivotPoint = Position.PivotPointCenter,
                    ParentOrigin = Position.ParentOriginCenter,
                    PositionUsesPivotPoint = true,
                };
                stubView.Add(colView);
                //var item = new ItemView();
                //item.NameLabel.SetBinding(TextLabel.TextProperty, "NameLabel");
                //item.PriceLabel.SetBinding(TextLabel.TextProperty, "PriceLabel");
                //item.Image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                myScroll.Add(stubView);
                totalCount++;
            /////////////////////////////////////////////////////////
                colView = new CollectionView()
                {
                    HideScrollbar = false,

                    ItemsSource = MenuItemsGroup[1],
                    ItemsLayouter = new GridLayouter(),
                    ItemTemplate = new DataTemplate(() =>
                    {
                        //return new ItemView();

                        var item = new ItemView(0.5f);
                        item.NameLabel.SetBinding(TextLabel.TextProperty, "NameLabel");
                        item.PriceLabel.SetBinding(TextLabel.TextProperty, "PriceLabel");
                        item.Image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                        return item;
                    }),

                    IsGrouped = false,
                    ScrollingDirection = ScrollableBase.Direction.Vertical,
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    SelectionMode = ItemSelectionMode.Single,
                    Weight = 0.9f,
                };
                // ScrollView에 CollectionView를 직접 올릴 수 없어서
                // 임시 View를 생성하고 여기에 CollectionView를 올려 
                // 다시 임시 View를 ScrollView에 올림.(2021/08/25)
                stubView = new View()
                {
                    WidthSpecification = 600,
                    HeightSpecification = 1000,
                    PivotPoint = Position.PivotPointCenter,
                    ParentOrigin = Position.ParentOriginCenter,
                    PositionUsesPivotPoint = true,
                };
                stubView.Add(colView);
                myScroll.Add(stubView);
            //}
            totalCount++;
            ***/
        }

        private void LeftButton_Clicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            if (index - 1 >= 0)
            {
                index--;

                myScroll.ScrollToIndex(index);
                //@ pagination.SelectedIndex = index;
                
            }

        }

        private void RightButton_Clicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            //Tizen.Log.Info("MiniKi", "Index ====" + this.index);
            if (index + 1 < totalCount)
            {
                index++;
                myScroll.ScrollToIndex(index);
                //@ pagination.SelectedIndex = index;
            }
        }

        private void myScroll_ScrollAnimationEnded(object sender, Tizen.NUI.Components.ScrollEventArgs e)
        {
            //@
            //Animation ani = new Animation(600);
            //ani.AnimateTo(bottomView, "Opacity", 0.7f);
            //ani.Play();
        }

        private void myScroll_ScrollAnimationStarted(object sender, Tizen.NUI.Components.ScrollEventArgs e)
        {
            //@
            //bottomView.Opacity = 0.0f;
        }

        private void Button_Clicked(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            //(del for build)
            //Window.Instance.GetDefaultLayer().Add(new MyPopup());
            //this.Activate();
        }

        // [주문하기]버튼
        private void Button_Clicked_1(object sender, Tizen.NUI.Components.ClickedEventArgs e)
        {
            //(del for build)
            //Window.Instance.GetDefaultLayer().Add(new VideoPopup());
            //this.Activate();

            //OrderManager.Instance.GallerySource.Add(BindingContext as MenuItem);
            //Tizen.Log.Info("MiniKi", "count ====" + (int)myScroll.ContentContainer.GetChildCount());

            View currTmpView = myScroll.GetChildAt((uint)this.index);
            CollectionView currCollView = (CollectionView)currTmpView.GetChildAt((uint)0);
            ItemView currItemView = (ItemView)currCollView.GetChildAt(0);
            var temp = currItemView.BindingContext;

            ItemPopup.Instance.BindingContext = temp;
            //ItemPopup.Instance.SetItemTag(btnTag, imgTag);
            ItemPopup.Instance.ShowPopup();
        }
    }
}
