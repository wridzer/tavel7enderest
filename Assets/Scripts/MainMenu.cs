using System.Collections;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject phoneNormal, phoneListner, UILineR, UILineL;

    public void StartGame()
    {
        //start phones ring
        phoneNormal.GetComponent<PhoneManager>().enabled = true;
        phoneListner.GetComponent<ListnerPhone>().enabled = true;
        phoneListner.GetComponent<PhoneManager>().enabled = true;
        UILineL.SetActive(false);
        UILineR.SetActive(false);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}