using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace MiniKi
{
    //(기존소스, 2021/08/20)
    //public class ItemView : RecyclerViewItem
    //{
    //    private Button btn;
    //    private TextLabel label;

    //    public ItemView()
    //    {
    //        float sizeW = Window.Instance.WindowSize.Width * 0.3f;
    //        Size = new Size(sizeW, sizeW);

    //        btn = new Button()
    //        {
    //            StyleName = "GalleryButton",
    //            WidthSpecification = LayoutParamPolicies.MatchParent,
    //            HeightSpecification = LayoutParamPolicies.MatchParent,
    //            ParentOrigin = Tizen.NUI.ParentOrigin.Center,
    //            PivotPoint = Tizen.NUI.PivotPoint.Center,
    //            PositionUsesPivotPoint = true,

    //        };
    //        btn.Icon.WidthSpecification = (int)(sizeW * 0.7f);
    //        btn.Icon.HeightSpecification = (int)(sizeW * 0.7f);
    //        btn.Icon.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
    //        Add(btn);
    //        label = new TextLabel()
    //        {
    //            PointSize = 20,
    //            ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter,
    //            PivotPoint = Tizen.NUI.PivotPoint.BottomCenter,
    //            PositionUsesPivotPoint = true,
    //        };
    //        Add(label);

    //        label.SetBinding(TextLabel.TextProperty, "NameLabel");
    //        btn.Clicked += Btn_Clicked;
    //    }

    //    private void Btn_Clicked(object sender, ClickedEventArgs e)
    //    {
    //        var tag1 = $"{Index}-Button";
    //        var tag2 = $"{Index}-Icon";
    //        btn.TransitionOptions = new TransitionOptions()
    //        {
    //            TransitionTag = tag1,
    //        };

    //        btn.Icon.TransitionOptions = new TransitionOptions()
    //        {
    //            TransitionTag = tag2,
    //        };

    //        //(del for build)
    //        //ItemPopup.Instance.BindingContext = this.BindingContext;
    //        //ItemPopup.Instance.SetTag(tag1, tag2);
    //        //ItemPopup.Instance.ShowPopup();
    //    }
    //}

    public class ItemView : RecyclerViewItem
    {
        private Button btn;
        private ImageView image;
        private TextLabel label_name;
        private TextLabel label_price;
        private int index;
        public ItemView(float fSize)
        {
            BackgroundColor = Color.Transparent;
            var sizeWidth = (int)(ApplicationHelper.GetPortraitWidth() * fSize);
            WidthSpecification = sizeWidth;
            HeightSpecification = sizeWidth;
            Margin = new Extents(5, 5, 15, 0);

            btn = new Button()
            {
                StyleName = "GalleryButton",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter,
                PivotPoint = Tizen.NUI.PivotPoint.TopCenter,
                PositionUsesPivotPoint = true,

            };
            btn.Clicked += Btn_Clicked;
            Add(btn);
            image = new ImageView()
            {
                WidthSpecification = (int)(sizeWidth * 0.73f),
                HeightSpecification = (int)(sizeWidth * 0.73f),
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            Add(image);

            View bottomLayoutView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter,
                PivotPoint = Tizen.NUI.PivotPoint.BottomCenter,
                PositionUsesPivotPoint = true,
            };
            Add(bottomLayoutView);
            label_name = new TextLabel()
            {
                PixelSize = sizeWidth * 0.07f,
                SizeWidth = sizeWidth * 0.65f,
                Ellipsis = false,
                MultiLine = true,
                TextColor = new Color("#7474FF"),
                HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin,
                PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                PositionUsesPivotPoint = true,
                Padding = new Extents((ushort)(sizeWidth * 0.15f), 0, 0, 0),
            };

            label_price = new TextLabel()
            {
                PixelSize = sizeWidth * 0.07f,
                TextColor = new Color("#7474FF"),
                HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Begin,
                PivotPoint = Tizen.NUI.PivotPoint.BottomRight,
                ParentOrigin = Tizen.NUI.ParentOrigin.BottomRight,
                PositionUsesPivotPoint = true,
                Padding = new Extents(0, (ushort)(sizeWidth * 0.15f), 0, 0),
            };
            bottomLayoutView.Add(label_name);
            bottomLayoutView.Add(label_price);
        }

        private void Btn_Clicked(object sender, ClickedEventArgs e)
        {
            var btnTag = "ButtonTag" + label_name.Text + (BindingContext as MenuItem).Index;
            var imgTag = "ImageTag" + label_name.Text + (BindingContext as MenuItem).Index;

            btn.TransitionOptions = new TransitionOptions()
            {
                TransitionTag = btnTag,
            };
            image.TransitionOptions = new TransitionOptions()
            {
                TransitionTag = imgTag,
            };


            ItemPopup.Instance.BindingContext = this.BindingContext;
            ItemPopup.Instance.SetItemTag(btnTag, imgTag);
            ItemPopup.Instance.ShowPopup();
        }

        public ImageView Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public TextLabel NameLabel
        {
            get
            {
                return label_name;
            }
            set
            {
                label_name = value;
            }
        }

        public TextLabel PriceLabel
        {
            get
            {
                return label_price;
            }
            set
            {
                label_price = value;
            }
        }
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }
    }
}
