using UnityEngine;

public class BetterCameraController : MonoBehaviour {

    protected Transform xFormCamera;
    protected Transform xFormParent;

    protected Vector3 localRotation;
    protected float cameraDistance = 10f;

    public float mouseSensitivity = 400f;
    public float scrollSensitivity = 300f;
    public float OrbitDampening = 10f;
    public float scrollDampening = 6f;
    public float minClipDistance = 1000f;
    public float maxClipDistance = 5000f;

    public bool cameraDisabled = true;

    // Use this for initialization
    void Start () {
        xFormCamera = transform;
        xFormParent = transform.parent;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Input.GetMouseButton(1))
        {
            cameraDisabled = false;
        }

        if (!cameraDisabled)
        {
            // Rotation of the camera on mouse coordinates
            if(Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


                // Clamp the rotation
                localRotation.y = Mathf.Clamp(localRotation.y, -90f, 90f);
            }

            cameraDisabled = true;
        }

        // Actuall camera rig transformation
        Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        xFormParent.rotation = Quaternion.Lerp(xFormParent.rotation, QT, Time.deltaTime * OrbitDampening);


        // Scrolling input for zoom in and out
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity * Time.deltaTime;
            float newCameraVecLength = transform.localPosition.magnitude;

            newCameraVecLength -= scrollAmount;
            newCameraVecLength = Mathf.Clamp(newCameraVecLength, minClipDistance, maxClipDistance);

            Zoom(newCameraVecLength);
        }
	}

    void Zoom(float newVecLength)
    {
        // Don't forget that localPosigion.magnitude must not be equal to zero 0
        if (xFormCamera.localPosition.magnitude != newVecLength)
        {
            float coef = newVecLength / xFormCamera.localPosition.magnitude;
            xFormCamera.localPosition = Vector3.Lerp(xFormCamera.localPosition, xFormCamera.localPosition * coef, Time.deltaTime * scrollSensitivity);
        }
    }
}
