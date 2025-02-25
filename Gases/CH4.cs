using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH4 : Enemy
{
    [Space(5)]
    [Header("Spin")]
    [SerializeField] protected float spinMin;
    [SerializeField] protected float spinMax;
    [SerializeField] protected float spin;
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        moveY();
        spinning();

        if (transform.position.y < ymin)
        {
            ScoreManager.score += 2;
            die();
        }
    }


    protected override void spawn()
    {
        base.spawn();

        spin = Random.Range(spinMin, spinMax);
    }

    protected void spinning()
    {
        transform.RotateAround(transform.position, Vector3.forward ,spin*Time.deltaTime *ScoreManager.calculateGTS(1, 3.5f, 1.2f));
    }
}
