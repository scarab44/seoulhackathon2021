using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace MiniKi
{
    public partial class MainPage1 : ContentPage
    {
        private const int MAX_PAGES_CNT = 2;
        private TableView tableView;
        //List<MenuEachPage> layerList = new List<MenuEachPage>();
        List<MenuEachPage> MenuList = new List<MenuEachPage>();
        MenuEachPage currentPage = null;
        OrderListPage tempPage = null;

        public MainPage1()
        {
            InitializeComponent();
            //MakeTableView();
            //MakeTabControl();

            MenuEachPage menuEachPage;
            Layer layer;
            for (int ix = 0; ix < MAX_PAGES_CNT; ix++)
            {
                //layer = new Layer();
                menuEachPage = new MenuEachPage(ix);
                MenuList.Add(menuEachPage);
                //layerList.Add(layer);
            }
            contentArea.Add(MenuList[0]);
            //contentArea.Add(MenuList[1]);
            currentPage = MenuList[0];

            // add orderlist page, 2021/08/21
            //orderArea.Add(new OrderListPage(this));
            tempPage = new OrderListPage();
            tempPage.setParentPage(this);

            //orderArea.Add(new OrderListPage());
            orderArea.Add(tempPage);
        }

        private void MakeTabControl()
        {
            var tabView = new TabView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

            };

            ///////////////////////////////////////////////
            /// Tab#1
            var tabButton = new TabButton()
            {
                Text = "Tab#1"
            };

            var content = new View()
            {
                BackgroundColor = Color.Red,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            tabView.AddTab(tabButton, content);

            ///////////////////////////////////////////////////
            /// Tab#2
            var tabButton2 = new TabButton()
            {
                Text = "Tab#2"
            };

            var content2 = new View()
            {
                BackgroundColor = Color.Green,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            tabView.AddTab(tabButton2, content2);

            /////////////////////////////////////////////////////
            /// Tab#3
            var tabButton3 = new TabButton()
            {
                Text = "Tab#3"
            };

            var content3 = new View()
            {
                BackgroundColor = Color.Blue,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            tabView.AddTab(tabButton3, content3);
            contentArea.Add(tabView);
        }

        //(Test code for TableView , ok)
        private void MakeTableView()
        {
            tableView = new TableView(4, 4);
            tableView.WidthResizePolicy = ResizePolicyType.FillToParent;
            tableView.HeightResizePolicy = ResizePolicyType.FillToParent;

            for (uint row = 0; row < 4; ++row)
            {
                for (uint col = 0; col < 4; ++col)
                {
                    TextLabel textLabel = new TextLabel(row + "." + col);
                    textLabel.Size2D = new Size2D(150, 250);
                    textLabel.BackgroundColor = Color.White;
                    tableView.AddChild(textLabel, new TableView.CellPosition(row, col));
                }
            }
            contentArea.Add(tableView);
        }

        //startover 버튼 클릭.
        private bool StartButtonTouchEvent(object source, TouchEventArgs e)
        {
            
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                //@ enable
                Navigator.Pop();
                OrderManager.Instance.GallerySource.Clear(); // 주문리스트 삭제.
            }
            return false;
        }

        private void Button_Clicked(object sender, ClickedEventArgs e)
        {
            Tizen.Log.Info("MiniKi", "button clicked");
            if (sender is Button btn)
            {
                switch (btn.Name)
                {
                    case "BTN1":
                        Tizen.Log.Info("MiniKi", "Button1 Clicked !");
                        if( this.currentPage != null)
                        {
                            contentArea.Remove(this.currentPage);
                            contentArea.Add(MenuList[0]);
                            this.currentPage = MenuList[0];
                        }
                        break;
                    case "BTN2":
                        Tizen.Log.Info("MiniKi", "Button2 Clicked !");
                        if (this.currentPage != null)
                        {
                            contentArea.Remove(this.currentPage);
                            contentArea.Add(MenuList[1]);
                            this.currentPage = MenuList[1];
                        }
                        break;
                }
            }
        }
    }
}
