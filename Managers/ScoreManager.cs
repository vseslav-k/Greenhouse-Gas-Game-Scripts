using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static float gameTimeScale;
    [SerializeField] TextMeshProUGUI scoreText;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

    }


    public static float calculateGTS(float min, float max, float scale)
    {
        float gts;

        gts = score*scale / 125f;

        if (gts < min)
        {
            gts = 1 + gts/125f;
        }

        if (gts > max)
        {
            gts = max;
        }


        return gts;
    }
    public static float calculateGTS()
    {
        float gts;

        gts = score / 125f;

        if (gts < 1f)
        {
            gts = 1 + gts / 125;
        }

        if (gts > 3f)
        {
            gts = 3;
        }


        return gts;
    }


}
