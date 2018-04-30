using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionScript : MonoBehaviour {

    public enum InteractMethod
    {
        LookAt,
        Point
    }

    public InteractMethod interactMethod;

    public LayerMask interactWith;
    public Transform fingerPoint;

    public string sceneName;

    public Image fadeImage;

    float interactTimer = 0;

    GameObject lastPressedButton;

    public bool extended = false;

	void Update ()
    {
        switch (interactMethod) 
        {
            case InteractMethod.LookAt:
                LookInteraction();
                break;
            case InteractMethod.Point:
                PointInteraction();
                break;
        }
    }

    void PointInteraction()
    {
        RaycastHit hit;

        Ray ray = new Ray(this.transform.position, fingerPoint.transform.position - this.transform.position);

        Debug.DrawRay(this.transform.position, (fingerPoint.transform.position - this.transform.position) * 10, Color.red, 10);
        if (extended)
        {
            if (Physics.Raycast(ray, out hit, 100, interactWith))
            {
                fingerPoint.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                lastPressedButton = hit.transform.gameObject;
                //lastPressedButton.GetComponent<Image>().color = new Color(1, 0.5f, 0.5f);

                interactTimer += Time.deltaTime;
                Slider slider = lastPressedButton.GetComponentInChildren<Slider>();
                slider.value = interactTimer;

                if (interactTimer >= slider.maxValue)
                {
                    ButtonInteract();
                }
            }
            else
            {
                interactTimer = 0;
                if (lastPressedButton != null)
                {
                    //lastPressedButton.GetComponent<Image>().color = new Color(255, 255, 255);
                    Slider slider = lastPressedButton.GetComponentInChildren<Slider>();
                    slider.value = interactTimer;
                }
                

                fingerPoint.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
        else
        {
            interactTimer = 0;
            if (lastPressedButton != null)
            {
                //lastPressedButton.GetComponent<Image>().color = new Color(255, 255, 255);
                Slider slider = lastPressedButton.GetComponentInChildren<Slider>();
                slider.value = interactTimer;
            }
            
        }
    }

    void LookInteraction()
    {
        RaycastHit hit;

        Ray ray = new Ray(this.transform.position, transform.forward);

        Debug.DrawRay(this.transform.position, (transform.forward) * 10, Color.red, 10);

        if (Physics.Raycast(ray, out hit, 100, interactWith))
        {
            lastPressedButton = hit.transform.gameObject;
            //lastPressedButton.GetComponent<Image>().color = new Color(1, 0.5f, 0.5f);
            interactTimer += Time.deltaTime;
            Slider slider = lastPressedButton.GetComponentInChildren<Slider>();
            slider.value = interactTimer;

            if(interactTimer >= slider.maxValue)
            {
                ButtonInteract();
            }
        }
        else
        {
            interactTimer = 0;
            if (lastPressedButton != null)
            {
                Slider slider = lastPressedButton.GetComponentInChildren<Slider>();
                slider.value = interactTimer;
            }

            
        }
    }

    void ButtonInteract()
    {
        fadeImage.gameObject.GetComponent<Animator>().SetTrigger("Fade");
    }

    public void Extend()
    {
        fingerPoint.gameObject.SetActive(true);
        extended = true;
    }

    public void UnExtend()
    {
        fingerPoint.gameObject.SetActive(false);
        extended = false;
    }
}
