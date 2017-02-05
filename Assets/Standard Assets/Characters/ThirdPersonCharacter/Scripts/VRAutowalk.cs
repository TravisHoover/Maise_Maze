using UnityEngine;
using System.Collections;

/*[RequireComponent{typeof(CharacterController)}]*/
public class VRAutowalk : MonoBehaviour{

	public float speed = 3.0f;
	
	public bool moveForward = false;
	
	private CharacterController controller;
	
	//private GvrViewer gvrViewer;
	
	private Transform vrHead;
	
	void Start(){
		controller = GetComponent<CharacterController>();
		//gvrViewer = GameObject.find("GvrMain").GetComponent<GvrViewer>();
		//transform.GetChild(0).GetComponent<GvrViewer>();
		vrHead = Camera.main.transform;
	}
	
	void Update(){
	
		if(Input.GetButtonDown("Fire1")){
			moveForward = !moveForward;
		}
	
		if(moveForward){
			Vector3 forward = vrHead.TransformDirection(Vector3.forward);
			controller.SimpleMove(forward*speed);
		}
	}

}