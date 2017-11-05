using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int i = 0;
    public Text countText;
    public GameObject goal;
    public Material skyboxBlack;



	// Use this for initialization
	void Start () {
        i = 0;

        print(i);
        SetCountText();
        
	}
	
	// Update is called once per frame
	void Update () {

        if(i == 5)
        {
            RenderSettings.fogDensity = .5f;
            RenderSettings.skybox = skyboxBlack;
            goal.SetActive(true);
          
        }


    }

    public void collected()
    {
        i = i +1;
        print("i = " + i);
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Collected " + i.ToString()+"/5";
    }
}
