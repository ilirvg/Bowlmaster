using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 lounchVelocity;
    public bool lounched = false;

    Rigidbody rb;
    AudioSource audioSource;

    void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        rb.useGravity = false;
    }

    public void Lounch(Vector3 velocity) {
        lounched = true;
        rb.velocity = velocity;
        rb.useGravity = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
	}
}
