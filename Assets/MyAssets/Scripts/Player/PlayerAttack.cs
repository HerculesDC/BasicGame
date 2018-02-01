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
            fireball = Instantiate(shoot, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
            fireball.GetComponentInChildren<Rigidbody2D>().AddForce(Vector2.right * force);
        }
    }

}
