using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PositionData {
	public bool connected;
	public int id;
	public float x;
	public float y;
	public float z;

	public void Apply(Vector3 transform) {
		x = (float)Math.Round(transform.x, 3);
		y = (float)Math.Round(transform.y, 3);
		z = (float)Math.Round(transform.z, 3);
	}
}

public class NetworkManger : MonoBehaviour {

	public string sockaddr = "ws://fathomless-hollows-55932.herokuapp.com/";
	public PlayerManager players;

	private PositionData self = new PositionData();
	Queue<string> positionList = new Queue<string>();
	Queue<PositionData> otherPlayers = new Queue<PositionData>();
	WebSocket w;

	// Use this for initialization
	void Start () {
		w = new WebSocket(new Uri(sockaddr));
		StartCoroutine(Websocket());
		// Websocket();
	}
	
	// Update is called once per frame
	void Update () {
		while (otherPlayers.Count > 0) {
			players.UpdatePlayer (otherPlayers.Dequeue());
		}
	}

	public void InitializePlayer(int id) {
		self.id = id;
		// Websocket ();
	}

	public void SendPosition(Vector3 transform) {
		self.Apply (transform);
		string str = JsonUtility.ToJson (self);
		positionList.Enqueue (str);
		// Websocket ();
	}

	void OnApplicationQuit() {
		self.connected = false;
		string str = JsonUtility.ToJson (self);
		w.SendString (str);
		w.Close ();
		print ("Bye bye");
	}

	IEnumerator Websocket () {
		
		yield return StartCoroutine(w.Connect());
		self.connected = true;
		string str;

//		str = JsonUtility.ToJson (player);
//		w.SendString(str);

		while (true)
		{
			string reply = w.RecvString();
			if (reply != null)
			{
				Debug.Log ("Received: "+reply);
				try {
					PositionData rec = JsonUtility.FromJson<PositionData> (reply);
					otherPlayers.Enqueue(rec);
				} catch (Exception e) {
					print ("yeah... damn " + e.ToString());
					// lol exception
				}
				// w.SendString("Hi there"+i++);
			}
			if (w.error != null)
			{
				Debug.LogError ("Error: "+w.error);
				break;
			}
			while (positionList.Count > 0) {
				str = positionList.Dequeue ();
				w.SendString(str);
			}
			yield return 0;
		}
		w.Close();
	}
}
