using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField] private GameObject[] attacks;
    [SerializeField] private GameObject shoot;
    [SerializeField] private float force;

    void Update() {

        GameObject fireball;

        if (Input.GetKeyDown(KeyCode.C)) { 
            fireball = Instantiate(shoot, (PlayerMovement.facing? (transform.position+Vector3.right):(transform.position+Vector3.left)), this.gameObject.transform.rotation) as GameObject;
            fireball.GetComponent<Rigidbody2D>().AddForce((PlayerMovement.facing? Vector2.right : Vector2.left) * force);
        }
    }
}
