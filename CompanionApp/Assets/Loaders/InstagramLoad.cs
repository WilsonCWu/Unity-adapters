using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstagramLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        getPerson("justinbieber");
	}

    public void getPerson(string name)
    {
        StartCoroutine(loadInstagram(name));
    }
    private IEnumerator loadInstagram(string name)
    {
        WWW site = new WWW("https://www.instagram.com/" + name + "/media/");
        yield return site;
        JSON content = new JSON();
        content.serialized = site.text;
        JSON[] posts = content.ToArray<JSON>("items");
        foreach(JSON post in posts)
        {
            JSON imageData = new JSON();
            imageData = post.ToJSON("images");
            
            JSON stdImage = new JSON();
            stdImage = imageData.ToJSON("standard_resolution");
            Debug.Log(stdImage.ToString("url"));
            
        }
    }
}
