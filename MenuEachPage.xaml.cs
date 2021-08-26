using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

 //< Button x: Name = "btnRedLabel"
 //                       WidthSpecification = "{Static LayoutParamPolicies.MatchParent}"
 //                       PointSize = "6"
 //                       Text = "Set label background color to red"
 //                       TextColor = "White" />

namespace MiniKi
{
    public partial class MenuEachPage : ContentPage
    {
        //private const int MAX_PAGE_CNT = 2; 
        private const int MAX_TAB_CNT = 2;          // (추후) props
        private const int MAX_TAB_EACH_CNT = 2;     // (추후) props
        
        private List<SubPage> tabPageList;
        
        private List< List<SubPage> > tabAllList;

        private int subMaxCnt = 0;

        private List<SubPage> tempList;

        public MenuEachPage(int pageno)
        {
            InitializeComponent();

            tabAllList = new List< List<SubPage> >();
            for(int ix = 0; ix < MAX_TAB_CNT; ix++)
            {
                tabPageList = new List<SubPage>();
                for(int kx = 0; kx < MAX_TAB_EACH_CNT; kx++)    // page cnt in the tab.
                    tabPageList.Add(new SubPage(kx));
                tabAllList.Add(tabPageList);
            }
            List<SubPage> temp = tabAllList[0];

            //selectNavigator.Push(temp[0]);
            // (test,ok)
            //selectNavigator.Push(new SubPage());

            //(add by hch, 2021/08/20)
            //Create instance of ItemPopup
            _ = ItemPopup.Instance;

            if (pageno == 0)
            {
                //this.BackgroundColor = Color.Red;
                this.BackgroundColor = Color.White;
                selectNavigator.Push(temp[0]);

                var button1 = new Button()
                {
                    Text = "버튼1",
                    Name = "BTN1",
                    PointSize = 30,
                    TextColor = Color.White,
                    //WidthSpecification = LayoutParamPolicies.WrapContent,
                    //HeightSpecification = LayoutParamPolicies.WrapContent,
                    Size2D = new Size2D(100,100),


                };
                var button2 = new Button()
                {
                    Text = "버튼2",
                    Name = "BTN2",
                    PointSize = 30,
                    TextColor = Color.White,
                    //WidthSpecification = LayoutParamPolicies.WrapContent,
                    Size2D = new Size2D(100, 100),

                };

                button1.Clicked += Button_Clicked;
                button2.Clicked += Button_Clicked;

                tabButtonArea.Add(button1);
                tabButtonArea.Add(button2);

                //////////////////////////////////////////////////////
                ///
                var btnPrev = new Button()
                {
                    Text = "<<<",
                    Name = "BTNPREV",
                    PointSize = 15,
                    TextColor = Color.White,
                    //WidthSpecification = LayoutParamPolicies.WrapContent,
                    //HeightSpecification = LayoutParamPolicies.WrapContent,
                    Size2D = new Size2D(50, 50),


                };
                var btnNext = new Button()
                {
                    Text = ">>>",
                    Name = "BTNNEXT",
                    PointSize = 15,
                    TextColor = Color.White,
                    //WidthSpecification = LayoutParamPolicies.WrapContent,
                    Size2D = new Size2D(50, 50),

                };

                btnPrev.Clicked += Button_Clicked;
                btnNext.Clicked += Button_Clicked;

                tabHistArea.Add(btnPrev);
                tabHistArea.Add(btnNext);


                // push 여러번 안 되는 듯...
                //List<SubPage> tempList = tabAllList[0];
                //for (int ix = tempList.Count-1; ix >= 0; ix--)
                //{
                //    this.selectNavigator.Push(tempList[ix]);
                //}

                // 1st TAB, default
                tempList = tabAllList[0];
                this.selectNavigator.Push(tempList[0]);
                subMaxCnt = tempList.Count;
            }
            if (pageno == 1)
            {
                //this.BackgroundColor = Color.Green;
                this.BackgroundColor = Color.White;
                selectNavigator.Push(temp[1]);

                var button1 = new Button()
                {
                    Text = "BT1",
                    Name = "BTN1",
                    PointSize = 30,
                    TextColor = Color.White,
                    //WidthSpecification = LayoutParamPolicies.WrapContent,
                    //HeightSpecification = LayoutParamPolicies.WrapContent,
                    Size2D = new Size2D(100, 100),


                };
                var button2 = new Button()
                {
                    Text = "BT2",
                    Name = "BTN2",
                    PointSize = 30,
                    TextColor = Color.White,
                    //WidthSpecification = LayoutParamPolicies.WrapContent,
                    Size2D = new Size2D(100, 100),

                };

                button1.Clicked += Button_Clicked;
                button2.Clicked += Button_Clicked;

                tabButtonArea.Add(button1);
                tabButtonArea.Add(button2);

                // 1st TAB
                //List<SubPage> tempList = tabAllList[0];
                //for (int ix = tempList.Count - 1; ix >= 0; ix--)
                //{
                //    this.selectNavigator.Push(tempList[ix]);
                //}
                List<SubPage> tempList = tabAllList[1];
                this.selectNavigator.Push(tempList[0]);
            }
        }

