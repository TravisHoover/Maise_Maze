using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdate : MonoBehaviour {
	WebSocket w;
	PositionData pd;
	public NetworkManger net;
	int id;
	// Use this for initialization
	void Start () {
		id = UnityEngine.Random.Range(1, 1<<30);
		net.InitializePlayer (id);
	}
		
	void FixedUpdate() {
		if (Input.GetKeyDown (KeyCode.W)) {
			this.transform.Translate (Vector3.forward);
			net.SendPosition (transform.localPosition, transform.rotation);
		} else if (Input.GetKeyDown (KeyCode.A)) {
			this.transform.Rotate (new Vector3 (0, -45, 0));
			net.SendPosition (transform.localPosition, transform.rotation);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			this.transform.Rotate (new Vector3 (0, 45, 0));
			net.SendPosition (transform.localPosition, transform.rotation);
		}
		// this.transform.localPosition.x;
	}


}
