using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ScriptWallaballNetworkManager : NetworkManager {

    public bool ready = false;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {

        StartCoroutine(WaitForTeams(conn, playerControllerId));
    }

    IEnumerator WaitForTeams(NetworkConnection conn, short playerControllerId)
    {
        while (ready == false)
        {
            yield return null;
        }

        GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player.GetComponent<Script_PlayerSync>().color = Color.red;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

    }
}
