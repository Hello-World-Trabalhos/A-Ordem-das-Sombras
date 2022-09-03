using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchActions : MonoBehaviour
{
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

        if (actualCameraPosition.x > ScenarioGeneratiorViewerConstants.MAX_X_CAMERA_AXIS)
        {
            Camera.main.transform.position = new Vector3(
                ScenarioGeneratiorViewerConstants.MAX_X_CAMERA_AXIS, Camera.main.transform.position.y, ScenarioGeneratiorViewerConstants.Z_CAMERA_AXIS
            );
        }

        if (actualCameraPosition.y > ScenarioGeneratiorViewerConstants.MAX_Y_CAMERA_AXIS)
        {
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x, ScenarioGeneratiorViewerConstants.MAX_Y_CAMERA_AXIS, ScenarioGeneratiorViewerConstants.Z_CAMERA_AXIS
            );
        }

        if (actualCameraPosition.x < ScenarioGeneratiorViewerConstants.MIN_X_CAMERA_AXIS)
        {
            Camera.main.transform.position = new Vector3(
                ScenarioGeneratiorViewerConstants.MIN_X_CAMERA_AXIS, Camera.main.transform.position.y, ScenarioGeneratiorViewerConstants.Z_CAMERA_AXIS
            );
        }

        if (actualCameraPosition.y < ScenarioGeneratiorViewerConstants.MIN_Y_CAMERA_AXIS)
        {
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x, ScenarioGeneratiorViewerConstants.MIN_Y_CAMERA_AXIS, ScenarioGeneratiorViewerConstants.Z_CAMERA_AXIS
            );
        }
    }
}
