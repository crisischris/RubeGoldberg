using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class handInteraction : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;
    public float throwForce = 1f;
    public ushort pulesStregnth = 3000;

    public GameObject controllerModel;
    public GameObject controllerTextMenu;
    public GameObject[] objectsToDelete;




    public float posXatThrow;
    public float posYatThrow;
    public float posZatThrow;

    public bool isGrabbingBall = false;


    //Swipe

    public float swipeSum;
    public float touchLast;
    public float touchCurrent;
    public float distance;
    public bool hasSwipedLeft;
    public bool hasSwipedRight;
    public ObjectMenuManager objectMenuManager;
    public BallPhysics ballPhysics;



    // Use this for initialization
    void Start() {

        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    // Update is called once per frame
    void Update() {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (trackedObj.GetComponentInChildren<ObjectMenuManager>() == true)

        {
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {

            touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
        }

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))

        {
            touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            distance = touchCurrent - touchLast;
            touchLast = touchCurrent;
            swipeSum += distance;
            if (!hasSwipedRight)
            {
                if (swipeSum > 0.5f)
                {
                    swipeSum = 0;
                    SwipeRight();
                    hasSwipedRight = true;
                    hasSwipedLeft = false;
                }
            }

            if (!hasSwipedLeft)
            {
                if (swipeSum < -0.5f)
                {
                    swipeSum = 0;
                    SwipeLeft();
                    hasSwipedLeft = true;
                    hasSwipedRight = false;
                }
            }
        }

        //reset all vars if finger is lifted

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            swipeSum = 0;
            touchCurrent = 0;
            touchLast = 0;
            hasSwipedLeft = false;
            hasSwipedRight = false;
            objectMenuManager.showNone();
        }


        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Spawn obj currently selected by menu

            SpawnObject();

        }

    }
        
}



    void SpawnObject()
    {
        objectMenuManager.SpawnCurrentObject();
    }

    void SwipeLeft()
    {
        objectMenuManager.MenuLeft();
        Debug.Log("SwipeLeft");

    }

    void SwipeRight()
    {
        objectMenuManager.MenuRight();
        Debug.Log("SwipeRight");
    }

    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.CompareTag("Throwable"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                ThrowObject(col);
                controllerModel.SetActive(true);
                controllerTextMenu.SetActive(true);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabObjectBall(col);
                controllerModel.SetActive(false);
                controllerTextMenu.SetActive(false);
            }
        }
        if (col.gameObject.CompareTag("Structure"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                dropObjectStructure(col);
                controllerModel.SetActive(true);
                controllerTextMenu.SetActive(true);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabObject(col);
                controllerModel.SetActive(false);
                controllerTextMenu.SetActive(false);
            }

        }

        if (col.gameObject.CompareTag("Interactive"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                dropObjectStructure(col);
                controllerModel.SetActive(true);
                controllerTextMenu.SetActive(true);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabObject(col);
                controllerModel.SetActive(false);
                controllerTextMenu.SetActive(false);
            }
        }

        if (col.gameObject.CompareTag("Deleter"))
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                deleteObjects();
            }
        }

        if (col.gameObject.CompareTag("Restarter"))
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                restartLevel();
            }
        }
    }
    
     void GrabObjectBall(Collider col)
    {
       
        col.transform.SetParent(gameObject.transform);
        col.GetComponent<Rigidbody>().isKinematic = true;
        device.TriggerHapticPulse(pulesStregnth);
        isGrabbingBall = true;


        // Debug.Log("you are touching down the trigger on an object");

    }

    void GrabObject(Collider col)
    {

        col.transform.SetParent(gameObject.transform);
        col.GetComponent<Rigidbody>().isKinematic = true;
        device.TriggerHapticPulse(pulesStregnth);


        // Debug.Log("you are touching down the trigger on an object");

    }



    void ThrowObject(Collider col)
    {

        ballPhysics.sources[1].Play();
        col.transform.SetParent(null);        
        Rigidbody rigidBody = col.GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.velocity = device.velocity * throwForce;
        rigidBody.angularVelocity = device.angularVelocity;        
        isGrabbingBall = false;
               
        


        //  Debug.Log("you have released the trigger");


    }  

    void dropObject(Collider col)
    {
        col.transform.SetParent(null);
        Rigidbody rigidBody = col.GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.velocity = device.velocity * .9f;
        rigidBody.angularVelocity = device.angularVelocity;
        isGrabbingBall = false;
        // Debug.Log("you have dropped the object");

    }

    void dropObjectStructure(Collider col)
    {
        col.transform.SetParent(null);
        Rigidbody rigidBody = col.GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        isGrabbingBall = false;
        // Debug.Log("you have dropped the object");

    }

    void dropObjectInteractive(Collider col)
    {
        col.transform.SetParent(null);
        Rigidbody rigidBody = col.GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;
        rigidBody.velocity = device.velocity * .9f;
        rigidBody.angularVelocity = device.angularVelocity;

    }

    //delete objects with Structure tag

    public void deleteObjects()
    {
        device.TriggerHapticPulse(pulesStregnth);
        print("you clicked the sphere of deletion");
        objectsToDelete = GameObject.FindGameObjectsWithTag("Structure");

        for(int i =0; i < objectsToDelete.Length; i++)
        {
            Destroy(objectsToDelete[i]);

        }       

    }

    public void restartLevel()
    {
        device.TriggerHapticPulse(pulesStregnth);
        Scene activeScene = SceneManager.GetActiveScene();
        SteamVR_LoadLevel.Begin(activeScene.name, false, 2);

    }
}
