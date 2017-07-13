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
                    CreateTweet(Response.items[i]);
                }
            }
            //Debug.Log(response);
        }
        else
        {
            Debug.Log(response);
        }
    }
    void CreateTweet(Twitter.Tweet tweet)
    {
        Debug.Log(tweet.user.profile_image_url);
        Debug.Log(tweet.user.name); //actual name
        Debug.Log(tweet.user.screen_name); //handle
        Debug.Log("TIME: " + tweet.created_at);
        Debug.Log(tweet.text);
        Debug.Log("RT: " + tweet.retweet_count + "FAV: " + tweet.favorite_count);
        if (tweet.entities.media != null)
        {
            foreach (Media url in tweet.entities.media)
            {
                Debug.Log(url.type + "\t" + url.media_url);
            }
        }
    }
}
