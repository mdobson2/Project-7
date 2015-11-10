using UnityEngine;
using System.Collections;

public class ScriptFlagCatch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BlueFlag" || collision.gameObject.tag == "RedFlag")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
