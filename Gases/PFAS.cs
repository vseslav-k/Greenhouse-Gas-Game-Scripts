using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFAS : Enemy
{

    [Space(5)]
    [Header("X Speed")]
    [SerializeField] protected float xSpeedMin;
    [SerializeField] protected float xSpeedMax;
    [SerializeField] protected float xSpeed;



    void Start()
    {
        spawn();
    }


    void Update()
    {
        moveY();
        targetPlayer();

        if (transform.position.y < ymin)
        {
            ScoreManager.score += 5;
            die();
        }
    }


    protected override void spawn()
    {
        base.spawn();
        xSpeed = Random.Range(xSpeedMin, xSpeedMax);

    }

    void targetPlayer()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(Vector2.MoveTowards(transform.position, mousePos, Time.deltaTime * xSpeed  *ScoreManager.calculateGTS(1, 3, 0.75f)).x, transform.position.y, 0);
    }
}
