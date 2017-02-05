using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private GvrHead head;

	void Start()
	{
		// head = GetComponent<GvrHead> ();
		// head.target = this.transform;
		offset = transform.position - player.transform.position;
	}

	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
