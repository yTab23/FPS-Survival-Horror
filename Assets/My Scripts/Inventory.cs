using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject UIInventory;
    private bool inventoryActive = false;
    // Start is called before the first frame update
    void Start()
    {
        UIInventory.SetActive(false);
        inventoryActive = false;
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
    }
}
