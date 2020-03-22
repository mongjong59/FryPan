using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public Sprite elevatorButtonOn;
    public Sprite elevatorButtonOff;
    public Elevator elevator;

    bool callingElevator;
    float elevatorArriveCountdown;
    bool elevatorArrived;
    float elevatorCloseCountdown;

    Interactive interactive;

    void Awake()
    {
        interactive = GetComponent<Interactive>();
    }

    
    void Update()
    {
        if (elevatorArriveCountdown > 0)
        {
            GetComponent<SpriteRenderer>().sprite = elevatorButtonOn;
            elevatorArriveCountdown -= Time.deltaTime;

            if (elevatorArriveCountdown <= 0)
            {
                GetComponent<SpriteRenderer>().sprite = elevatorButtonOff;
                if (callingElevator)
                {
                    elevator.Arrive();
                    elevatorArrived = true;
                    elevatorCloseCountdown = 3.0f;
                    callingElevator = false;
                }
            }
        }

        if (elevatorCloseCountdown > 0)
        {
            elevatorCloseCountdown -= Time.deltaTime;
            
            if (elevatorCloseCountdown <= 0)
            {
                elevatorArrived = false;
                elevator.Close();
                interactive.Activate();
            }
        }
    }

    public void TurnOn()
    {
        Debug.Log(elevatorArrived);
        if (elevatorArrived) return;
        callingElevator = true;
        elevatorArriveCountdown = Random.Range(5.0f, 6.0f);
        interactive.Deactivate();
    }
}
