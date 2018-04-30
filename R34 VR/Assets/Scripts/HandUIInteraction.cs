using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandUIInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finger")
        {
            Debug.Log("reee");
            this.GetComponent<Image>().color = new Color(1, 0.5f, 0.5f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Finger")
        {
            this.GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }
}
