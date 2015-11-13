using UnityEngine;
using System.Collections;

public class ScriptGameManager_References : MonoBehaviour {

    public GameObject respawnButton;
    public GameObject splatParticle;
    public ScriptWallaballNetworkManager manager;

    void Start()
    {
        manager = GameObject.Find("Network Manager").GetComponent<ScriptWallaballNetworkManager>();
    }

    public void CustomServerSpawn()
    {
        manager.ready = true;
    }
}
