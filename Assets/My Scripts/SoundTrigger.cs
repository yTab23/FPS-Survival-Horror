using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    private Collider collisionBox;
    [SerializeField] private bool triggerOnce = false;
    [SerializeField] private float pauseTime = 5.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        collisionBox = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            audioSource.Play();
            collisionBox.enabled = false;

            if(triggerOnce)
            {
                StartCoroutine(Reset());
            }
            else
            {
                Destroy(gameObject, pauseTime);
            }
            
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(pauseTime);
        collisionBox.enabled = true;
    }

}
