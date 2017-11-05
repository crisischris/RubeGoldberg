using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBlow : MonoBehaviour {


    public float BlowForce = 5f;
    private GameObject ball;
    private Vector3 normal;
    private float t = 0;


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
            gameObject.GetComponent<AudioSource>().Play();
            col.transform.SetParent(null);
            Rigidbody rigidBody = ball.GetComponent<Rigidbody>();
            rigidBody.velocity = normal * (BlowForce+t);
            rigidBody.angularVelocity = rigidBody.angularVelocity;
            Debug.Log("Blowy Blowy");
                

           
        }
    }
}

