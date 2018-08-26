using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour {


    public Transform target = null;
    public Transform center = null;
    public float lookAtRotationSpeed = 2.0f;
    public bool extendedLogging = false;
    Vector3 targetPoint;
    Quaternion targetRotation;

	
	// Update is called once per frame
	void Update ()
    {
        // Unity built-in
        CustomLookAt();

	}

    void CustomLookAt()
    {
        if (target != null) {

            targetPoint = new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position;
            targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * lookAtRotationSpeed);

        }
        else if(extendedLogging)
        {
            Debug.Log("No target to look at");
        }
    }


    // Method to provide targets
    public void ReceiveTarget(Transform newTarget)
    {
        target = newTarget;
        Debug.Log("New target assinged");
    }

    
}
