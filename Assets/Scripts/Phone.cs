using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    private CallObject currentCall;
    private AudioSource audioSource;
    private PhoneManager phoneManager;
    private bool isCalling = false;
    private float hangUpDelay = 1f;
    [SerializeField] private GameObject phoneHolder;

    [SerializeField] private AudioClip deadLine;

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
        phoneHolder.GetComponent<PhoneHolder>().Ring();
    }

    //pick up
    public void PickUp()
    {
        audioSource.Stop();
        if(currentCall != null)
        {
            audioSource.PlayOneShot(currentCall.callSound);
            StartCoroutine(HangUpDelay());
        } else
        {
            audioSource.PlayOneShot(deadLine);
        }
    }

    //hang up
    public void HangUp()
    {
        if (isCalling)
        {
            audioSource.Stop();
            currentCall = null;
            phoneManager.HungUp();
            isCalling = false;
        }
    }

    private IEnumerator waitForRing(CallObject call)
    {
        yield return new WaitForSeconds(call.waitToRing);
        Ring(call);
    }
    private IEnumerator HangUpDelay()
    {
        yield return new WaitForSeconds(hangUpDelay);
        isCalling = true;
    }
}
