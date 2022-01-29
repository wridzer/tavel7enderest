using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListnerPhone : MonoBehaviour
{
    private CallObject currentCall;
    private AudioSource audioSource;
    private PhoneManager phoneManager;
    private float hangUpDelay = 1f;
    [SerializeField] private GameObject phoneHolder;

    [SerializeField] private float volume;

    [SerializeField] private AudioClip deadLine;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        phoneManager = GetComponent<PhoneManager>();
    }

    private void Start()
    {
        audioSource.volume = 0;
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
        audioSource.PlayOneShot(currentCall.callSound);
    }

    //pick up
    public void PickUp()
    {
        if (currentCall != null)
        {
            audioSource.volume = volume;
        }
        else
        {
            audioSource.PlayOneShot(deadLine);
        }
    }

    //hang up
    public void HangUp()
    {
        audioSource.volume = 0;
    }

    private IEnumerator waitForRing(CallObject call)
    {
        yield return new WaitForSeconds(call.waitToRing);
        Ring(call);
    }
}
