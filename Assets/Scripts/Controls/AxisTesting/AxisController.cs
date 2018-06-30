using UnityEngine;


public class AxisController : MonoBehaviour {

    public float verticalRotationSpeed = 10f;
    public float horizontalRotationSpeed = 10f;

    public float smooth = 5.0f;
    public float tiltAngle = 60.0f;

    public Transform mainAxis;

    // Update is called once per frame
    void Update () {

        if (Normalize())
        {
            return;
        }

        float tiltAroundZ = 0;
        float tiltAroundY = 0;

        if (Input.GetKey("s"))
        {
            tiltAroundZ += tiltAngle;
        }

        if (Input.GetKey("w"))
        {
            tiltAroundZ -= tiltAngle;
        }

        if (Input.GetKey("d"))
        {
            tiltAroundY += tiltAngle;
        }

        if (Input.GetKey("a"))
        {
            tiltAroundY -= tiltAngle;
        }

        //Here we are gonna to look for an imput

        //And then we would call something like RotateAxis
        RotateAxis(tiltAroundZ, tiltAroundY);


    }

    bool Normalize()
    {

        if (Input.GetKeyDown("n"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            return true;
        }
        else
        {
            return false;
        }

    }

    void RotateAxis (float tiltZ, float tiltY)
    {
        if(tiltZ == 0f && tiltY == 0f)
        {
            return;
        }

        Vector3 previousAngles = transform.rotation.eulerAngles;

        Quaternion target = Quaternion.Euler(0, tiltY + previousAngles.y, tiltZ + previousAngles.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

    }
}
