using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public DoorController doorController;
    SphereCollider sphereCollider;

    void Start() {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnCollisionEnter(Collision entity) {
        if (entity.gameObject.name == "ring") {
            doorController.UnlockDoor();
        }
    }
}