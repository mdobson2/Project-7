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
        if (GameObject.Find("Network Manager") != null)
            manager = GameObject.Find("Network Manager").GetComponent<ScriptWallaballNetworkManager>();
        else
            Debug.Log("You need to start the game in the title scene.");
        
    }

    public void _SpawnAllPlayers()
    {
        manager.SpawnAllPlayers();
    }

}
