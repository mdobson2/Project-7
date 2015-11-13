using UnityEngine;
using UnityEngine.Networking;

public enum Team
{
    BLUE,
    RED,
    DEATHMATCH
}

public class ScriptPlayerTeam : NetworkBehaviour {

    public Team myTeam = Team.DEATHMATCH;
}
