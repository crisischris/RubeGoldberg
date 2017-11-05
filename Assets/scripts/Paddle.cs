using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    private float hitForce = 15f;
    private GameObject ball;



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

        //hit ball 
        if (col.gameObject.CompareTag("Throwable"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            col.transform.SetParent(null);
            Rigidbody rigidBodyBall = ball.GetComponent<Rigidbody>();
            rigidBodyBall.velocity = transform.up * hitForce;
            rigidBodyBall.angularVelocity = rigidBodyBall.angularVelocity;
            Debug.Log("Hit Hit!");
            
        }
    }
}

