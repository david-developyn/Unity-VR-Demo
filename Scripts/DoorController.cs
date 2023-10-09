using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    HingeJoint hinge;

    void Start() {
        hinge = GetComponent<HingeJoint>();

        // ONLY FOR TESTING
        UnlockDoor();
    }

    public void UnlockDoor() {
        JointLimits limits = hinge.limits;
        limits.min = -30;
        limits.max = 230;
        hinge.limits = limits;
    }
}