using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBlow : MonoBehaviour {


    public float BlowForce = 5f;
    private GameObject ball;
    private Vector3 normal;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        normal = gameObject.transform.TransformDirection(Vector3.back);
        ball = GameObject.Find("MainBall");
    }

    void OnCollisionEnter(Collision col)
    {

        //Blow Ball with wind
        if (col.gameObject.CompareTag("Throwable"))
        {
            col.transform.SetParent(null);
            Rigidbody rigidBody = ball.GetComponent<Rigidbody>();
            rigidBody.velocity = normal * BlowForce;
            rigidBody.angularVelocity = rigidBody.angularVelocity;
            Debug.Log("Blowy Blowy");

          

        }
    }
}

