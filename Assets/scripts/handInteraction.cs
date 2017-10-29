using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handInteraction : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;
    public float throwForce = 1.5f;
    public ushort pulesStregnth =  3000;

    public GameObject controllerModel;

    public float posXatThrow;
    public float posYatThrow;
    public float posZatThrow;

    public bool isGrabbingBall = false;
    

    // Use this for initialization
    void Start () {

        trackedObj = GetComponent<SteamVR_TrackedObject>();   
    }
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }    

    void OnTriggerStay(Collider col)
    {
       if (col.gameObject.CompareTag("Throwable"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                
            
                ThrowObject(col);
                controllerModel.SetActive(true);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabObjectBall(col);              
                controllerModel.SetActive(false);
            }           
        }
        if (col.gameObject.CompareTag("Structure"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                dropObjectInteractive(col);
                controllerModel.SetActive(true);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                GrabObject(col);
                controllerModel.SetActive(false);
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

    void dropObjectInteractive(Collider col)
    {
        col.transform.SetParent(null);
        Rigidbody rigidBody = col.GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        isGrabbingBall = false;
        // Debug.Log("you have dropped the object");

    }
}
