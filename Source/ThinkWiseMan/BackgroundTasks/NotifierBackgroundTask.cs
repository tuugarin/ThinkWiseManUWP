﻿using DataServices;
using System;
using System.Linq;
using ToastTileCreator;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;

namespace BackgroundTasks
{
    public sealed class NotifierBackgroundTask : IBackgroundTask
    {


        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if ((bool)localSettings.Values["NotificationEnabled"])
            {
                var settingsTime = (TimeSpan)(localSettings.Values["NotifcationSheduleTime"]);
                var timeToStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                        settingsTime.Hours, settingsTime.Minutes, settingsTime.Seconds);
                //  XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
                //  var toastNode = toastXml.SelectSingleNode("toast");
                //  IXmlNode text = toastXml.GetElementsByTagName("text").FirstOrDefault();
                // ISqlDataService  dataService = new SqlDataService();
                IToastManager toastManger = new ToastManager(new SqlDataService());
                var toastNotifier = ToastNotificationManager.CreateToastNotifier();
                if (DateTime.Now.TimeOfDay.Hours == settingsTime.Hours && DateTime.Now.Minute == settingsTime.Minutes)
                {
                    //var ideas = await dataService.GetThoughtsByDayAsync(timeToStart.Day, timeToStart.Month);
                    //text.InnerText = ideas.First().Content;
                    var toast = await toastManger.CreateToastNotificationAsync(timeToStart.Day, timeToStart.Month); //new ToastNotification(toastXml);
                    toastNotifier.Show(toast);
                }
                else
                {
                    //ScheduledToastNotification toast;
                    if (DateTime.Now.TimeOfDay > settingsTime)
                    {
                        timeToStart = timeToStart.AddDays(1);

                        //var ideas = await xmlDataService.GetThoughtsByDayAsync(timeToStart.Day, timeToStart.Month);
                        //text.InnerText = ideas.First().Content;
                    }

                    //var ideas = await dataService.GetThoughtsByDayAsync(timeToStart.Day, timeToStart.Month);
                    //text.InnerText = ideas.First().Content;
                    var toast = await toastManger.CreateSheduledToastNotificationAsync(timeToStart.Day, timeToStart.Month, timeToStart); //new ScheduledToastNotification(toastXml, new DateTimeOffset(timeToStart));
                    toastNotifier.AddToSchedule(toast);
                }
                // Add to the schedule.
            }
            _deferral.Complete();

        }


    }
}
