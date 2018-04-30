using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandUIScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowUI()
    {
        this.GetComponent<Canvas>().enabled = true;
        this.GetComponent<Animator>().SetTrigger("ShowUI");
    }

    public void StartHideUI()
    {
        this.GetComponent<Animator>().SetTrigger("HideUI");
    }

    public void HideUI()
    {
        this.GetComponent<Canvas>().enabled = false;
    }
}
