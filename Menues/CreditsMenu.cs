using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] GameObject creditsRef;
    public void showCredits()
    {
        creditsRef.SetActive(true);
    }

    public void hideCredits()
    {
        creditsRef.SetActive(false);
    }
}
