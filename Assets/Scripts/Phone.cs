using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone  : MonoBehaviour
{
    private CallObject currentCall;
    private AudioSource audioSource;
    private PhoneManager phoneManager;

    [SerializeField] AudioClip ring;
    [SerializeField] AudioClip deadLine;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        phoneManager = GetComponent<PhoneManager>();
    }

    //get call
    public void GetCall(CallObject call)
    {
        StartCoroutine(waitForRing(call));
    }

    //ring
    public void Ring(CallObject call)
    {
        currentCall = call;
        audioSource.PlayOneShot(ring);
    }

    //pick up
    public void PickUp()
    {
        audioSource.Stop();
        if(currentCall != null)
        {
            audioSource.PlayOneShot(currentCall.callSound);
        } else
        {
            audioSource.PlayOneShot(deadLine);
        }
    }

    //hang up
    public void HangUp()
    {
        audioSource.Stop();
        currentCall = null;
        phoneManager.HungUp();
    }

    private IEnumerator waitForRing(CallObject call)
    {
        yield return new WaitForSeconds(call.waitToRing);
        Ring(call);
    }
}
