using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField] private GameObject[] attacks;
    [SerializeField] private GameObject shoot;

    void Update() {

        GameObject fireball;

        if (Input.GetKeyDown(KeyCode.C))
            fireball = Instantiate(shoot, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
    }

}
