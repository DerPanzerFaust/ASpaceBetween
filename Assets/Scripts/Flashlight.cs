using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject FlashlightLight;

    public AudioSource clickSound;

    private bool FlashlightState = false; 

    private void Start()
    {
        // Zaklamp staat standaard uit
        FlashlightLight.gameObject.SetActive(false);
    }

    private void Update()
    {
        //Wanneer "F" is en de status van de zaklamp staat op "uit" dan verander "uit" naar "aan" door true
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightState == false)
            {
                FlashlightLight.gameObject.SetActive(true);
                clickSound.Play(0);
                FlashlightState = true;
            }
            else
            {
                FlashlightLight.gameObject.SetActive(false);
                clickSound.Play(0);
                FlashlightState = false;
            }
        }
    }
}
