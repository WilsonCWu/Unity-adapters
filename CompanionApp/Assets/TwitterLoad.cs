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
        getTimeline();
        
    }
    void getTimeline()
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["count"] = "30";
        parameters["include_entities"] = "true";
        StartCoroutine(Client.Get("statuses/home_timeline", parameters, this.Callback));
    }
    void getPerson()
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters["screen_name"] = "realDonaldTrump";
        parameters["userid"] = "25073877";
        StartCoroutine(Client.Get("statuses/user_timeline", parameters, this.Callback));
    }
    void Callback(bool success, string response)
    {
        if (success)
        {
            Debug.Log(response);
            StatusesHomeTimelineResponse Response = JsonUtility.FromJson<StatusesHomeTimelineResponse>(response);
            for (int i = 0; i < Response.items.Length; i++)
            {
                if (Response.items[i].text.Length < 4 || Response.items[i].text.Substring(0,4) != "RT @")
                {
                    Debug.Log(Response.items[i].user.profile_image_url);
                    Debug.Log(Response.items[i].user.name); //actual name
                    Debug.Log(Response.items[i].user.screen_name); //handle
                    Debug.Log("TIME: " + Response.items[i].created_at);
                    Debug.Log(Response.items[i].text);
                    Debug.Log("RT: " + Response.items[i].retweet_count + "FAV: " + Response.items[i].favorite_count);
                    if (Response.items[i].entities.media != null)
                    {
                        foreach (Media url in Response.items[i].entities.media)
                        {
                            Debug.Log(url.type + "\t" + url.media_url);
                        }
                    }
                }
            }
            //Debug.Log(response);
        }
        else
        {
            Debug.Log(response);
        }
    }
}
