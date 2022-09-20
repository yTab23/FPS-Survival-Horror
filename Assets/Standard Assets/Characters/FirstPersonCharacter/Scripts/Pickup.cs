using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Transform playerCarryTransform;

    private bool isCarrying = false;

    void OnKeyDown()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {   
            if(isCarrying == false)
            {
                GetComponent<BoxCollider>().enabled = false;
                this.transform.position = playerCarryTransform.position;
                this.transform.parent = GameObject.Find("CarryObject").transform;
                GetComponent<Rigidbody>().isKinematic = true;
                isCarrying = true;
            }
            else
            {
                this.transform.parent = null;
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<Rigidbody>().isKinematic = false;
                isCarrying = false;
            }
        }
    }
}
