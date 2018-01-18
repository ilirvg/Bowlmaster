using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Vector3 lounchVelocity;
    public bool lounched = false;

    private Vector3 ballStartingPosition;
    private Rigidbody rb;
    private AudioSource audioSource;

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
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
    }
}
