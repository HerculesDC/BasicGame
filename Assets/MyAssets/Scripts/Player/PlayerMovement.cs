using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float maxHorSpeed;
    [SerializeField] private float horAccel;
    [SerializeField] private float vertForce;

    private Rigidbody2D rb2D;
    private bool isGrounded;
    private bool hasDoubleJumped;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("ShowVel", 0.0f, 1.0f);
        isGrounded = false; // added to avoid errors, think I can do away with that later
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isGrounded) {

            if (rb2D.velocity.sqrMagnitude >= 0 && rb2D.velocity.sqrMagnitude <= 3)
                rb2D.AddForce(Vector2.right * horAccel * Input.GetAxis("Horizontal"));
            else if (rb2D.velocity.sqrMagnitude > 3 && rb2D.velocity.sqrMagnitude < maxHorSpeed)
                rb2D.AddForce(Vector2.right * horAccel / rb2D.velocity.sqrMagnitude * Input.GetAxis("Horizontal"));

            if (Input.GetKeyDown(KeyCode.Space))
                rb2D.AddForce(Vector2.up * vertForce);

        } else {

            if (!hasDoubleJumped) {
                if (Input.GetKeyDown(KeyCode.Space)) { 
                    rb2D.AddForce(Vector2.up * vertForce);
                    hasDoubleJumped = true;
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            hasDoubleJumped = false;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("Ground")) isGrounded = false;
    }


    void ShowVel() {
        Debug.Log(rb2D.velocity.sqrMagnitude.ToString());
    }

}
