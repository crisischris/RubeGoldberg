using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handControllerInput : MonoBehaviour
{

    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;


    //teleporter

    private LineRenderer laser;
    public GameObject teleporterAimerObject;
    public Vector3 teleportLocation;
    public GameObject player;
    public LayerMask laserMask;
    public float Height = 1f; // specific to teleportAimerObject height;

    ////////////////////////Dash////////////////////////
    /*
    public float dashSpeed = 0.1f;
    private bool isDashing;
    private float lerpTime;
    private Vector3 dashStartPosition;
    */

    //walking
    public Transform playerCam;
    public float moveSpeed = 5f;
    private Vector3 movementDirection;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        laser = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            movementDirection = playerCam.transform.forward;
            movementDirection = new Vector3(movementDirection.x, 0, movementDirection.z);
            movementDirection = movementDirection * moveSpeed * Time.deltaTime;
            player.transform.position += movementDirection;
        }

        ////////////////////////Dash////////////////////////
        /*
            if (isDashing)
            {
                lerpTime += Time.deltaTime* dashSpeed;
                player.transform.position = Vector3.Lerp(dashStartPosition, teleportLocation, lerpTime);
                if(lerpTime >= 1)
                {
                    isDashing = false;
                    lerpTime = 0;
                }

    
            }
            else
            {

    */
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    print("pressing down");

                    laser.gameObject.SetActive(true);
                    teleporterAimerObject.SetActive(true);

                    laser.SetPosition(0, gameObject.transform.position);
                    RaycastHit hit;


                    if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
                    {
                        teleportLocation = hit.point;
                        laser.SetPosition(1, teleportLocation);
                        teleporterAimerObject.transform.position = new Vector3(teleportLocation.x, teleportLocation.y + Height, teleportLocation.z);
                    }

                    else
                    {
                        teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 + transform.position.y, transform.forward.z * 15 + transform.position.z);
                        RaycastHit groundRay;

                        if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, laserMask))
                        {
                            teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, groundRay.point.y, transform.forward.z * 15 + transform.position.z);



                        }

                        laser.SetPosition(1, transform.forward * 15 + transform.position);
                        teleporterAimerObject.transform.position = teleportLocation + new Vector3(0, Height, 0);


                    }
                }



                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    laser.gameObject.SetActive(false);
                    teleporterAimerObject.SetActive(false);
                    player.transform.position = teleportLocation;   
                   // dashStartPosition = player.transform.position;
                    //isDashing = true;

                }
            }



            }
////////////////////////Dash////////////////////////      }



