using UnityEngine;

public class RotateToTarget : MonoBehaviour {

    public Transform navAxis;
    public float rotationSpeed = 100f;
	
	// Update is called once per frame
	void LateUpdate () {
        transform.rotation = Quaternion.Slerp(transform.rotation, navAxis.rotation, Time.deltaTime * rotationSpeed);
	}
}
