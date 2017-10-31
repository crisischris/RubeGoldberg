using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public GameObject scoreManagerObject;
    public ScoreManager scoreManagerScript;


	// Use this for initialization
	void Start () {
        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreManagerScript = scoreManagerObject.GetComponent<ScoreManager>();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {

        //collect point
        if (col.gameObject.CompareTag("Throwable"))
        {            
            scoreManagerScript.collected();
            Destroy(gameObject);
            Debug.Log("collected point");
        }
    }

   
}
