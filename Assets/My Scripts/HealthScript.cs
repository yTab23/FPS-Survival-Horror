using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = SaveScript.PlayerHealth.ToString()+"%";
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.HealthChanged == true)
        {
            SaveScript.HealthChanged = false;
            healthText.text = SaveScript.PlayerHealth.ToString()+"%";
        }
    }
}
