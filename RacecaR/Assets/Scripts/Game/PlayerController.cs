using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerID;

    public float accelerationRate;
    public float topSpeed;
    public float currentSpeed = 0;
    public float decelerationRate;
    public float reverseRate;

    public float turnRate;
    public float turnLimit;
    float turnSpeed = 0;
    public bool reverse;

    public int pickupCount;
    bool powerupActive;
    float powerupDuration = 5;
    public bool immune;

    public int lap = 0;
    public int checkpointCount;
    public int lapLimit;
    public bool win;

    public Rigidbody rgb;
    public GameObject respawn;
    public CheckPoints[] CP = new CheckPoints[5];

    public GameObject bulletPoint;
    public GameObject bullet;
    public GameObject minePoint;
    public GameObject mine;
    public GameObject player;

    public int burst = 5;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        player = gameObject;

        powerupActive = false;
        immune = false;
    }

    // Update  is called once per frame
    void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            Debug.Log("Reverse Active: " + reverse);

            if (turnSpeed > turnLimit)
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
                gameObject.transform.Translate(0, 0, currentSpeed * Time.deltaTime);
                gameObject.transform.Rotate(0, currentTurn * Time.deltaTime, 0);

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
                                if (Input.GetKey(KeyCode.S))
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

                            //Accelerate and Reverse
                            if (Input.GetKey(KeyCode.UpArrow))
                            {
                                Accelerate();
                            }
                            else
                                if (Input.GetKey(KeyCode.DownArrow))
                            {
                                Reverse();
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
                if (pickupCount == 1)
                {
                    Immunity();
                }

                if (pickupCount == 2)
                {
                    Shoot();
                }

                if (pickupCount == 3)
                {
                    Mine();
                }
            }

            if (GameManager.instance.inverseActive && !immune)
            {
                reverse = true;
            }
            else
            {
                reverse = false;
            }
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

        currentSpeed += accelerationRate;

        if(currentSpeed >= maxSpeed)
        {
            currentSpeed = maxSpeed;
        }

        //rgb.AddForce(transform.forward * speed);
    }

    void Reverse()
    {
        float topReverse;

        topReverse = -topSpeed * 0.1f;

        currentSpeed -= reverseRate;

        if(currentSpeed <= topReverse)
        {
            currentSpeed = topReverse;
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

    void Shoot()
    {
        Instantiate(bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);

        burst -= 1;

        if(burst <= 0)
        {
            pickupCount = 0;
            burst = 5;
        }

        powerupActive = false;
    }

    void Mine()
    {
        Instantiate(mine, minePoint.transform.position, Quaternion.identity);
        powerupActive = false;
        pickupCount = 0;
    }
}