using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public QRCodeDecodeController e_qrcontroller;
	public string username = "erichong";
	//string dataText = "";
	Texture ad;
	// Use this for initialization
	void Start () {
		e_qrcontroller.onQRScanFinished += onScanFinished;
		//e_qrcontroller.e_QRScanFinished += onScanFinished;//receive the result data from QRController
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// maybe put the box a foot above the qr code so that it's above the head???
	void OnGUI()
	{
		if (GUI.Button (new Rect (0, 0, Screen.width, Screen.height / 10), "Reset")) {
			Reset ();
		}
		GUI.Box (new Rect (0, Screen.height / 10, Screen.width/5, Screen.height / 5), ad);
	}

	// receive the result datatext from the qrcontroller event.
	void onScanFinished(string str) {
		Debug.Log (str);
		string url = str + "/" + username;
		Debug.Log (url);

		StartCoroutine (retrieveURL (url));
		//dataText = str;
	}

	IEnumerator retrieveURL(string url) {
		WWW www = new WWW(url);
		yield return www;
		StartCoroutine(retrieveImage(www.text));
	}

	IEnumerator retrieveImage(string url) {
		WWW www = new WWW (url);
		yield return www;
		ad = www.texture;
	}

	void Reset () {
		e_qrcontroller.Reset ();
		ad = null;
	}
}