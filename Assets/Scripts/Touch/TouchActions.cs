using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchActions : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;
    private bool drag;

    void LateUpdate()
    {
        DragCamera();
        FixCameraPositionUnderLimits();
    }

    private void DragCamera()
    {
        if (Input.touchCount == 1 && Input.GetMouseButton(0))
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
        Camera.main.transform.position = new Vector3(
            Mathf.Clamp(Camera.main.transform.position.x, ScenarioGeneratiorViewerConstants.MIN_X_CAMERA_AXIS, ScenarioGeneratiorViewerConstants.MAX_X_CAMERA_AXIS),
            Mathf.Clamp(Camera.main.transform.position.y, ScenarioGeneratiorViewerConstants.MIN_Y_CAMERA_AXIS, ScenarioGeneratiorViewerConstants.MAX_Y_CAMERA_AXIS),
            ScenarioGeneratiorViewerConstants.Z_CAMERA_AXIS
        );
    }
}
