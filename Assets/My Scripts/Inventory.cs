using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject UIInventory;
    private bool inventoryActive = false;

    //Apples
    [SerializeField] GameObject[] AppleIcons;
    [SerializeField] GameObject[] AppleButtons;

    //Batteries
    [SerializeField] GameObject[] BatteryIcons;
    [SerializeField] GameObject[] BatteryButtons;
    // Start is called before the first frame update
    void Start()
    {
        UIInventory.SetActive(false);
        inventoryActive = false;
        Cursor.visible = false;

        foreach(GameObject icon in BatteryIcons)
        {
            icon.SetActive(false);
        }

        foreach(GameObject button in BatteryButtons)
        {
            button.SetActive(false);
        }

        foreach(GameObject icon in AppleIcons)
        {
            icon.SetActive(false);
        }

        foreach(GameObject button in AppleButtons)
        {
            button.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryActive == false)
            {
                UIInventory.SetActive(true);
                inventoryActive = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if(inventoryActive == true)
            {
                UIInventory.SetActive(false);
                inventoryActive = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        CheckInventory();
        
    }

    private void CheckInventory()
    {
        if(SaveScript.Batteries == Mathf.Clamp(SaveScript.Batteries, 1, 4))
        {
           for(var i = 0; i < SaveScript.Batteries; i++)
           {
                BatteryIcons[i].gameObject.SetActive(true);
                BatteryButtons[i].gameObject.SetActive(true);
           }
        }

        if(SaveScript.Apples == Mathf.Clamp(SaveScript.Apples, 1, 6))
        {
           for(var i = 0; i < SaveScript.Apples; i++)
           {
                AppleIcons[i].gameObject.SetActive(true);
                AppleButtons[i].gameObject.SetActive(true);
           }
        }
    }

    public void HealthUpdate()
    {
        SaveScript.PlayerHealth += 10;
        SaveScript.HealthChanged = true;
        SaveScript.Apples -= 1;

        AppleIcons[SaveScript.Apples].gameObject.SetActive(false);
        AppleButtons[SaveScript.Apples].gameObject.SetActive(false);
    }
    public void BatteryUpdate()
    {
        SaveScript.BatteryRefill = true;
        SaveScript.Batteries -= 1;

        BatteryIcons[SaveScript.Batteries].gameObject.SetActive(false);
        BatteryButtons[SaveScript.Batteries].gameObject.SetActive(false);
    }
}
