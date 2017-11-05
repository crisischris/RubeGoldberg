using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    private GameObject ball;

    private float endPosX;
    private float endPosY;
    private float endPosZ;

    private float ShootForce = 2;
    private float randomNumberX;
    private float randomNumberZ;

    // Use this for initialization
    void Start () {

          ball = GameObject.Find("MainBall");
        
            
    }

    
	
	// Update is called once per frame
	void Update () {

        endPosX = GameObject.Find("TeleporterParticleEnd").transform.position.x;
        endPosY = GameObject.Find("TeleporterParticleEnd").transform.position.y;
        endPosZ = GameObject.Find("TeleporterParticleEnd").transform.position.z;

    }


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Throwable"))
        {

            randomNumberX = Random.Range(-.5f, .5f);
            randomNumberZ = Random.Range(-.5f, .5f);

            col.transform.SetParent(null);
            ball.transform.position = new Vector3(endPosX, endPosY, endPosZ);
            gameObject.GetComponent<AudioSource>().Play();
            Rigidbody rigidBody = ball.GetComponent<Rigidbody>();
            rigidBody.velocity = new Vector3(randomNumberX, 5, randomNumberZ) * ShootForce;
            rigidBody.angularVelocity = rigidBody.angularVelocity;
            Debug.Log("you hit the teleporter");

        }
    }
}
