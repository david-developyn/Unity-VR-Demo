using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : MonoBehaviour {

	public GameObject meteor;

	void Start() {
		Master.on_scene_change += on_scene_change;
	}

	private void on_scene_change() {
		if (Master.current_scene == Master.Scenes.death_by_meteor) {
			meteor.SetActive(true);
		}
	}
}