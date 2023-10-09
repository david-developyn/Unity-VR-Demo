using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour {

	public delegate void scene_change();
	public static event scene_change on_scene_change;

	private static Scenes _current_scene = Scenes.start;
	public static Scenes current_scene {
		get {
			return _current_scene;
		}
		set {
			_current_scene = value;
			if (value == Scenes.start) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			on_scene_change?.Invoke();
		}
	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		switch (current_scene) {
			case Scenes.start:
				GUILayout.FlexibleSpace();
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				if (GUILayout.Button("Get up")) {
					current_scene = Scenes.unlock_door;
				}
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				GUILayout.FlexibleSpace();
				break;
			case Scenes.unlock_door:
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.Label("Find a way to unlock the door");
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				break;
			case Scenes.get_to_other_side:
				GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.Label("Get to the other side");
				GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
				break;
		}
		GUILayout.EndArea();
	}

	public enum Scenes {
		start,
		unlock_door,
		get_to_other_side,
		death_by_meteor
	}
}