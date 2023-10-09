using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{

    public DoorController doorController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider entity) {
        Debug.Log(entity.gameObject.name);
        if (entity.gameObject.name == "BasketBall1") {
            Debug.Log("KOBE!");
            doorController.UnlockDoor();
        }
    }
}
