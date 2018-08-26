using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour {

    public Transform center = null;
    public bool extendedLogging = false;

    // Here we are choosing how to rotate and around what
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    // Update is called once per frame
    void Update () {

        if(center == null)
        {
            // so we will take only first one but it's ok
            center = transform.GetComponentInParent<LookAtTarget>().target;
        }

        CustomRotateAround();

	}

    void LateUpdate()
    {
        // for now do nothing
    }

    void CustomRotateAround()
    {
        if (center != null)
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
            desiredPosition = (transform.position - center.position).normalized * radius + center.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

        }
        else if (extendedLogging)
        {
            Debug.Log("No target to rotate around");
        }

    }

}
