using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public AudioSource[] sources;

    // Use this for initialization
    void Start()
    {
        
        sources[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        int sceneNow = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("the current scene is" + sceneNow);
    }
    void OnCollisionEnter(Collision col)
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("you are in scene index" + activeScene);

        if (col.gameObject.CompareTag("Throwable"))
        {
            if (activeScene == 0)
            {
                sources[0].Stop();
                sources[1].Play();
                SteamVR_LoadLevel.Begin("scene0", false, 2);
            }
            if (activeScene == 1)
            {
                sources[0].Stop();
                sources[1].Play();
                SteamVR_LoadLevel.Begin("scene1", false, 2);
            }
            if (activeScene == 2)
            {
                sources[0].Stop();
                sources[1].Play();
                SteamVR_LoadLevel.Begin("scene2", false, 2);
            }
            if (activeScene == 3)
            {
                sources[0].Stop();
                sources[1].Play();
                SteamVR_LoadLevel.Begin("scene3", false, 2);
            }
            if (activeScene == 4)
            {
                sources[0].Stop();
                sources[1].Play();
                SteamVR_LoadLevel.Begin("Intro", false, 2);
            }
        }
    }
}

