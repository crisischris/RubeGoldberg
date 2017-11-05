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
      

        transform.position = new Vector3(transform.position.x + (Mathf.Sin(Time.time) / distance), Height, transform.position.z);
       

  

    }



}
