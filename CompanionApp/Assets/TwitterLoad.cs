using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Twitter;

public class TwitterLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Twitter.Oauth.consumerKey = "q33oAyhv3DUm2N9DwuYtd6Oqn";
        Twitter.Oauth.consumerSecret = "sXNrpClcZABNILxml2EY2tcah3c6bWMQmYbzhTDgfdZMmIcGx7";
        Twitter.Oauth.accessToken = "882304356820955136-yOKXoN0NIbn00JIhORKcEt6ju5HflHW";
        Twitter.Oauth.accessTokenSecret = "3AGIZncQ1WKSqjqN85YgMvRh01ojreddfs9yUmR2Ez3gG";

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["screen_name"] = "realDonaldTrump";
        parameters["userid"] = "25073877";
        StartCoroutine(Client.Get("statuses/user_timeline", parameters, this.Callback));
    }

    void Callback(bool success, string response)
    {
        if (success)
        {
            StatusesHomeTimelineResponse Response = JsonUtility.FromJson<StatusesHomeTimelineResponse>(response);
            for (int i = 0; i < Response.items.Length; i++)
            {
                Debug.Log(Response.items[i].text);
            }
            //Debug.Log(response);
        }
        else
        {
            Debug.Log(response);
        }
    }
}
