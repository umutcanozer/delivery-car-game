using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowedSpeed = 5f;
    [SerializeField] float boostedSpeed = 15f;
    float Timer;
    float ReducingTime = 2f;
    bool isSpeeding;
     

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moving = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); // rotate the car
        transform.Translate(0, moving, 0); // move the car
        SpeedTimer();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost")
        {
            moveSpeed = boostedSpeed;
            Timer = 10f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowedSpeed;
        Timer = 10f;
    }

    void SpeedTimer()
    {
        //Speed boosting or speed reducing timer
        if(moveSpeed == boostedSpeed || moveSpeed == slowedSpeed)
        {
            isSpeeding = true;
            Timer -= ReducingTime * Time.deltaTime;
            if(Timer <= 0 && isSpeeding)
            {

                moveSpeed = 10f;
                isSpeeding = false;
            }
        }
    }
}
