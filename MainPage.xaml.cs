﻿using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace MiniKi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // 메뉴작게보기
        private void SButton_Clicked(object sender, ClickedEventArgs e)
        {
            Navigator.Push(new MainPage1());
        }

        // 메뉴크게보기
        private void LButton_Clicked(object sender, ClickedEventArgs e)
        {
            Navigator.Push(new MainPage2());
        }

      



    }
}
