using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScriptPlayerRespawn : NetworkBehaviour {

    private Script_PlayerHealth healthScript;
    private Image crossHairImage;
    private GameObject respawnButton;

	// Use this for initialization
	void Start () {
        healthScript = GetComponent<Script_PlayerHealth>();
        healthScript.EventRespawn += EnablePlayer;
        crossHairImage = GameObject.Find("SimpleCrosshairImage").GetComponent<Image>();
        SeRespawnButton();
	}
	
    void SeRespawnButton()
    {
        if (isLocalPlayer)
        {
            respawnButton = GameObject.Find("GameManager").GetComponent<ScriptGameManager_References>().respawnButton;
            respawnButton.GetComponent<Button>().onClick.AddListener(CommenceRespawn);
            respawnButton.SetActive(false);
        }
    }

    void OnDisable()
    {
        healthScript.EventRespawn -= EnablePlayer;
    }

    void EnablePlayer()
    {
        GetComponent<ScriptPlayerShoot>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;

        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer rend in renderers)
        {
            rend.enabled = true;
        }

        if (isLocalPlayer)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
            crossHairImage.enabled = true;
        }
    }

    void CommenceRespawn()
    {
        CmdRespawnOnServer();
    }

    [Command]
    void CmdRespawnOnServer()
    {
        healthScript.ResetHealth();
    }
}
