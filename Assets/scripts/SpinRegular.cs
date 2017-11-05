using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRegular : MonoBehaviour {


    private float spinSpeed = 250;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.Rotate(Vector3.up, Time.deltaTime * spinSpeed);


    }
}
