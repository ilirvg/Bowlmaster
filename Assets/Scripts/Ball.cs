using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 lounchVelocity;
    public bool lounched = false;

    Vector3 ballStartingPosition;
    Rigidbody rb;
    AudioSource audioSource;

    void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        rb.useGravity = false;
        ballStartingPosition = transform.position;
    }

    public void Lounch(Vector3 velocity) {
        lounched = true;
        rb.velocity = velocity;
        rb.useGravity = true;
        audioSource.Play();
    }

    public void Reset() {
        lounched = false;
        transform.position = ballStartingPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
    }
}
