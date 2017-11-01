using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour {

    public handInteraction handinteractionL;
    public handInteraction handinteractionR;
    public Material glowMat;
    public GameObject warningLight1;
    public GameObject warningLight2;
    public GameObject mainLight;

    public Material skyboxLight;
    public Material skyboxDark;
   





    public GameObject controllerL;
    public GameObject controllerR;

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

    private float curveWidth = .025f;
 





    // Use this for initialization
    void Start() {

        initXPos = gameObject.transform.position.x;
        initYPos = gameObject.transform.position.y;
        initZPos = gameObject.transform.position.z;


    }

    // Update is called once per frame
    void Update() {


     
        //check Left controller grabbing status
        if (handinteractionL.isGrabbingBall == true)
          { 
            if(controllerL.transform.position.x < 1 && controllerL.transform.position.x > -1
            && controllerL.transform.position.z < 1 && controllerL.transform.position.z > -1)
            {
                Debug.Log("you are in the playing feild");
                GetComponent<Renderer>().material = mat2;
                GetComponent<Rigidbody>().mass = 1;
                GetComponent<Rigidbody>().drag = 0;
                notWarning();
            }                         
        }

        if (handinteractionL.isGrabbingBall == true)
        {
            if(controllerL.transform.position.x > 1 || controllerL.transform.position.x < -1
             || controllerL.transform.position.z > 1 || controllerL.transform.position.z < -1)
            {
                Debug.Log("you are out of bounds holding the ball...you could be cheating......");
                GetComponent<Renderer>().material = mat1;
                GetComponent<Rigidbody>().mass = 1000;
                GetComponent<Rigidbody>().drag = 1000;
                warning();
            }             
            
        }

        //check Left controller grabbing status
        if (handinteractionR.isGrabbingBall == true)
        {
            if (controllerR.transform.position.x < 1 && controllerR.transform.position.x > -1
            && controllerR.transform.position.z < 1 && controllerR.transform.position.z > -1)
            {
                Debug.Log("you are out of bounds and grabbing something");
                GetComponent<Renderer>().material = mat2;
                GetComponent<Rigidbody>().mass = 1;
                GetComponent<Rigidbody>().drag = 0;
                notWarning();
            }
        }

        if (handinteractionR.isGrabbingBall == true)
        {
            if (controllerR.transform.position.x > 1 || controllerR.transform.position.x < -1
             || controllerR.transform.position.z > 1 || controllerR.transform.position.z < -1)
            {
                Debug.Log("you are  out of bounds and grabbing something");
                GetComponent<Renderer>().material = mat1;
                GetComponent<Rigidbody>().mass = 1000;
                GetComponent<Rigidbody>().drag = 1000;
                warning();
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //reset ball position
        if (col.gameObject.CompareTag("Ground"))
        {
            Debug.Log("ball hit the ground");
            Destroy(GetComponent<TrailRenderer>());
            Destroy(GetComponent<Light>());
            gameObject.transform.position = new Vector3(initXPos, initYPos, initZPos);
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.velocity = rigidBody.velocity * 0;
            rigidBody.angularVelocity = rigidBody.angularVelocity * 0;
            GetComponent<Renderer>().material = mat2;
            GetComponent<Rigidbody>().mass = 1;
            GetComponent<Rigidbody>().drag = 0;


        }

        if (col.gameObject.CompareTag("Structure"))
        {

            gameObject.AddComponent<TrailRenderer>();
            TrailRenderer trail = GetComponent<TrailRenderer>();
            trail.material = glowMat;
            trail.startWidth = curveWidth;
            trail.receiveShadows = false;
            trail.time = 2;                    

        }

        /*
           if (col.gameObject.CompareTag("Interactive"))
        {

            gameObject.AddComponent<TrailRenderer>();
            TrailRenderer trail = GetComponent<TrailRenderer>();
            trail.startWidth = curveWidth;
            trail.time = 2;
            trail.receiveShadows = false;
            trail.material.SetColor("_TintColor", Color.red);

        }
        */
    }

    public void warning()
    {
        mainLight.SetActive(false);
        warningLight1.SetActive(true);
        warningLight2.SetActive(true);
        RenderSettings.fogDensity = .1f;
        RenderSettings.skybox = skyboxDark;

    }

    public void notWarning()
    {
        mainLight.SetActive(true);
        warningLight1.SetActive(false);
        warningLight2.SetActive(false);
        RenderSettings.fogDensity = .025f;
        RenderSettings.skybox = skyboxLight;

    }



}
