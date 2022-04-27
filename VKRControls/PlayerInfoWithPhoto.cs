﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Entities;

namespace VKR_Test
{
    public partial class PlayerInfoWithPhoto : UserControl
    {
        public Batter Player;
        public event EventHandler<PlayerChangedEventArgs> PlayerChanging;

        public PlayerInfoWithPhoto()
        {
            InitializeComponent();
            PlayerChanging += OnPlayerChanging;
        }

        private void OnPlayerChanging(object sender, PlayerChangedEventArgs e)
        {
            var imagePath = $"PlayerPhotos/Player{e.PlayerInfo.Id:0000}.png";
            var playerPhoto = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;
            
            PlayerPhoto.BackgroundImage = playerPhoto;

            PlayerFirstName.Text = e.PlayerInfo.FirstName.ToUpper();
            PlayerSecondName.Text = e.PlayerInfo.SecondName.ToUpper();
            PlayerNumber.Text = e.PlayerInfo.PlayerNumber.ToString();
            PlayerPosition.Text = e.PlayerInfo.PositionForThisMatch;
        }

        public void SetPlayer(Batter player)
        {
            Player = player;

            var args = new PlayerChangedEventArgs
            {
                PlayerInfo = player
            };

            PlayerChanging?.Invoke(this, args);
        }

        public void SetBackgroundColor(Color color) => PlayerPhoto.BackColor = color;
    }
}