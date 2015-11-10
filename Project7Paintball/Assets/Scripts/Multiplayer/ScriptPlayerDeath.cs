using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class ScriptPlayerDeath : NetworkBehaviour {

    private Script_PlayerHealth healthScript;
    private Image crossHairImage;

    // Use this for initialization
    void Start () {

        crossHairImage = GameObject.Find("SimpleCrosshairImage").GetComponent<Image>();
        healthScript = GetComponent<Script_PlayerHealth>();
        healthScript.EventDie += DisablePlayer;
    }
	
    void OnDisable()
    {
        healthScript.EventDie -= DisablePlayer;
    }

    void DisablePlayer()
    {
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        GetComponent<ScriptPlayerShoot>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach(Renderer rend in renderers)
        {
            rend.enabled = false;
        }

        healthScript.isDead = true;

        if (isLocalPlayer)
        {
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            crossHairImage.enabled = false;
            //Respawn Button Needs to Appear.
        }
    }
}
