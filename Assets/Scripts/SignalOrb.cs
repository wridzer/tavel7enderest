using System.Collections;
using UnityEngine;

public class SignalOrb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Antenna")
        {
            other.transform.parent.GetComponent<Antenna>().GotAntenna(gameObject);
        }
    }
}