using System.Collections;
using UnityEngine;


public class PhoneHolder : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip hangupSound;

    [SerializeField] private float hangUpDelay = 2;
    private float timer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = hangUpDelay;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Phone" && timer <= 0)
        {
            other.gameObject.GetComponent<Phone>().HangUp();
            audioSource.PlayOneShot(hangupSound);
            timer = hangUpDelay;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Phone" && timer <= 0)
        {
            other.gameObject.GetComponent<Phone>().PickUp();
            timer = hangUpDelay;
        }
    }
}