using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CO2 : Enemy
{

    
    
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        moveY();

        if (transform.position.y < ymin)
        {
            ScoreManager.score += 1;
            die();
        }
    }



}
