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

        if (AlignWithMainAxis())
        {
            return;
        }

        float tiltAroundX = 0;
        float tiltAroundY = 0;

        if (Input.GetKey("w"))
        {
            tiltAroundX += tiltAngle;
        }

        if (Input.GetKey("s"))
        {
            tiltAroundX -= tiltAngle;
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
        RotateAxis(tiltAroundX, tiltAroundY);


    }

    bool Normalize()
    {

        if (false)//(Input.GetKeyDown("n")  && !Input.GetKeyDown(KeyCode.LeftShift))
        {
            float xEulerAngle = transform.rotation.eulerAngles.x;
            float yEulerAngle = transform.rotation.eulerAngles.y;
            if (xEulerAngle <= 90 && xEulerAngle >=-90)
            {
                transform.rotation = Quaternion.Euler(0, yEulerAngle, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, yEulerAngle, 0);
            }
            return true;
        }
        else
        {
            return false;
        }

    }

    bool AlignWithMainAxis()
    {
        if(Input.GetKeyDown("n")) //&& Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Left shift pressed");

            float xEulerAngle = mainAxis.rotation.eulerAngles.x;
            float yEulerAngle = mainAxis.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(xEulerAngle, yEulerAngle, 0);
            return true;
        }
        else
        {
            return false;
        }
    }

    void RotateAxis (float tiltX, float tiltY)
    {
        if(tiltX == 0f && tiltY == 0f)
        {
            return;
        }

        Vector3 previousAngles = transform.rotation.eulerAngles;

        float xQTrotation = tiltX + previousAngles.x;
        float yQTrotation = tiltY + previousAngles.y;

        // xQTrotation = Mathf.Clamp(xQTrotation, 0f, 180f);
        // i_belekhov figure out how to clamp rotation right. And rework this controller;

        Quaternion target = Quaternion.Euler(xQTrotation, yQTrotation, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

    }

    void LateUpdate()
    {
        transform.position = mainAxis.position;
    }
}
