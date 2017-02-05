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
			new Vector3 (pd.x, pd.y, pd.z),
			Quaternion.identity);

		players [pd.id] = obj;
	}

	public void UpdatePlayer(PositionData position) {
		if (players.ContainsKey (position.id)) {
			if (position.connected == false) {
				Destroy (players [position.id]);
				players.Remove (position.id);
			} else { 
				players [position.id].transform.localPosition = new Vector3 (position.x, position.y, position.z);
			}
		} else {
			CreateObject (position);
		}
	}
}
