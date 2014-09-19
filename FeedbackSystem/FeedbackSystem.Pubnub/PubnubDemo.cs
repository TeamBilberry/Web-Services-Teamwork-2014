using System;
using System.Collections.Generic;
using System.Diagnostics;

public class PubnubDemo
{
	static void Main()
	{
		// Start the HTML5 Pubnub client
		Process.Start("..\\..\\PubNub-HTML5-Client.html");

        System.Threading.Thread.Sleep(2000);

		PubnubAPI pubnub = new PubnubAPI(
            "pub-c-4fd56e1f-976d-440d-8bd1-fa892d69270f",               // PUBLISH_KEY
            "sub-c-8a8f356e-3fd6-11e4-b33e-02ee2ddab7fe",               // SUBSCRIBE_KEY
            "sec-c-YzQyOTFlNjItMzgwNS00NzZkLTgwYzMtNDMxYmNmOTkxODE5",   // SECRET_KEY
			true                                                        // SSL_ON?
		);
        string channel = "feedbacks-channel";

		// Publish a sample message to Pubnub
        List<object> publishResult = pubnub.Publish(channel, "Hello Pubnub!");
        Console.WriteLine(
            "Publish Success: " + publishResult[0].ToString() + "\n" +
            "Publish Info: " + publishResult[1]
        );

		// Show PubNub server time
        object serverTime = pubnub.Time();
        Console.WriteLine("Server Time: " + serverTime.ToString());

		// Subscribe for receiving messages (in a background task to avoid blocking)
		System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
			() =>
			pubnub.Subscribe(
				channel,
				delegate(object message)
				{
					Console.WriteLine("Received Urgent Problem -> '" + message + "'");
					return true;
				}
			)
		);
		t.Start();

		// Read messages from the console and publish them to Pubnub
		while (true)
		{
			Console.Write("Enter urgent problem message: ");
			string msg = Console.ReadLine();
			pubnub.Publish(channel, msg);
			Console.WriteLine("Problem message {0} sent.", msg);
		}
	}
}