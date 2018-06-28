using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 200f;
    public float sidewayslForce = 500f;

    private bool moveLeft = false;
    private bool moveRight = false;

    void Update()
    {
        if (Input.GetKey("d"))
        {
            moveRight = true;
        }

        if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
    }
	
	// Update is called once per frame
    // When using physics - use FixedUpdate
	void FixedUpdate () {

        // Adding forwardForce
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (moveRight)
        {
            rb.AddForce(sidewayslForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            // Some code
        }

        if (moveLeft)
        {
            rb.AddForce(-1 * sidewayslForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            // Some code
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<ExampleGameManager>().EndGame();
        }

        if (moveLeft || moveLeft)
        {
            moveRight = false;
            moveLeft = false;
        }

    }
}
