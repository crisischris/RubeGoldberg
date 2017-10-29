using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour {

    public handInteraction handinteractionL;
    public handInteraction handinteractionR;

    public GameObject controllerL;
    public GameObject controllerR;

    private float bounceForce = 2f;
    private LayerMask Interactive;

    public float initXPos;
    public float initYPos;
    public float initZPos;

    public float xpos;
    public float ypos;
    public float zpos;

    public bool inPlayArea = true;

    public Material mat1;
    public Material mat2;




    // Use this for initialization
    void Start() {

        initXPos = gameObject.transform.position.x;
        initYPos = gameObject.transform.position.y;
        initZPos = gameObject.transform.position.z;


    }

    // Update is called once per frame
    void Update() {


        //check Left controller grabbing status
        if (handinteractionL.isGrabbing == true)
          { 
            if(controllerL.transform.position.x < 1 && controllerL.transform.position.x > -1
            && controllerL.transform.position.z < 1 && controllerL.transform.position.z > -1)
            {
                Debug.Log("you are out of bounds and grabbing something");
                GetComponent<Renderer>().material = mat2;
                GetComponent<Rigidbody>().mass = 1;
                GetComponent<Rigidbody>().drag = 0;
            }                         
        }

        if (handinteractionL.isGrabbing == true)
        {
            if(controllerL.transform.position.x > 1 || controllerL.transform.position.x < -1
             || controllerL.transform.position.z > 1 || controllerL.transform.position.z < -1)
            {
                Debug.Log("you are  out of bounds and grabbing something");
                GetComponent<Renderer>().material = mat1;
                GetComponent<Rigidbody>().mass = 1000;
                GetComponent<Rigidbody>().drag = 1000;
            }             
        }

        //check Left controller grabbing status
        if (handinteractionR.isGrabbing == true)
        {
            if (controllerR.transform.position.x < 1 && controllerR.transform.position.x > -1
            && controllerR.transform.position.z < 1 && controllerR.transform.position.z > -1)
            {
                Debug.Log("you are out of bounds and grabbing something");
                GetComponent<Renderer>().material = mat2;
                GetComponent<Rigidbody>().mass = 1;
                GetComponent<Rigidbody>().drag = 0;
            }
        }

        if (handinteractionR.isGrabbing == true)
        {
            if (controllerR.transform.position.x > 1 || controllerR.transform.position.x < -1
             || controllerR.transform.position.z > 1 || controllerR.transform.position.z < -1)
            {
                Debug.Log("you are  out of bounds and grabbing something");
                GetComponent<Renderer>().material = mat1;
                GetComponent<Rigidbody>().mass = 1000;
                GetComponent<Rigidbody>().drag = 1000;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //reset ball position
        if (col.gameObject.CompareTag("Ground"))
        {
            Debug.Log("ball hit the ground");         
            gameObject.transform.position = new Vector3(initXPos, initYPos, initZPos);
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.velocity = rigidBody.velocity * 0;
            rigidBody.angularVelocity = rigidBody.angularVelocity*0;
            GetComponent<Renderer>().material = mat2;
            GetComponent<Rigidbody>().mass = 1;
            GetComponent<Rigidbody>().drag = 0;

        }

        //bounce ball 
        if (col.gameObject.CompareTag("Bouncer"))
        {
            col.transform.SetParent(null);
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.velocity = rigidBody.velocity * bounceForce;
            rigidBody.angularVelocity = rigidBody.angularVelocity;
       //     Debug.Log("you have released the trigger");

        }
    }

}
