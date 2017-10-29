using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour {

    private float spinSpeed = 500;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.Rotate((Vector3.forward * Time.deltaTime)*spinSpeed);

	}
}
