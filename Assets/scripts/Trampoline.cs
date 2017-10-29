using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    private float bounceForce = 2.5f;
    private  GameObject ball;


    // Use this for initialization
    void Start()
    {

        ball = GameObject.Find("MainBall");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {

        //bounce ball 
        if (col.gameObject.CompareTag("Throwable"))
        {
            col.transform.SetParent(null);
            Rigidbody rigidBody = ball.GetComponent<Rigidbody>();
            rigidBody.velocity = rigidBody.velocity * bounceForce;
            rigidBody.angularVelocity = rigidBody.angularVelocity;
            Debug.Log("Bouncy Bouncy");

        }
    }
}

