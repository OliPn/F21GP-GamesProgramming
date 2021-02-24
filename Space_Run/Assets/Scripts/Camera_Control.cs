using UnityEngine;
public class Camera_Control : MonoBehaviour
  
{
    [SerializeField]            //Allow Private To Show In Inspector
    private Transform target;   //Link To Player To Follow

    [SerializeField]
    private Vector3 offsetPosition; //Set Camera Offset From Player To Follow

    private void Update()
    {
        transform.position = target.TransformPoint(offsetPosition); //Change Camera Coordinate Position To Target + Offset
        transform.LookAt(target);   //Rotate Camera To Always Look At Side Of Target
    }     
}

