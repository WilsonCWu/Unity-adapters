using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUrls : MonoBehaviour {
    JSON urlsJSON = new JSON();
    WWW firebaseAPI;
    string[] urls;
	IEnumerator Start () {
        do {
            firebaseAPI = new WWW("https://spatial-16a73.firebaseio.com/Room_0.json");
            yield return firebaseAPI;
        } while (firebaseAPI.text == "null");
        urlsJSON.serialized = firebaseAPI.text;
        urls = urlsJSON.ToArray<string>("urls");
        foreach (string url in urls)
        {
            Debug.Log(url);
        }
        yield return null;
	}
	
}
