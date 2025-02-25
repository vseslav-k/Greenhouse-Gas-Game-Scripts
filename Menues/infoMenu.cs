using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoMenu : MonoBehaviour
{
    [SerializeField] GameObject infoMenuRef;

    [SerializeField] Sprite[] infoSheets;
    int currInfoSheet;

    [SerializeField] Image image;

    private void Start()
    {
        currInfoSheet = 0;
        image.sprite = infoSheets[currInfoSheet];
    }

    public void advanceImage()
    {
        if(currInfoSheet < infoSheets.Length - 1)
        {
            currInfoSheet++;
            image.sprite = infoSheets[currInfoSheet];
        }
    }
    public void backtrackImage()
    {
        if (currInfoSheet > 0)
        {
            currInfoSheet--;
            image.sprite = infoSheets[currInfoSheet];
        }
    }

    public void infoOpen()
    {
        infoMenuRef.SetActive(true);
        Time.timeScale = 0;
    }
    public void infoClose()
    {
        infoMenuRef.SetActive(false);
        Time.timeScale = 1;
    }
}
