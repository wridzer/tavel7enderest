using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhoneManager : MonoBehaviour
{
    private List<CallObject> callList;
    private int callCount = 0;
    private Phone phone;

    private void Awake()
    {
        callList.Add(Resources.Load<CallObject>("Calls"));
        phone = GetComponent<Phone>();
    }

    private void Start()
    {
        phone.GetCall(callList[callCount]);
    }

    public void HungUp()
    {
        callCount++;
        phone.GetCall(callList[callCount]);
    }
}