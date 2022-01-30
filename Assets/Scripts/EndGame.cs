using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject phoneNormal, phoneListner, UILineR, UILineL;
    [SerializeField] private int maxScore = 24;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Transform headlineHolder;
    [SerializeField] private GameObject credits;

    public void ShowHeadlines(Dictionary<CallObject, ScoreTypes> callList, int score)
    {
        phoneNormal.GetComponent<PhoneManager>().enabled = false;
        phoneListner.GetComponent<ListnerPhone>().enabled = false;
        phoneListner.GetComponent<PhoneManager>().enabled = false;
        UILineL.SetActive(true);
        UILineR.SetActive(true);

        scoreText.text = score + "/" + maxScore;
        foreach(KeyValuePair<CallObject, ScoreTypes> call in callList)
        {
            if(call.Value == ScoreTypes.WRONG)
            {
                Instantiate(call.Key.headlinePrefab, headlineHolder);
            }
        }
    }

    public void ToCredits()
    {
        credits.SetActive(true);
        gameObject.SetActive(false);
    }
}