using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class RSS : MonoBehaviour {

    public string url = "http://rss.nytimes.com/services/xml/rss/nyt/US.xml";
    public Text textNode;
    void Start()
    {
        StartCoroutine(News());
    }
    public IEnumerator News()
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.isDone)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(www.text);
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("rss/channel/item/title");
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                Debug.Log(xmlNode.InnerText);
            }
        }
    }
}
