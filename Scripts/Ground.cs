using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	public GameObject player;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject == player) {
			Master.current_scene = Master.Scenes.start;
		}
	}
}