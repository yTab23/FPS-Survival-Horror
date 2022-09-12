using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit))
            {
                if(hit.transform.CompareTag("Carryable"))
                {
                    this.transform.parent = hit.transform;
                }
            }
            
        }
    }
}
