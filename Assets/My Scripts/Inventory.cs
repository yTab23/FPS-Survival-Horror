using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject UIInventory;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        UIInventory.SetActive(false);
        isActive = false;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(isActive == false)
            {
                UIInventory.SetActive(true);
                isActive = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
            else if(isActive == true)
            {
                UIInventory.SetActive(false);
                isActive = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
        }
    }
}
