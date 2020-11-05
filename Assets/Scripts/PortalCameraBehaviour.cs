using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraBehaviour : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    float myAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetMyAngle(float angle)
    {
        myAngle = angle;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation,otherPortal.rotation);
        if (myAngle == 90 || myAngle == 270)
        {
            angularDifferenceBetweenPortalRotations -= 90;
        }
        Quaternion portalRotationalDifference =
        Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        if (myAngle == 90 || myAngle == 270)
        {
            newCameraDirection = new Vector3(newCameraDirection.z * -1, newCameraDirection.y,newCameraDirection.x);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
        else
        {
            newCameraDirection = new Vector3(newCameraDirection.x * -1, newCameraDirection.y,newCameraDirection.z * -1);
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }



}
