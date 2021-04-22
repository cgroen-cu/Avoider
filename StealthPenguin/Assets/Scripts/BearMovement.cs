using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMovement : MonoBehaviour
{

    public List<WaypointScript> Waypoints = new List<WaypointScript>();
    public Penguin penny;
    public float Speed = 1.0f;
    public int DestinationWaypoint = 1;

    public Vector3 startPosition;
    private Vector3 Destination;
    private bool Forwards = true;

    public int state;
    // state 0 = static
    // state 1 = waypoints
    // state 2 = chasing

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        StopAllCoroutines();
        if(state == 1)
        {
            StartCoroutine(MoveTo());
        }
        if(state == 2)
        {
            //Debug.Log("Chasing!");
            this.Destination = penny.transform.position;
            StartCoroutine(MoveTo());
        }
    }

    //Initilization
    public void Init()
    {
        //Debug.Log("Initilizing bear");
        Speed = 1.0f;
        this.transform.position = startPosition;
        if(this.Waypoints.Count >=1)
            this.Destination = this.Waypoints[DestinationWaypoint].transform.position;
    }


    IEnumerator MoveTo()
    {
        while ((transform.position - this.Destination).sqrMagnitude > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, this.Destination,
                this.Speed * Time.deltaTime);
            yield return null;
        }
        if ((transform.position - this.Destination).sqrMagnitude <= 0.01f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (this.Waypoints[DestinationWaypoint].IsEndpoint)
        {
            if (this.Forwards)
                this.Forwards = false;
            else
                this.Forwards = true;

        }

        if (this.Forwards)
            ++DestinationWaypoint;
        else
            --DestinationWaypoint;
        this.Destination = this.Waypoints[DestinationWaypoint].transform.position;
    }
    
    //Called when enter chasing state
    public void StartChasing()
    {
        Speed += 2;
        state = 2;
    }
}