        //public MenuEachPage(int pageno)
        //{
        //    //this.MenuEachPage();

        //    if( pageno == 0)
        //    {
        //        this.BackgroundColor = "white";
        //    }
        //    if( pageno == 1)
        //    {
        //        this.BackgroundColor = "Orange";
        //    }
        //}

        private void Button_Clicked(object sender, ClickedEventArgs e)
        {
            //Tizen.Log.Info("MiniKi", "button clicked");
            if (sender is Button btn)
            {
                switch (btn.Name)
                {
                    case "BTNPREV":
                        if( this.selectNavigator.PageCount > 1)
                        {
                            this.selectNavigator.Pop();
                        }
                        break;

                    case "BTNNEXT":
                        if (this.selectNavigator.PageCount < subMaxCnt)
                        {
                            this.selectNavigator.Push(tempList[this.selectNavigator.PageCount]);
                        }
                        break;

                    // 1st TAB
                    //case "BTN1":
                    //    Tizen.Log.Info("MiniKi", "+Button1 Clicked !");
                    //    Tizen.Log.Info("MiniKi", "Count:" + this.selectNavigator.PageCount);
                    //    if(this.selectNavigator.PageCount > 0)
                    //    {
                    //        ////this.selectNavigator.RemoveAll();
                    //        //this.selectNavigator.Pop();
                    //        //this.selectNavigator.Pop();

                    //        //// Add 1st TAB in Navigator
                    //        //List<SubPage> tempList = tabAllList[0];
                    //        //for (int ix = tempList.Count - 1; ix >= 0; ix--)
                    //        //{
                    //        //    this.selectNavigator.Push(tempList[ix]);
                    //        //}
                    //        //Tizen.Log.Info("MiniKi", "Count_:" + this.selectNavigator.PageCount);

                    //        //this.selectNavigator.RemoveAll();
                    //        while(this.selectNavigator.PageCount>0) this.selectNavigator.RemoveAt(0);
                    //        //Tizen.Log.Info("MiniKi", "Count__:" + this.selectNavigator.PageCount);
                    //        //this.selectNavigator.Pop();
                    //        //
                    //        tempList = tabAllList[0];
                    //        this.selectNavigator.Push(tempList[0]);
                    //        subMaxCnt = tempList.Count;
                    //    }
                    //    break;

                    //// 2nd TAB
                    //case "BTN2":
                    //    Tizen.Log.Info("MiniKi", "+Button2 Clicked !");
                    //    Tizen.Log.Info("MiniKi", "Count:" + this.selectNavigator.PageCount);
                    //    if (this.selectNavigator.PageCount > 0)
                    //    {
                    //        ////this.selectNavigator.RemoveAll();
                    //        //this.selectNavigator.Pop();
                    //        //this.selectNavigator.Pop();

                    //        //// Add 2nd TAB in Navigator
                    //        //List<SubPage> tempList = tabAllList[1];
                    //        //for (int ix = tempList.Count - 1; ix >= 0; ix--)
                    //        //{
                    //        //    this.selectNavigator.Push(tempList[ix]);
                    //        //}
                    //        while (this.selectNavigator.PageCount > 0) this.selectNavigator.RemoveAt(0);
                    //        //this.selectNavigator.Pop();
                    //        //
                    //        tempList = tabAllList[1];
                    //        this.selectNavigator.Push(tempList[0]);
                    //        subMaxCnt = tempList.Count;
                    //    }
                    //    break;


                    // 1st TAB
                    case "BTN1":
                        Tizen.Log.Info("MiniKi", "+Button1 Clicked !");
                        Tizen.Log.Info("MiniKi", "Count: " + this.selectNavigator.PageCount);
                       
                        while (this.selectNavigator.PageCount > 0) this.selectNavigator.RemoveAt(0);
                         
                        tempList = tabAllList[0];
                        this.selectNavigator.Push(tempList[0]);
                        subMaxCnt = tempList.Count;

                        break;

                    // 2nd TAB
                    case "BTN2":
                        Tizen.Log.Info("MiniKi", "+Button2 Clicked !");
                        Tizen.Log.Info("MiniKi", "Count: " + this.selectNavigator.PageCount);
                      
                        while (this.selectNavigator.PageCount > 0) this.selectNavigator.RemoveAt(0);
               
                        tempList = tabAllList[1];
                        this.selectNavigator.Push(tempList[0]);
                        subMaxCnt = tempList.Count;

                        break;
                }
            }
        }

    }
}
