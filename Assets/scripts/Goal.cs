using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnCollisionEnter(Collision col)
    {

        //collect point
        if (col.gameObject.CompareTag("Throwable"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            SteamVR_LoadLevel.Begin("scene1", false, 2);
            
            
        }
    }
    
          
}
