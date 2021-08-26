using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace MiniKi
{
    public partial class OrderListPage : ContentPage
    {
        public OrderListPage()
        {
            InitializeComponent();

            // copied from sample source, 2021/08/21
            BindingContext = OrderManager.Instance;

            totalPrice.SetBinding(TextLabel.TextProperty, "TotalPrice");

            CollectionView colView = new CollectionView()
            {
                HideScrollbar = false,

                ItemsSource = OrderManager.Instance.GallerySource,
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
