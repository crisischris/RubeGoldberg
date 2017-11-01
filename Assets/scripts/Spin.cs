using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    private float spinSpeed = 250;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.RotateAround(new Vector3 (0,5,0), Vector3.up, Time.deltaTime * spinSpeed);

    }
}
