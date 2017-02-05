using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {
	
	public ParticleSystem particles1;
	public ParticleSystem particles2;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	//void Update () {
	//}

	void OnTriggerEnter(Collider player){
		
		//start particle system and...ui?
		particles1.Play();
		particles2.Play();
		
		StartCoroutine(EndGame());		
	}
	
	IEnumerator EndGame(){
		//wait for 10 seconds
		yield return new WaitForSeconds(10);

		print("I am printing!");
		
		//go back to menu
		//Application.LoadLevel("mainMenu");
	}

}
