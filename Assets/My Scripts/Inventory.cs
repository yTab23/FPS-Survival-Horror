using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject UIInventory;
    private bool inventoryActive = false;

    [SerializeField] GameObject AppleImage1;
    [SerializeField] GameObject AppleButton1;
    [SerializeField] GameObject BatteryImage1;
    [SerializeField] GameObject BatteryButton1;
    // Start is called before the first frame update
    void Start()
    {
        UIInventory.SetActive(false);
        inventoryActive = false;
        Cursor.visible = false;

        AppleImage1.gameObject.SetActive(false);
        AppleButton1.gameObject.SetActive(false);
        BatteryImage1.gameObject.SetActive(false);
        BatteryButton1.gameObject.SetActive(false);
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
        if(SaveScript.Apples == 1)
        {
            AppleImage1.gameObject.SetActive(true);
            AppleButton1.gameObject.SetActive(true);
        }
        if(SaveScript.Batteries == 1)
        {
            BatteryImage1.gameObject.SetActive(true);
            BatteryButton1.gameObject.SetActive(true);
        }
    }

    public void HealthUpdate()
    {
        SaveScript.PlayerHealth += 10;
        SaveScript.HealthChanged = true;
        SaveScript.Apples -= 1;

        AppleImage1.gameObject.SetActive(false);
        AppleButton1.gameObject.SetActive(false);
    }
    public void BatteryUpdate()
    {
        // SaveScript.PlayerHealth += 10;
        // SaveScript.HealthChanged = true;
        // SaveScript.Apples -= 1;

        BatteryImage1.gameObject.SetActive(false);
        BatteryButton1.gameObject.SetActive(false);
    }
}
