using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public Camera camera;
	private Animator animator;

	// Positional directions
	private bool move_backward = false;
	private bool move_forward = false;
	private bool move_left = false;
	private bool move_right = false;

	void Start() {
		animator = GetComponent<Animator>();
		Master.on_scene_change += on_scene_change;
	}

	void FixedUpdate() {
		// Move player
		if (Master.current_scene != Master.Scenes.start) {
			float move_speed = 0.05f;
			if (move_backward) {
				transform.position += transform.forward * -move_speed;
			}
			if (move_forward) {
				transform.position += transform.forward * move_speed;
			}
			if (move_left) {
				transform.position += transform.right * -move_speed;
			}
			if (move_right) {
				transform.position += transform.right * move_speed;
			}
		}
	}

	void Update() {
		// Rotate camera/player
		float rotation_speed = 5;
		transform.Rotate(0, rotation_speed * Input.GetAxis("Mouse X"), 0);
		camera.transform.Rotate(-rotation_speed * Input.GetAxis("Mouse Y"), 0, 0);

		// Set positional inputs
		if (Input.GetKeyDown("w")) {
			move_forward = true;
		} else if (Input.GetKeyUp("w")) {
			move_forward = false;
		}
		if (Input.GetKeyDown("a")) {
			move_left = true;
		} else if (Input.GetKeyUp("a")) {
			move_left = false;
		}
		if (Input.GetKeyDown("s")) {
			move_backward = true;
		} else if (Input.GetKeyUp("s")) {
			move_backward = false;
		}
		if (Input.GetKeyDown("d")) {
			move_right = true;
		} else if (Input.GetKeyUp("d")) {
			move_right = false;
		}
	}

	private void on_finished_getting_up() {
		animator.enabled = false;
		GetComponent<Rigidbody>().isKinematic = false;
	}

	private void on_scene_change() {
		if (Master.current_scene == Master.Scenes.unlock_door) {
			animator.enabled = true;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}