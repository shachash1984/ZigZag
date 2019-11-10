using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

    public float fallTime;
    public float destroyDelay;
	
	void Start () {
		 
	}
	
	 
	void Update () {
		
	}

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            Invoke("FallDown", fallTime);
           
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, destroyDelay);
        PlatformSpawner.numOfPlatforms--;
    }
}
