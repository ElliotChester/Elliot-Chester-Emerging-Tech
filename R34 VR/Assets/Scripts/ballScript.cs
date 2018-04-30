using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowBall()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }

    public void HideBall()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }


}
