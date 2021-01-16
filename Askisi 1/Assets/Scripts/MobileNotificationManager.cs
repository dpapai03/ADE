using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class MobileNotificationManager : MonoBehaviour
{
#if UNITY_ANDROID
    public AndroidNotificationChannel defaultNotificationChannel;
    public AndroidNotificationChannel NotificationChannel;
    private int identifier1;
    private int identifier2;
    private int identifier3;
    private System.DateTime morning = System.DateTime.Parse("10:00");
    private System.DateTime lunch1 = System.DateTime.Parse("15:00");
    private System.DateTime afternoon1 = System.DateTime.Parse("19:00");
    private System.DateTime test = System.DateTime.Parse("14:00");
    private int compare;
    private int compare1;
    private int compare2;
    private int compare3;
    // Start is called before the first frame update
    void Start()
    {
        defaultNotificationChannel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Description = "For General Notifications",
            Importance = Importance.High,

        };
        AndroidNotificationCenter.RegisterNotificationChannel(defaultNotificationChannel);


        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Time for training",
            Text = "Let's train together",
            SmallIcon = "default",
            LargeIcon = "app_icon",
            FireTime = System.DateTime.Parse("10:00"),
        };

        identifier1 = AndroidNotificationCenter.SendNotification(notification, "default_channel");
        Debug.Log(notification.FireTime);

        AndroidNotification lunch = new AndroidNotification()
        {
            Title = "Time for training",
            Text = "The workout you do today, determines who you will be tomorrow",
            SmallIcon = "default",
            LargeIcon = "app_icon",
            FireTime = System.DateTime.Parse("15:00"),
        };
        // AndroidNotification lunch = new AndroidNotification("Time for training","The workout you do today, determines who you will be tomorrow",System.DateTime.Parse("15:00"));
        identifier2 = AndroidNotificationCenter.SendNotification(lunch, "default_channel");

        AndroidNotification afternoon = new AndroidNotification()
        {
            Title = "Time for training",
            Text = "It's all to do with the training",
            SmallIcon = "default",
            LargeIcon = "app_icon",
            FireTime = System.DateTime.Parse("19:00"),
        };
        // AndroidNotification afternoon = new AndroidNotification("Time for training", "It's all to do with the training", System.DateTime.Parse("19:00"));
        identifier3 = AndroidNotificationCenter.SendNotification(afternoon, "default_channel");

        /**
        AndroidNotification not = new AndroidNotification()
        {
            Title = "This is a test",
            Text = "It's all to do with the training",
            SmallIcon = "default",
            LargeIcon = "app_icon",
            FireTime = System.DateTime.Parse("14:55"),
        };
        // AndroidNotification not = new AndroidNotification("This is a test", "It's all to do with the training", System.DateTime.Parse("14:45"));
        identifier = AndroidNotificationCenter.SendNotification(not, "default_channel");

        AndroidNotificationCenter.SendNotification(not, "channel");
        */
        
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier1) == NotificationStatus.Delivered)
        {
            //Remove the notification from the status bar
            AndroidNotificationCenter.CancelNotification(identifier1);
        }
        else
        {
            AndroidNotificationCenter.SendNotification(notification, "default_channel");
        }
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier2) == NotificationStatus.Delivered)
        {
            //Remove the notification from the status bar
            AndroidNotificationCenter.CancelNotification(identifier2);
        }
        else
        {
            AndroidNotificationCenter.SendNotification(lunch, "default_channel");
        }
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier2) == NotificationStatus.Delivered)
        {
            //Remove the notification from the status bar
            AndroidNotificationCenter.CancelNotification(identifier2);
        }
        else
        {
            AndroidNotificationCenter.SendNotification(afternoon, "default_channel");
        }


        AndroidNotificationCenter.NotificationReceivedCallback receiveNotificationHandler = delegate (AndroidNotificationIntentData data)
        {
            var msg = "Notification received : " + data.Id + "\n";
            msg += "\n Notification received: ";
            msg += "\n .Title: " + data.Notification.Title;
            msg += "\n .Body: " + data.Notification.Text;
            msg += "\n .Channel: " + data.Channel;
            Debug.Log(msg);

        };
        AndroidNotificationCenter.OnNotificationReceived += receiveNotificationHandler;

        var NotificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();

        if (NotificationIntentData !=null)
        {
            Debug.Log("App opened with notification");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
#endif
}
