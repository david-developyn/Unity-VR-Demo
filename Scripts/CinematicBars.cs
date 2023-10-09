using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicBars : MonoBehaviour {

	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
		Master.on_scene_change += on_scene_change;
	}

	private void hide() {
		if (Master.current_scene == Master.Scenes.get_to_other_side) {
			animator.Play("Base Layer.Cinematic Bars Disappear");
		}
	}

	private void on_scene_change() {
		if (Master.current_scene == Master.Scenes.get_to_other_side) {
			animator.enabled = true;
		}
		if (Master.current_scene == Master.Scenes.death_by_meteor) {
			animator.Play("Base Layer.Cinematic Bars Appear");
		}
	}
}