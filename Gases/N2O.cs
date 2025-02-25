using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N2O : Enemy
{

    [Space(5)]
    [Header("X Speed")]
    [SerializeField] protected float xSpeedMin;
    [SerializeField] protected float xSpeedMax;
    [SerializeField] protected float xSpeed;

    protected float chosenPt;

    void Start()
    {

        spawn();
    }


    void Update()
    {
        moveY();
        moveX();

        if (transform.position.y < ymin)
        {
            ScoreManager.score += 3;
            die();
        }
    }

    protected override void spawn()
    {
        base.spawn();

        xSpeed = Random.Range(xSpeedMin, xSpeedMax);

        chosenPt = choseXPos();
    }

    protected void moveX()
    {
        if(isCloseTo(transform.position.x, chosenPt, 0.01f))
         {
             chosenPt = choseXPos();
         }

        transform.position = new Vector3(moveTo(transform.position.x, chosenPt, Time.deltaTime * xSpeed *ScoreManager.calculateGTS(1, 3, 0.8f)), transform.position.y, 0);

    }

    protected float choseXPos()
    {
        float r = Random.Range(XspawnMin, XspawnMax);

        return r;
    }

    protected bool isCloseTo(float a, float b, float dist)
    {
        if(Mathf.Abs(a-b)<= dist)
        {
            return true;
        }

        return false;
    }

    protected float moveTo(float a, float b, float step)
    {
        if(isCloseTo(a, b, step))
        {
            return b;
        }

        if (a > b)
        {
            return (a - step);
        }

        if (a < b)
        {
            return (a + step);
        }



        return b;
    }
}
