using UnityEngine;
using System.Collections;

public class ScriptFlagCatch : MonoBehaviour {

    bool isCarryFlag = false;
    public GameObject carryFlag;
    public Material redFlag;
    public Material blueFlag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(!isCarryFlag)
        {
            if(other.transform.parent.tag == "BlueFlag" || other.transform.parent.tag == "RedFlag")
            {
                other.transform.parent.gameObject.SetActive(false);
                SetFlagCarry(true);
                SetFlagColor(other.transform.parent.tag);
            }
        }
    }

    public void SetFlagCarry(bool state)
    {
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
}
