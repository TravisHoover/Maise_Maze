using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genObjectMovement : MonoBehaviour {

	public float start;
	public float stop;
	public float interval;
		// Use this for initialization
    public	bool right = true;

	void Start () {
		//InvokeRepeating ("TestCondition", 0, 05); 
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.localPosition;
		if (right == true) {
		      if (pos.z > start) {
				pos.z -= interval;

			} else {
				right = false;
			}
		} else {
			if (pos.z < stop) {
				pos.z += interval;


			} else {
				right = true;
			}

		}


		this.transform.localPosition = pos;
	}


}




