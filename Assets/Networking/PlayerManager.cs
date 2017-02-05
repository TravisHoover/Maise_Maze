using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public GameObject neuPlayer;
	Dictionary <int, GameObject> players;
	// Use this for initialization
	void Start () {
		players = new Dictionary<int, GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateObject(PositionData pd) {
		GameObject obj = Object.Instantiate<GameObject> (
			neuPlayer,
			pd.position,
			pd.rotation);

		players [pd.id] = obj;
	}

	public void UpdatePlayer(PositionData position) {
		if (players.ContainsKey (position.id)) {
			if (position.connected == false) {
				Destroy (players [position.id]);
				players.Remove (position.id);
			} else { 
				players [position.id].transform.localPosition = position.position;
				players [position.id].transform.localRotation = position.rotation;
			}
		} else {
			CreateObject (position);
		}
	}
}
