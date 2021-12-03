using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebReque : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator LoadTextAssets()
    {
        System.Uri uri = new System.Uri(System.IO.Path.Combine(Application.streamingAssetsPath,"config,json"));
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(uri.AbsoluteUri);
        yield return unityWebRequest.SendWebRequest();
    }
}
