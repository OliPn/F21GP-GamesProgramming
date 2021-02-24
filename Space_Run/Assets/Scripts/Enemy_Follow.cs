using UnityEngine;
using UnityEngine.AI;

public class Enemy_Follow : MonoBehaviour
{
    public NavMeshAgent enemy;      //Enemy To Chase
    public Transform Player;        //Player To Follow
    void Update()
    { 
        enemy.SetDestination(Player.position);  //Set Enemy End Point To Current Player Position
    }
}
