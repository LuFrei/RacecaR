﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerID;

    public float topSpeed;
    public float currentSpeed = 0;
    public float decelerationRate;
    public bool reverse;

    public float turnRate;
    public float turnLimit;
    public float turnSpeed = 0;
    
    public int pickupCount;
    public bool powerupActive;
    float powerupDuration = 5;
    public bool immune;

    public int lap = 0;
    public int checkpointCount;
    public int lapLimit;
    public bool win;

    public Rigidbody rgb;
    public GameObject respawn;
    public CheckPoints[] CP = new CheckPoints[5];
    public GameMaster gm;


    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        powerupActive = false;
        immune = false;
    }
    // Update  is called once per frame
    void Update()
    {

        if(turnSpeed > turnLimit)
        {
            turnSpeed = turnLimit;
        }

        if (turnSpeed < -turnLimit)
        {
            turnSpeed = -turnLimit;
        }

        float currentTurn = turnSpeed;

        if (reverse == true)
        {
            currentTurn = -currentTurn;
        }
        else
        {
            currentTurn = currentTurn;
        }

        if (win == false)
        {
            gameObject.transform.Translate(0, 0, currentSpeed);
            gameObject.transform.Rotate(0, currentTurn, 0);

            switch (playerID)
            {
                case 1:
                {

                        //Turns player
                        if (Input.GetKey(KeyCode.A))
                        {
                            turnSpeed -= turnRate;
                        }
                        else
                            if (Input.GetKey(KeyCode.D))
                        {
                            turnSpeed += turnRate;
                        }
                        else
                        {
                            //turnSpeed = 0;
                            if (turnSpeed > 0)
                            {
                                turnSpeed -= turnRate;
                                if (turnSpeed <= 0)
                                {
                                    turnSpeed = 0;
                                }
                            }
                            if (turnSpeed < 0)
                            {
                                turnSpeed += turnRate;
                                if (turnSpeed >= 0)
                                {
                                    turnSpeed = 0;
                                }
                            }
                        }


                        //Accelerate and Reverse
                        if (Input.GetKey(KeyCode.W))
                        {
                            Accelerate();
                        }
                        else 
                            if(Input.GetKey(KeyCode.S))
                            {
                                Reverse();
                            }
                            else
                            {
                                Decelerate();
                            }
                    break;
                }

                case 2:
                {
                        //Turns player
                        if (Input.GetKey(KeyCode.LeftArrow))
                        {
                            turnSpeed -= turnRate;
                        }
                        else
                            if (Input.GetKey(KeyCode.RightArrow))
                        {
                            turnSpeed += turnRate;
                        }
                        else
                        {
                            turnSpeed = 0;
                            if (turnSpeed > 0)
                            {
                                turnSpeed -= turnRate;
                            }
                            if (turnSpeed < 0)
                            {
                                turnSpeed += turnRate;
                            }
                        }


                        if (Input.GetKey(KeyCode.UpArrow))
                    {
                        Accelerate();
                    }
                    else
                    {
                        Decelerate();
                    }
                    break;
                }
            }

            if (lap >= lapLimit)
            {
                win = true;
            }
        }

        //toggle powerup
        if (pickupCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            powerupActive = true;
        }

        if (powerupActive)
        {
            Immunity();
        }

        if(gm.inversion && !immune)
        {
            reverse = true;
        }
        else
        {
            reverse = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && checkpointCount >= 5)
        {
            foreach (CheckPoints cp in CP)
                cp.GetComponent<CheckPoints>().inactive[playerID - 1] = false;

            lap++;
            checkpointCount = 0;
        }

        if (other.CompareTag("Respawn"))
        {
            respawn = other.gameObject;
        }

        if (other.CompareTag("KillBox"))
        {
            transform.position = respawn.transform.position;
            transform.rotation = respawn.transform.rotation;
        }
    }

    void Accelerate()
    {
        float maxSpeed;
        

        maxSpeed = topSpeed;

        currentSpeed += 0.01f;

        if(currentSpeed >= maxSpeed)
        {
            currentSpeed = maxSpeed;
        }



        //rgb.AddForce(transform.forward * speed);
    }

    void Reverse()
    {
        float maxReverse;

        maxReverse = -topSpeed * 0.5f;

        currentSpeed -= 0.01f;

        if(currentSpeed <= maxReverse)
        {
            currentSpeed = maxReverse;
        }
    }

    //racer will always go back to 0 speed if no accelrating or revering.
    void Decelerate()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= decelerationRate;
            if(currentSpeed <= 0)
            {
                currentSpeed = 0;
            }
        }
        if (currentSpeed < 0)
        {
            currentSpeed += decelerationRate;
            if (currentSpeed >= 0)
            {
                currentSpeed = 0;
            }
        }

        if(currentSpeed == 0)
        {
            currentSpeed = 0;
        }
    }

    void Immunity()
    {
        immune = true;
        powerupDuration -= 1 * Time.deltaTime;

        if(powerupDuration <= 0)
        {
            immune = false;
            powerupDuration = 5;
            powerupActive = false;
            pickupCount = 0;
        }
        
        Debug.Log(powerupDuration);
        //LeanTween.move(gameObject, respawn.transform, 1).setEase(LeanTweenType.easeInExpo);
    }
}