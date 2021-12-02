using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float TurnSpeed = 220f;
    [SerializeField] float CarSpeed = 10f;
    [SerializeField] float SlowSpeed = 15f;
    [SerializeField] float BoostSpeed = 25f;
    [SerializeField] float SpeedChangeDuration = 1;

    string SteerAxis = "Horizontal";
    string SpeedAxis = "Vertical";
    float CurrentCarSpeed;
    DateTime StartCheckTime;
    bool ShouldCheckTime = false;

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(new Vector3(0,0,45));
        CurrentCarSpeed = CarSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        TurnCar();
        if (ShouldCheckTime)
        {
            CheckCarSpeed();
        }
    }

    public void CheckCarSpeed()
    {
        DateTime now = DateTime.Now;
        float diff = (float)(now - StartCheckTime).TotalSeconds;
        if(diff >= SpeedChangeDuration)
        {
            CurrentCarSpeed = CarSpeed;
            ShouldCheckTime = false;
        }
    }
    /// <summary>
    /// set the car speed and initiate check for when to change speed back to normal
    /// </summary>
    /// <param name="speed"></param>
    void UpdateCarSpeed(float speed)
    {
        CurrentCarSpeed = speed;
        ShouldCheckTime = true;
        StartCheckTime = DateTime.Now;
    }

    /// <summary>
    /// time delta time makes things frame rate independent
    /// move the car forward
    /// </summary>
    void MoveForward()
    {
        float speedAmount = Input.GetAxis(SpeedAxis) * CurrentCarSpeed * Time.deltaTime;
        transform.Translate(0, speedAmount, 0);
    }

    /// <summary>
    /// rotate the car
    /// </summary>
    void TurnCar()
    {
        float steerAmount = Input.GetAxis(SteerAxis) * TurnSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
    }

    /// <summary>
    /// potentially move to a booster script at some point?
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision car");
        UpdateCarSpeed(SlowSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if(tag == "booster")
        {
            UpdateCarSpeed(BoostSpeed);
        }
    }
}
