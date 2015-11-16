﻿using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// @Author: Andrew Seba
/// @Description: Syncs player movement across the network.
/// </summary>
public class Script_PlayerSync : NetworkBehaviour {

    [SyncVar]
    Vector3 syncedPosition;
    [SyncVar]
    Quaternion syncedRotation;

    #region variables
    [SyncVar]
    public string myName;

    [SyncVar]
    public Color color;

    [Header("\tReference Values")]
    public Transform myTransform;

    [Header("\tValues for Client Management")]
    [Header("Player")]
    public Rigidbody myRigidbody;
    public CapsuleCollider myCollider;
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController myController;
    [Header("Camera")]
    public GameObject myCameraObject;
    public Camera myCamera;
    public AudioListener myListener;

    [Header("\tSync Values")]
    [Header("Rotation")]
    public float rotationLerpRate = 15f;
    public float rotationThreshold = 5f;
    [Header("Position")]
    public float positionLerpRate = 15f;
    public float positionThreshold = 0.3f;

    public Text aboveHeadName;

    Quaternion lastPlayerRotation;
    Vector3 lastPlayerPosition;
    #endregion

    //probably shouldn't be in this script
    bool pauseMenu = false;


    [Command]
    void CmdSetName(string pName)
    {
        myName = pName;
        aboveHeadName.text = myName;
    }

    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(myController);
            Destroy(myRigidbody);
            //Destroy(myCollider);
            Destroy(myCameraObject);
        }
        else
        {
            GameObject manager = GameObject.Find("Network Manager");
            myName = manager.GetComponent<ScriptMyName>().myName;
            CmdSetName(myName);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //disable SpectatorCamera
            if (GameObject.Find("SpectatorCamera"))
                GameObject.Find("SpectatorCamera").SetActive(false);

            if (GameObject.Find("ButtonStartGame") != null)
            {
                GameObject.Find("ButtonStartGame").SetActive(false);
            }
        }
        aboveHeadName.text = myName;
    }

    void FixedUpdate()
    {
        if(isLocalPlayer)
        {
            TransmitRotation();
            TransmitPosition();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (!isLocalPlayer)
        {
            LerpRotation();
            LerpPosition();
        }


        //lets you gain curor visibility to escape
        if (Input.GetButtonDown("Cancel"))
        {
            if (pauseMenu)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            pauseMenu = !pauseMenu;
        }
	}

    #region rotation
    [Client]
    void TransmitRotation()
    {
        if(Quaternion.Angle(myTransform.rotation, lastPlayerRotation) > rotationThreshold)
        {
            lastPlayerRotation = myTransform.rotation;
            CmdSendRotationToServer(myTransform.rotation);
        }
    }

    [Command]
    void CmdSendRotationToServer(Quaternion rotationToSend)
    {
        syncedRotation = rotationToSend;
    }


    void LerpRotation()
    {
        myTransform.rotation = Quaternion.Lerp(myTransform.rotation, syncedRotation, Time.deltaTime * rotationLerpRate);
    }
    #endregion

    #region position
    [Client]
    void TransmitPosition()
    {
        lastPlayerPosition = myTransform.position;
        CmdSendPositionToServer(myTransform.position);
    }

    [Command]
    void CmdSendPositionToServer(Vector3 positionToSend)
    {
        syncedPosition = positionToSend;
    }

    void LerpPosition()
    {
        myTransform.position = Vector3.Lerp(myTransform.position, syncedPosition, Time.deltaTime * positionLerpRate);
    }
    #endregion

}
