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
	[SerializeField]
	private GameObject commentsText;
	[SerializeField]
	private GameObject retweetsText;
	[SerializeField]
	private GameObject likesText;

    
    void Start () {
		//setContent("http://whysquare.co.nz/wp-content/uploads/2013/07/profile_square3-270x270.jpg", "myName", "myPost", "1", "2", "3");
	}
    public void setContent(string profileLink, string displayName, string text, string numComments, string numRetweets, string numLikes)
    {
        StartCoroutine(SetProfile(profileLink));
        twitterID.GetComponent<TextMeshPro>().text = displayName;
        contentText.GetComponent<TextMeshPro>().text = text;
		commentsText.GetComponent<TextMeshPro>().text = numComments;
		retweetsText.GetComponent<TextMeshPro>().text = numRetweets;
		likesText.GetComponent<TextMeshPro>().text = numLikes;
    }
    private IEnumerator SetProfile(string profileLink)
    {
        WWW profilePic = new WWW(profileLink);
        yield return profilePic;
        Texture2D picTex = profilePic.texture;
        profileButton.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", picTex);
    }
}
