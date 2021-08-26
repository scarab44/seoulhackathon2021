using System.ComponentModel;
using Tizen.Applications;

namespace MiniKi
{
    public class MenuItem : INotifyPropertyChanged
    {
        private int index;      //(2021/08/20,추후 필요시 사용)
        private string name;
        private string resource;
        private string price;
        private string description;
        private int menuType;   //(2021/08/20,추후 필요시 사용)

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MenuItem(int type, int galleryIndex, string galleryName, string res, string pri, string des)
        {
            menuType = type;
            index = galleryIndex;
            name = galleryName;
            resource = res;
            price = pri;
            description = des;
        }

        public int Index => index;


        public string NameLabel
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyyChanged("NameLabel");
            }
        }

        public string ImageUrl
        {
            get
            {
                return Application.Current.DirectoryInfo.Resource + "/images/menu/" + resource;
            }
            set
            {
                resource = value;
                OnPropertyyChanged("ImageUrl");
            }
        }

        public string PriceLabel
        {
            get
            {
                return $"${price}";
            }
            set
            {
                price = value;
                OnPropertyyChanged("PriceLabel");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyyChanged("Description");
            }
        }

        public int MenuType
        {
            get
            {
                return menuType;
            }
            set
            {
                menuType = value;
                OnPropertyyChanged("MenuType");
            }
        }
    }
}
