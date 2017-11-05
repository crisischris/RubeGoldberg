using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticCurve : MonoBehaviour {

    public GameObject sphere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        Vector3 point3 = new Vector3(transform.forward.x * 15, 0, transform.forward.z * 15);

        sphere.transform.position = point3;

    }
}
