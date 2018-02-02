using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float maxHorSpeed;
    [SerializeField] private float horAccel;
    [SerializeField] private float vertForce;

    public static PlayerMovement instance = null;
    public static bool facing;

    private Rigidbody2D rb2D;
    private bool isGrounded;
    private bool hasDoubleJumped;

    void Awake() {

        facing = true;

        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        rb2D = GetComponent<Rigidbody2D>();
        //InvokeRepeating("ShowVel", 0.0f, 1.0f);
        isGrounded = false; // added to avoid errors, think I can do away with that later
    }

	// Use this for initialization
	void Start () {
        InvokeRepeating("FacingLog", 0.0f, 1.0f);
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

            if (rb2D.velocity.sqrMagnitude >= 0 && rb2D.velocity.sqrMagnitude <= 3)
                rb2D.AddForce(Vector2.right * horAccel/2.0f * Input.GetAxis("Horizontal"));
            else if (rb2D.velocity.sqrMagnitude > 3 && rb2D.velocity.sqrMagnitude < maxHorSpeed)
                rb2D.AddForce(Vector2.right * horAccel / (2.0f * rb2D.velocity.sqrMagnitude) * Input.GetAxis("Horizontal"));

            if (!hasDoubleJumped) {
                if (Input.GetKeyDown(KeyCode.Space)) { 
                    rb2D.AddForce(Vector2.up * vertForce);
                    hasDoubleJumped = true;
                }
            }
        }

        if (rb2D.velocity.x > 0) facing = true;
        else if (rb2D.velocity.x < 0) facing = false;
        else facing = facing; //keep facing towards whatever it is
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

    void FacingLog() {
        Debug.Log(facing.ToString());
    }
    
    void ShowVel() {
        Debug.Log(rb2D.velocity.sqrMagnitude.ToString());
    }

}
