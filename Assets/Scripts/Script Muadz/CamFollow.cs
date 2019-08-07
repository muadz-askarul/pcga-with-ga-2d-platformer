using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{
    public Camera camera;

    public GameObject ObjToFollow;

    public Vector3 offSet;

    Vector3 desiredPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        desiredPos = ObjToFollow.transform.position + offSet;

        Vector3 smoothedPosition = Vector3.Lerp(camera.transform.position, desiredPos, .1f);
        //smoothedPosition = new Vector3(smoothedPosition.x, ytemp, smoothedPosition.z);
        camera.transform.position = smoothedPosition;
    }
}
