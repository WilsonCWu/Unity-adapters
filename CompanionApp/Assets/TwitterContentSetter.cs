using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TwitterContentSetter : MonoBehaviour {
    [SerializeField]
    private GameObject contentBack;
    [SerializeField]
    private GameObject contentText;
    [SerializeField]
    private GameObject profileButton;
    [SerializeField]
    private GameObject twitterID;
    [SerializeField]
    private GameObject icons;
    
    void Start () {
	}
    public void setContent(string profileLink, string displayName, string text)
    {
        StartCoroutine(SetProfile(profileLink));
        twitterID.GetComponent<TextMeshPro>().text = displayName;
        contentText.GetComponent<TextMeshPro>().text = text;
    }
    private IEnumerator SetProfile(string profileLink)
    {
        WWW profilePic = new WWW(profileLink);
        yield return profilePic;
        Texture2D picTex = profilePic.texture;
        profileButton.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", picTex);
    }
}
