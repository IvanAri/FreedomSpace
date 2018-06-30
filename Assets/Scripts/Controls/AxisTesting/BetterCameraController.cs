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

        // Scrolling input for zoom in and out
        if(Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity * Time.deltaTime;

            //Makes camera zoom faster
            scrollAmount *= (cameraDistance * 0.3f);

            cameraDistance += scrollAmount * -1f;

            cameraDistance = Mathf.Clamp(cameraDistance, 1.5f, 100f);
        }

        // Actuall camera rig transformation
        Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        xFormParent.rotation = Quaternion.Lerp(xFormParent.rotation, QT, Time.deltaTime * OrbitDampening);

        if(xFormCamera.localPosition.z != cameraDistance * -1f)
        {
            xFormCamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(xFormCamera.localPosition.z, cameraDistance * -1f, Time.deltaTime * scrollDampening));
        }

	}
}
