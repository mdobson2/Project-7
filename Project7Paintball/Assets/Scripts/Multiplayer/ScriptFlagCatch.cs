using UnityEngine;
using System.Collections;

/// <summary>
/// @Author: Mike
/// </summary>
public class ScriptFlagCatch : MonoBehaviour {

    public bool isCarryFlag = false;
    public GameObject carryFlag;
    public Material redFlag;
    public Material blueFlag;
    public GameObject flagPrefab;

    public GameObject blueBase;
    public GameObject redBase;

    public bool carryBlueFlag = false;
	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("BlueBase"))
        {
            blueBase = GameObject.FindGameObjectWithTag("BlueBase");
        }
        else
        {
            Debug.LogError("No Blue Base in game scene: Add a game object to the scene and tag it BlueBase");
        }

        if (GameObject.FindGameObjectWithTag("RedBase"))
        {
            redBase = GameObject.FindGameObjectWithTag("RedBase");
        }
        else
        {
            Debug.LogError("No Red Base in game scene: Add a game object to the scene and tag it RedBase");
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(!isCarryFlag)
        {
            if(other.transform.parent != null)
            {
                if (other.transform.parent.tag == "BlueFlag" || other.transform.parent.tag == "RedFlag")
                {
                    Debug.Log("Hit the " + other.transform.parent.tag);
                    other.transform.parent.gameObject.SetActive(false);
                    SetFlagCarry(true);
                    SetFlagColor(other.transform.parent.tag);
                    //other.GetComponentInParent<ScriptTeamBase>().CatchFlag();
                    if(other.transform.parent.tag == "BlueFlag")
                    {
                       carryBlueFlag = true;
                    }
                    else
                    {
                        carryBlueFlag = false;
                    }
                }
            }
        }
    }

    public void SetFlagCarry(bool state)
    {
        Debug.Log("Setting the player flag to " + state);
        isCarryFlag = state;

        if(carryFlag != null)
        {
            if(state)
            {
                carryFlag.SetActive(true);
            }
            else
            {
                carryFlag.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("Flag object not set on player");
        }
    }

    public void SetFlagColor(string colorKey)
    {
        if(colorKey == "RedFlag")
        {
            carryFlag.transform.GetChild(0).GetComponent<Renderer>().material = redFlag;
        }
        else
        {
            carryFlag.transform.GetChild(0).GetComponent<Renderer>().material = blueFlag;
        }
    }

    public void DropFlag()
    {
        //Instantiate(flagPrefab, transform.position, Quaternion.identity);
    }
}
