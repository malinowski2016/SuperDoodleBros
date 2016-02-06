using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float maxSpeed;
	public float moveSpeed;
	public float jumpHeight;

	public bool grounded;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") && grounded == true) {
            rb2d.AddForce(Vector2.up * jumpHeight);
		}
	}

	void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");          //-1 if press left, +1 if press right
        rb2d.AddForce((Vector2.right * moveSpeed) * h); // Move left/right 

        //Limit speed
        if (rb2d.velocity.x > maxSpeed)
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        if (rb2d.velocity.x < -maxSpeed)
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
    }

    void OnCollisionEnter2D()
    {
        grounded = true;
    }

    void OnCollisionExit2D()
    {
        grounded = false;
    }
}
