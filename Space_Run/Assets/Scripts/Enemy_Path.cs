using UnityEngine;
using UnityEngine.AI;
public class Enemy_Path : MonoBehaviour
{
    public GameObject[] paths;      //Use Gameobjects As Waypoints And Set Number
    public NavMeshAgent agent;      //Enemy To Follow Path

    private int startingPath = 0;   //Start From Waypoint 0
    private int pathLength = 0;     //Default Number Of Waypoint Is 0

    private void Start()
    {
        startingPath = 0;                           //Start From Waypoint 0
        pathLength = paths.Length;                  //Read In Number Of Waypoints             
        agent = GetComponent<NavMeshAgent>();       //Use Enemy Ingame Component
    }

    void Update()
    {
        if (startingPath < pathLength)  //Check Waypoint Number Is Within Valid Range
        {
            //When Enemy Has Reached Waypont (1 Unit)  
            if (Vector3.Distance(paths[startingPath].transform.position, gameObject.transform.position) < 1)     
            {
                if (startingPath == pathLength - 1) //If At Final Waypoint
                {
                    startingPath = 0;   //Reset Waypoint Number
                }   
                else
                {
                    startingPath++; //Move To Next Waypoint
                }
            }
        }
        agent.SetDestination(paths[startingPath].transform.position);   //Travel Towards Next Waypoint
    }
}
