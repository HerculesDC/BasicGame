using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static int maxHealth;
    public static int curHealth;
    public static int maxMana;
    public static int curMana;

    private GameObject playerMovement;

    void Awake() {
        if (PlayerMovement.instance == null) Instantiate(playerMovement);
        maxHealth = 100;
        curHealth = maxHealth;
        maxMana = 100;
        curMana = maxMana;
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
