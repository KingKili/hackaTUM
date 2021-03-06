﻿using Ausgaben_Rechner.Classes;
using HackaTUM.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace HackaTUM.Pages
{
    public sealed partial class SettingsPage : Page
    {
        //--------------------------------------------------------Atribute:-------------------------------------------------------------------\\
        #region --Atribute--



        #endregion
        //--------------------------------------------------------Construktoren:--------------------------------------------------------------\\
        #region --Construktoren--
        /// <summary>
        /// Basic empty Constructor
        /// </summary>
        /// <history>
        /// 11/11/2016  Created [Fabian Sauter]
        /// </history>
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        #endregion
        //--------------------------------------------------------Set-, Get- Metoden:---------------------------------------------------------\\
        #region --Set-, Get- Metode--



        #endregion
        //--------------------------------------------------------Sonstige Metoden:-----------------------------------------------------------\\
        #region --Sonstige Metoden (Public)--



        #endregion

        #region --Sonstige Metoden (Private)--
        private void settingChanged()
        {
            DataStorage.INSTANCE.saveSettingsData();
        }

        #endregion

        #region --Sonstige Metoden (Protected)--



        #endregion
        //--------------------------------------------------------Events:---------------------------------------------------------------------\\
        #region --Events--
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataStorage.INSTANCE.settingsData.enabled)
            {
                enable_btn.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                enable_btn.Background = new SolidColorBrush(Windows.UI.Colors.Red);
            }

            if (DataStorage.INSTANCE.settingsData.privateMode)
            {
                private_btn.Content = "\xE1F6";
            }
            else
            {
                private_btn.Content = "\xE1F7";
            }

            powersaverMode_tgls.IsOn = DataStorage.INSTANCE.settingsData.powerSaverMode;
            smartMode_tgls.IsOn = DataStorage.INSTANCE.settingsData.smartMode;
            noGps_tgls.IsOn = DataStorage.INSTANCE.settingsData.gpsEnabled;
            noStepTacking.IsOn = DataStorage.INSTANCE.settingsData.steptackingEnabled;
            latestRingTime_tpck.IsEnabled = DataStorage.INSTANCE.settingsData.latestRingTimeEnabled;
            latestRingTime_tgls.IsOn = DataStorage.INSTANCE.settingsData.latestRingTimeEnabled;
            if (DataStorage.INSTANCE.settingsData.latestRingTime != null)
            {
                DateTime time = DataStorage.INSTANCE.settingsData.latestRingTime;
                latestRingTime_tpck.Time = new TimeSpan(time.Hour, time.Minute, time.Second);
            }
            else
            {
                latestRingTime_tpck.Time = new TimeSpan(0, 0, 0);
            }
        }

        private void expandGeneral_btn_Click(object sender, RoutedEventArgs e)
        {
            if (settingsGeneral_sckpl.Visibility == Visibility.Visible)
            {
                expandGeneralSettings_btn.Content = "\xE019";
                settingsGeneral_sckpl.Visibility = Visibility.Collapsed;
            }
            else
            {
                expandGeneralSettings_btn.Content = "\xE018";
                settingsGeneral_sckpl.Visibility = Visibility.Visible;
            }
        }

        private void expandAlarm_btn_Click(object sender, RoutedEventArgs e)
        {
            if (settingsAlarm_sckpl.Visibility == Visibility.Visible)
            {
                expandAlarmSettings_btn.Content = "\xE019";
                settingsAlarm_sckpl.Visibility = Visibility.Collapsed;
            }
            else
            {
                expandAlarmSettings_btn.Content = "\xE018";
                settingsAlarm_sckpl.Visibility = Visibility.Visible;
            }
        }

        private void expandPrivacy_btn_Click(object sender, RoutedEventArgs e)
        {
            if (settingsPrivacy_sckpl.Visibility == Visibility.Visible)
            {
                expandPrivacySettings_btn.Content = "\xE019";
                settingsPrivacy_sckpl.Visibility = Visibility.Collapsed;
            }
            else
            {
                expandPrivacySettings_btn.Content = "\xE018";
                settingsPrivacy_sckpl.Visibility = Visibility.Visible;
            }
        }

        private void private_btn_Click(object sender, RoutedEventArgs e)
        {
            if (DataStorage.INSTANCE.settingsData.privateMode)
            {
                private_btn.Content = "\xE1F7";
                DataStorage.INSTANCE.settingsData.privateMode = false;
            }
            else
            {
                private_btn.Content = "\xE1F6";
                DataStorage.INSTANCE.settingsData.privateMode = true;
            }
            settingChanged();
        }

        private void enable_btn_Click(object sender, RoutedEventArgs e)
        {
            if (DataStorage.INSTANCE.settingsData.enabled)
            {
                enable_btn.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                DataStorage.INSTANCE.settingsData.enabled = false;
            }
            else
            {
                enable_btn.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                DataStorage.INSTANCE.settingsData.enabled = true;
            }
            settingChanged();
        }

        private async void createBackup_btn_Click(object sender, RoutedEventArgs e)
        {
            await DataStorage.INSTANCE.createBackup();
        }

        private async void loadBackup_btn_Click(object sender, RoutedEventArgs e)
        {
            await DataStorage.INSTANCE.loadBackup();
        }

        private void powersaverMode_tgls_Toggled(object sender, RoutedEventArgs e)
        {
            DataStorage.INSTANCE.settingsData.powerSaverMode = !DataStorage.INSTANCE.settingsData.powerSaverMode;
            settingChanged();
        }

        private void smartMode_tgls_Toggled(object sender, RoutedEventArgs e)
        {
            DataStorage.INSTANCE.settingsData.smartMode = !DataStorage.INSTANCE.settingsData.smartMode;
            settingChanged();
        }

        private void noGps_tgls_Toggled(object sender, RoutedEventArgs e)
        {
            DataStorage.INSTANCE.settingsData.gpsEnabled = !DataStorage.INSTANCE.settingsData.gpsEnabled;
            settingChanged();
        }

        private void noStepTacking_tgls_Toggled(object sender, RoutedEventArgs e)
        {
            DataStorage.INSTANCE.settingsData.steptackingEnabled = !DataStorage.INSTANCE.settingsData.steptackingEnabled;
            settingChanged();
        }

        private void latestRingTime_tgls_Toggled(object sender, RoutedEventArgs e)
        {
            DataStorage.INSTANCE.settingsData.latestRingTimeEnabled = !DataStorage.INSTANCE.settingsData.latestRingTimeEnabled;
            latestRingTime_tpck.IsEnabled = DataStorage.INSTANCE.settingsData.latestRingTimeEnabled;
            settingChanged();
        }

        private async void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            DataStorage.INSTANCE.settingsData = new Ausgaben_Rechner.Classes.Data.SettingsData();
            DataStorage.INSTANCE.userData = new Ausgaben_Rechner.Classes.Data.UserData();
            DataStorage.INSTANCE.saveAllData();
            await Utillities.showMessageBoxAsync("App got successfully reset!");
        }

        #endregion
    }
}
