using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal : MonoBehaviour {

    public AudioSource[] sources;

	// Use this for initialization
	void Start () {

        sources[0].Play();

    }
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnCollisionEnter(Collision col)
    {
        Scene activeScene = SceneManager.GetActiveScene();

        if (col.gameObject.CompareTag("Throwable"))
        {
            if(activeScene.name == "scene0")
            sources[0].Stop();
            sources[1].Play();            
            SteamVR_LoadLevel.Begin("scene1", false, 2);
        }

        if (col.gameObject.CompareTag("Throwable"))
        {
            if (activeScene.name == "scene1")
                sources[0].Stop();
            sources[1].Play();
            SteamVR_LoadLevel.Begin("scene2", false, 2);
        }

        if (col.gameObject.CompareTag("Throwable"))
        {
            if (activeScene.name == "scene2")
                sources[0].Stop();
            sources[1].Play();
            SteamVR_LoadLevel.Begin("scene3", false, 2);
        }

        if (col.gameObject.CompareTag("Throwable"))
        {
            if (activeScene.name == "scene3")
                sources[0].Stop();
            sources[1].Play();
            SteamVR_LoadLevel.Begin("scene0", false, 2);
        }

        if (col.gameObject.CompareTag("Throwable"))
        {
            if (activeScene.name == "Intro")
                sources[0].Stop();
            sources[1].Play();
            SteamVR_LoadLevel.Begin("scene0", false, 2);
        }

    }
    
          
}
