using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour


{

    [Header("Size")]
    [SerializeField] protected float sizeMin;
    [SerializeField] protected float sizeMax;
    [SerializeField] protected float size;

    [Space(5)]
    [Header("Fall Speed")]
    [SerializeField] protected float fallSpeedMin;
    [SerializeField] protected float fallSpeedMax;
    [SerializeField] protected float fallSpeed;


    [Space(5)]
    [Header("Spawn Cords")]
    [SerializeField] protected float yspawn;
    [SerializeField] protected float XspawnMin;
    [SerializeField] protected float XspawnMax;


    [Space(5)]
    [Header("Die Level")]
    [SerializeField] protected float ymin;

    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void spawn()
    {
        transform.position = new Vector3(Random.Range(XspawnMin, XspawnMax), yspawn, 0);


        size = Random.Range(sizeMin, sizeMax);
        fallSpeed = Random.Range(fallSpeedMin, fallSpeedMax);

        transform.localScale = new Vector3(size, size, size);
    }

    virtual protected void moveY()
    {
        transform.position -= new Vector3(0, fallSpeed*Time.deltaTime * ScoreManager.calculateGTS(1, 3, 1), 0);
    }

    virtual protected void die()
    {
        if (transform.position.y < ymin)
        {
            Destroy(gameObject);
        }
    }
}
