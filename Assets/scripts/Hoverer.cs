using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverer : MonoBehaviour
{


    public float hoverForce = .1f;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {

        //Blow Ball with wind
        if (col.gameObject.CompareTag("Throwable"))
        {
            col.transform.SetParent(null);
            Debug.Log("Hover baby");



        }
    }
}

