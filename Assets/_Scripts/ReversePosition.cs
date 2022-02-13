using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePosition : MonoBehaviour
{
    //reversePosition set to false
    public bool reversePosition = false;
    //list of vector3 positions
    List<Vector3> lastPositions;



    // Start is called before the first frame update
    void Start()
    {
        //new list of vector3 positions
        lastPositions = new List<Vector3>();

    }

    // Update is called once per frame
    void Update()
    {
        //if key is currently pressed start or stop rewinding
        if (Input.GetKeyDown(KeyCode.F3))
        {
            StartReversingPosition();
        }
        if (Input.GetKeyUp(KeyCode.F3))
        {
            StopReversingPosition();
        }
    }
    void FixedUpdate()
    {
        //check if isrewinding and rewind or record position
        if (reversePosition == true)
        {
            //then reverse by removing the earliest 
            Reverse();
        }
        else
        {
            RecordLastPositions();
        }
    }
    void RecordLastPositions()
    {
        //record vector3 position and insert into index 0 of the list 
        lastPositions.Insert(0, transform.position);

    }
    void Reverse()
    {
        //check if any position are in the list
        if(lastPositions.Count > 0)
        {
            // move to last position made in the list
            transform.position = lastPositions[0];
            //remove position in the list
            lastPositions.RemoveAt(0);

        }
        else
        {
            //stop reversing position
            StopReversingPosition();
        }

    }
    public void StartReversingPosition()
    {
        //set bool reverse position to true
        reversePosition = true;
    }
    public void StopReversingPosition()
    {
        //set bool reverse position to false
        reversePosition = false;
    }
    
}
