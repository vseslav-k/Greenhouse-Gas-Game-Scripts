using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeScaleSet : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void setGameTime(int i)
    {
        Time.timeScale = i;
    }
}
