using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    [SerializeField] private float growthRate;
    [SerializeField] private float maxSize;
    [SerializeField] private float alphaReduce;
    [SerializeField] private float lifetime;

    public static int damage = 3;
    public static int manaCost = 5;

    private Color emission;
    private GameObject sprite;
    private GameObject particles;

    void Awake() {
        
        particles = GameObject.Find("Particles");
        sprite = GameObject.Find("Star");
        emission = sprite.GetComponent<Renderer>().material.color;
        Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        Invoke("DelayDeath", 0.0f);
    }

    void OnCollisionEnter2D(Collision2D other){
        CancelInvoke("DelayDeath");
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        if (other.gameObject.CompareTag("Wall")) Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        if (other.gameObject.CompareTag("Ground")) Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        particles.SetActive(false);
        InvokeRepeating("Growth", 0.0f, 0.01f);
    }

    void DelayDeath() { Destroy(this.gameObject, lifetime); }

    void Growth() {
        this.gameObject.transform.localScale += new Vector3(growthRate, growthRate, 0.0f); //ambiguous with Vector2
        emission -= new Color(0.0f, 0.0f, 0.0f, alphaReduce);
        if (emission.a <= 0) Destroy(this.gameObject);
    }
}
