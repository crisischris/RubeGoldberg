using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour {

   // public SteamVR_LoadLevel loadLevel;
    public List <GameObject> objectList;
    public List<GameObject> objectPrebabList;
    public GameObject clone;

    public int currentObject = 0;

	// Use this for initialization
	void Start () {
        foreach(Transform child in transform)
        {
            objectList.Add(child.gameObject);
            
        }
		
	}

    public void MenuLeft()
    {
        objectList[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0)
        {
            currentObject = objectList.Count - 1;
        }
        objectList[currentObject].SetActive(true);

    }

    public void MenuRight()
    {
        objectList[currentObject].SetActive(false);
        currentObject++;
        if (currentObject > objectList.Count-1)
        {
            currentObject = 0;
        }
        objectList[currentObject].SetActive(true);

    }

    public void SpawnCurrentObject()
    {
        clone = Instantiate(objectPrebabList[currentObject], objectList[currentObject].transform.position, objectList[currentObject].transform.rotation);
        clone.tag = "Structure";
        clone.AddComponent<BoxCollider>();
        clone.AddComponent<Rigidbody>();
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.mass = 10;

        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

       // loadLevel.Trigger();
    }

    public void showNone()
    {
        objectList[currentObject].SetActive(false);

    }





// Update is called once per frame
void Update () {
		
	}
}
