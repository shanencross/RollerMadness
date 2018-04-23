﻿using UnityEngine;
using System.Collections;

public class PlatformAttachPlayer : MonoBehaviour {

	//On collision with player, make player a child of the moving platform
	//so that the player moves with the platform
	void OnTriggerEnter(Collider col) {
		GameObject collidingObject = col.gameObject;
		if (collidingObject.CompareTag("Player") && collidingObject.transform.parent != this.gameObject.transform.parent) {
			collidingObject.transform.parent = this.gameObject.transform.parent;
			Debug.Log ("Player object on top of floating platform");
		}
		
	}

	void OnTriggerExit(Collider col) {
		GameObject exitingObject = col.gameObject;
		if (exitingObject.CompareTag ("Player") && exitingObject.transform.parent == this.gameObject.transform.parent) {
			Debug.Log("Player object leaving floating platform");
			exitingObject.transform.parent = null;
		}
	}
}
