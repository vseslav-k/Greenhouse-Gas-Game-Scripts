using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyMove : MonoBehaviour
{
    [SerializeField] int moveSpeed;

    [SerializeField] float ymin;
    [SerializeField] float ymax;

    [SerializeField] GameObject otherSky;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, moveSpeed*Time.deltaTime *ScoreManager.calculateGTS(1, 4, 1.2f), 0);

        if (transform.position.y < ymin)
        {
            transform.position = new Vector3(0, otherSky.transform.position.y+ ymax, 0);
        }
    }
}
