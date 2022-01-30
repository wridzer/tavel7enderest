using System.Collections;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    [SerializeField] private GameObject[] signalPoints;
    private GameObject bestSignal;

    private AudioSource audioSource;
    [SerializeField] private AudioClip distortion;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bestSignal = signalPoints[Random.Range(0, signalPoints.Length - 1)];
    }

    public void NewSignal()
    {
        bestSignal = signalPoints[Random.Range(0, signalPoints.Length - 1)];
    }

    public void GotAntenna(GameObject orb)
    {
        if (orb != bestSignal)
        {
            DistortAudio();
        }
        else
        {
            Debug.Log("Right one!");
        }
    }

    private void DistortAudio()
    {
        //audioSource.PlayOneShot(distortion);
        Debug.Log("Wrong one!");
    }
}