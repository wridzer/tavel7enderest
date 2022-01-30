using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhoneManager : MonoBehaviour
{
    [SerializeField] private List<CallObject> callList;
    private int callCount = 0;
    private bool done = false;
    private Phone phone;
    private ListnerPhone listnerPhone;
    [SerializeField] private GameObject antenna, endGameMenu;

    private void Awake()
    {
        phone = GetComponent<Phone>();
        listnerPhone = GetComponent<ListnerPhone>();
    }

    private void Start()
    {
        if (phone != null)
        {
            phone.GetCall(callList[callCount]);
        }
        else
        {
            listnerPhone.GetCall(callList[callCount]);
        }
    }

    public void HungUp()
    {
        callCount++;
        if(callCount == callList.Count)
        {
            ScoreKeeper.PhoneDone(callList, endGameMenu);
            done = true;
        }
        if (!done)
        {
            if (phone != null)
            {
                phone.GetCall(callList[callCount]);
            }
            else
            {
                //signal update
                antenna.GetComponent<Antenna>().NewSignal();
                listnerPhone.GetCall(callList[callCount]);
            }
        }
    }
}