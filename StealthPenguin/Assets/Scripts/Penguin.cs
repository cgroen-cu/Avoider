using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    //How far they launch

    private float holdDownStartTime;

    public GameManagerScript gameManager;
    public PenguinMovement penmove;
    public bool canMove = false;

    void Start()
    {
        
    }
    public void Init()
    {
        penmove.Init();
        canMove = false;
    }
    private void Update()
    {
        //Aim sprite at mouse
        //lookAtMouse();
        //Inputs
        //Hold if buttons are on
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Charge
                //Debug.Log("Button Down!");
                holdDownStartTime = Time.time;

            }

            if (Input.GetMouseButtonUp(0))
            {
                //Debug.Log("Button Up!");
                //Launch
                //float holdDownTime;
                // holdDownTime = Time.time - holdDownStartTime;
                //Debug.Log(Time.time - holdDownStartTime);
                penmove.Launch(Time.time - holdDownStartTime);
            }
        }
      
    }

    public void switchMove()
    {
        if (canMove == true)
            canMove = false;
        else
            canMove = true;
    }

    public void GameOver(int deathType)
    {
        Debug.Log("GameOVer");
        gameManager.Init(deathType);
    }


}
