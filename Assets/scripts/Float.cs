using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour 
{

  
    public float Height;
    public float distance;

    void Start()
    {

        

    }



    void Update()
	{
        // occilate the Y position
      

        transform.position = new Vector3(transform.position.x, (Height) + (Mathf.Sin(Time.time)/distance), transform.position.z);
       

  

    }



}
