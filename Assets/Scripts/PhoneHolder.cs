using System.Collections;
using UnityEngine;


public class PhoneHolder : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip hangupSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Phone")
        {
            other.gameObject.GetComponent<Phone>().HangUp();
            audioSource.PlayOneShot(hangupSound);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Phone")
        {
            other.gameObject.GetComponent<Phone>().PickUp();
        }
    }
}