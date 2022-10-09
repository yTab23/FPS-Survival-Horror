using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float Distance = 4.0f;
    [SerializeField] GameObject PickupMessage;

    private float RayDistance;
    private bool CanSeePickup = false;

    void Start()
    {
        PickupMessage.gameObject.SetActive(false);
        RayDistance = Distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
        {
            if(hit.transform.tag == "Apple" && SaveScript.Apples < 6)
            {
                CanSeePickup = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.transform.gameObject);
                    SaveScript.Apples += 1;
                }
            }
            else if(hit.transform.tag == "Battery" && SaveScript.Batteries < 4)
            {
                CanSeePickup = true;
                if(Input.GetKeyDown(KeyCode.E) )
                {
                    Destroy(hit.transform.gameObject);
                    SaveScript.Batteries += 1;
                }
            }
            else
            {
                CanSeePickup = false;
            }
        }

        if(CanSeePickup == true)
        {
            PickupMessage.gameObject.SetActive(true);
            RayDistance = 1000f;
        }

        if(CanSeePickup == false)
        {
            PickupMessage.gameObject.SetActive(false);
            RayDistance = Distance;
        }
    }
}
