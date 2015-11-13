using UnityEngine;
using System.Collections;

public class ScriptGameManager_References : MonoBehaviour {

    public GameObject respawnButton;
    public GameObject splatParticle;

    public GameObject joinBlueButton;
    public GameObject joinRedButton;

    public GameObject startGameButton;

    public ScriptWallaballNetworkManager manager;

    void Start()
    {
        manager = GameObject.Find("Network Manager").GetComponent<ScriptWallaballNetworkManager>();
        
    }

    public void _SpawnAllPlayers()
    {
        manager.SpawnAllPlayers();
    }

}
