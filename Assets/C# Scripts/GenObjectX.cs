using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenObjectX : MonoBehaviour {
	
	public float interval;
	public int distance;
	// Use this for initialization
	public bool up = true;
	int diff = 0;

	void Start () {
		//InvokeRepeating ("TestCondition", 0, 05); 
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.localPosition;

		if (diff < distance) {
			if (up == false) 
				pos.x -= interval;
			else 
				pos.x += interval;
		} else {
			diff = 0;
			up = !up;
		}
		diff++;


		this.transform.localPosition = pos;
	}

}
