using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchActions : MonoBehaviour
{
    private const float MAX_X_CAMERA_AXIS = 150;
    private const float MAX_Y_CAMERA_AXIS = 150;
    private const float MIN_X_CAMERA_AXIS = MAX_X_CAMERA_AXIS * -1;
    private const float MIN_Y_CAMERA_AXIS = MAX_Y_CAMERA_AXIS * -1;
    private const float Z_CAMERA_AXIS = -10;

    private Vector3 origin;
    private Vector3 difference;
    private Vector3 initialCameraPoint;
    private bool drag;

    // Start is called before the first frame update
    void Start()
    {
        initialCameraPoint = Camera.main.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DragCamera();
        FixCameraPositionUnderLimits();
    }

    private void DragCamera()
    {
        if (Input.GetMouseButton(0))
        {
            difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;

            if (!drag)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            Camera.main.transform.position = origin - difference;
        }
    }

    private void FixCameraPositionUnderLimits()
    {
        Vector3 actualCameraPosition = Camera.main.transform.position;

        if (actualCameraPosition.x > MAX_X_CAMERA_AXIS)
        {
            Camera.main.transform.position = new Vector3(
                MAX_X_CAMERA_AXIS, Camera.main.transform.position.y, Z_CAMERA_AXIS
            );
        }

        if (actualCameraPosition.y > MAX_Y_CAMERA_AXIS)
        {
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x, MAX_Y_CAMERA_AXIS, Z_CAMERA_AXIS
            );
        }

        if (actualCameraPosition.x < MIN_X_CAMERA_AXIS)
        {
            Camera.main.transform.position = new Vector3(
                MIN_X_CAMERA_AXIS, Camera.main.transform.position.y, Z_CAMERA_AXIS
            );
        }

        if (actualCameraPosition.y < MIN_Y_CAMERA_AXIS)
        {
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x, MIN_Y_CAMERA_AXIS, Z_CAMERA_AXIS
            );
        }
    }
}
