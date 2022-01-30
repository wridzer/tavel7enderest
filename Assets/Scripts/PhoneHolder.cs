using System.Collections;
using UnityEngine;


public class PhoneHolder : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip hangupSound;
    [SerializeField] private AudioClip ring;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Phone")
        {
            audioSource.Stop();
            other.gameObject.GetComponent<Phone>().HangUp();
            audioSource.PlayOneShot(hangupSound);
        }
        if (other.tag == "ListnerPhone")
        {
            audioSource.Stop();
            other.gameObject.GetComponent<ListnerPhone>().HangUp();
            audioSource.PlayOneShot(hangupSound);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Phone")
        {
            audioSource.Stop();
            other.gameObject.GetComponent<Phone>().PickUp();
        }
        if(other.tag == "ListnerPhone")
        {
            audioSource.Stop();
            other.gameObject.GetComponent<ListnerPhone>().PickUp();
        }
    }

    public void Ring()
    {
        audioSource.PlayOneShot(ring);
    }
}