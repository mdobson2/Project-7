using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ScriptSpectatorInit : NetworkBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (!isServer)
        {
            if (GameObject.Find("ButtonStartGame") != null)
            {
                GameObject.Find("ButtonStartGame").SetActive(false);
            }
        }
    }
}
