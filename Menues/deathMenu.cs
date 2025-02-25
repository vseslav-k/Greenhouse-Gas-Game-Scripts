using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathMenu : MonoBehaviour
{

    [SerializeField] GameObject deathMenuRef;

    void Start()
    {
        followMouse.died += PlayerDiedListener;
    }


    private void OnDisable()
    {
        followMouse.died -= PlayerDiedListener;
    }

    void PlayerDiedListener()
    {
        deathMenuRef.SetActive(true);
        Time.timeScale = 0;
    }



}
