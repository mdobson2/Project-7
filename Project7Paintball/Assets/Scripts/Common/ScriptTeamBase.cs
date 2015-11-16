using UnityEngine;
using System.Collections;

public class ScriptTeamBase : MonoBehaviour {

    public Material redTeamMat;
    public Material blueTeamMat;
    public GameObject flagPrefab;
    public GameObject baseCollider;
    //public bool isFlagHere = true;

	// Use this for initialization
	void Start () {
	    if(tag == "RedBase" || tag == "BlueBase")
        {
            SetBaseColor(tag);
        }
        else
        {
            Debug.LogError("Base is untagged: Tag the base with RedBase or BlueBase to continue");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReturnFlag()
    {
        Debug.Log("Returned the flag");
        flagPrefab.SetActive(true);
    }

    void SetBaseColor(string colorKey)
    {
        Material tempMat = (colorKey == "RedBase") ? redTeamMat : blueTeamMat;
        string tempTag = (colorKey == "RedBase") ? "RedFlag" : "BlueFlag";
        this.GetComponent<Renderer>().material = tempMat;
        flagPrefab.transform.GetChild(0).GetComponent<Renderer>().material = tempMat;
        flagPrefab.transform.tag = tempTag;
        baseCollider.transform.tag = colorKey;
    }

    public void CheckWinCondition()
    {
        if(flagPrefab.activeInHierarchy)
        {
            Debug.Log("A winner is found");
        }
        else
        {
            Debug.Log("Flag is missing for win condition");
        }
    }
}
