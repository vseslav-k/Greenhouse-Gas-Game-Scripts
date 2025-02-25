using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class followMouse : MonoBehaviour
{
    [SerializeField] Vector2 mousePos;

    [SerializeField]float moveSpeed;

    public static Action died;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

  
        transform.position = Vector2.MoveTowards(transform.position, mousePos, Time.deltaTime * moveSpeed * ScoreManager.calculateGTS(1, 3, 1));
       
    }

    



    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colision Detected");
        if (other.gameObject.tag == "enemy")
        {
            died();
        }
    }
}
