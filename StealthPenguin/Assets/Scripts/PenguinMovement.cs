using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PenguinMovement : MonoBehaviour
{

    public float frictionAmmount = 5;
    public Vector2 startPosition;
    public Penguin penny;

    public Vector3 setPosition;

    private float friction;

    private const float JUMP_AMMOUNT = 10f;
    private Rigidbody2D penguinbody2D;
    //Mouse location
    private Vector2 target;
    //whether it's moving or not
    private bool moving;
    private float moveX;
    private float moveY;
    private float launchForce = 1;
    //step most be more than 0 to count for moving
    private float step = 1;

    

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    public void Init()
    {
        Debug.Log("Initilizing Penguin");
        //resets
        friction = frictionAmmount;
        penguinbody2D = GetComponent<Rigidbody2D>();
        float step = 0;
        float launchForce = 1;
        this.transform.position = setPosition;
        moving = false;
        Vector2 velocity2 = new Vector2(0,0);
        penguinbody2D.velocity = -velocity2;
        //reset position
    }

    // Update is called once per frame
    void Update()
    {
        lookAtMouse();

        //If moving and step is more than 0
        if (moving && step > 0f)
        {
            //Calculate how much to move
            step = launchForce * Time.deltaTime / friction;

            //Debug.Log(Time.deltaTime);
            Debug.Log("Speed: " + step);

            //transform.position = Vector2.MoveTowards(transform.position, target, step);
            Vector2 velocity = new Vector2(moveX + step, moveY + step);
            penguinbody2D.velocity = -velocity;

            //increase friction
            friction += 1;
        }
        else
        {
            //put moving to false
            moving = false;
            //now we can reset step
            step = 1;
            //reset friction
            friction = frictionAmmount;
        }
    }

    //Keep penguin pointed at mouse
    private void lookAtMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //calculate how long was held down for
    private float CalculateHoldDownForce(float holdTime)
    {
        startPosition = transform.position;
        float maxForceHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(1 / maxForceHoldDownTime);
        //Debug.Log("Normalzied: " + holdTimeNormalized);
        float force = holdTimeNormalized * JUMP_AMMOUNT;
        //Debug.Log("Force: " + force);

        //Also calulcate the direction

        moveX = startPosition.x - target.x;
        moveY = startPosition.y - target.y;
        return force;
    }

    //Launch penguin in direction

    public void Launch(float held)
    {
        //set target
        moving = true;
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        launchForce = CalculateHoldDownForce(held);


    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Trigger");
        //If it's on the water layer
        if(collider.gameObject.layer == 4)
        {
            //Debug.Log("Water!");
            penny.GameOver(2);
        }
        //if its on the sardine layer
        if (collider.gameObject.layer == 9)
        {
            //Debug.Log("Sardine!");
            penny.GameOver(1);
        }
        //Bear Vision layer
        if (collider.gameObject.layer == 10)
        {
            //Debug.Log("She saw you!");
            collider.GetComponentInParent<BearMovement>().StartChasing();
        }
        //Bear Body Layer
        if (collider.gameObject.layer == 11)
        {
            //Debug.Log("Caught by the bear!");
            //Debug.Log("DetectedBear");
            moving = false;
            step = 0;
            penny.GameOver(3);
        }
    }


}
