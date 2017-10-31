using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int i = 0;
    public Text countText;
    private int count;


	// Use this for initialization
	void Start () {
        i = 0;

        print(i);
        SetCountText();
	}
	
	// Update is called once per frame
	void Update () {


        
	}

    public void collected()
    {
        i = i +1;
        print("i = " + i);
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Count: " + i.ToString();
    }
}
