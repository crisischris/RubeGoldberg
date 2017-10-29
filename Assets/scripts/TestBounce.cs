using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBounce : MonoBehaviour {

    private float bounceForce = 3f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision col)
    {
        col.transform.SetParent(null);
        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.velocity = rigidBody.velocity * bounceForce;
        rigidBody.angularVelocity = rigidBody.angularVelocity * bounceForce;
        Debug.Log("you have released the trigger");
    }
}
