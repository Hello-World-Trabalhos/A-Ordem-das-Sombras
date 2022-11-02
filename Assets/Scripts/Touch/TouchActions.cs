using System;
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
        ZoomCamera();
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
            FixCameraPositionUnderLimits();
        }
    }

    private void FixCameraPositionUnderLimits()
    {
        Camera.main.transform.position = new Vector3(
            Mathf.Clamp(Camera.main.transform.position.x, ScenarioGenerationViewerConstants.MIN_X_CAMERA_AXIS, ScenarioGenerationViewerConstants.MAX_X_CAMERA_AXIS),
            Mathf.Clamp(Camera.main.transform.position.y, ScenarioGenerationViewerConstants.MIN_Y_CAMERA_AXIS, ScenarioGenerationViewerConstants.MAX_Y_CAMERA_AXIS),
            ScenarioGenerationViewerConstants.Z_CAMERA_AXIS
        );
    }

    private void ZoomCamera()
    {
        if (Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            Vector2 firstTouchPreviousPosition = firstTouch.position - firstTouch.deltaPosition;
            Vector2 secondTouchPreviousPosition = secondTouch.position - secondTouch.deltaPosition;

            float touchesPreviousPositionsDifference = (firstTouchPreviousPosition - secondTouchPreviousPosition).magnitude;
            float touchesCurrentPositionsDifference = (firstTouch.position - secondTouch.position).magnitude;

            float zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * ScenarioGenerationViewerConstants.CAMERA_ZOOM_SPEED;

            if (touchesPreviousPositionsDifference > touchesCurrentPositionsDifference)
            {
                Camera.main.orthographicSize += zoomModifier;
            }

            if (touchesPreviousPositionsDifference < touchesCurrentPositionsDifference)
            {
                Camera.main.orthographicSize -= zoomModifier;
            }

            FixCameraZoomUnderLimits();
        }
    }

    private void FixCameraZoomUnderLimits()
    {
        Camera.main.orthographicSize = Mathf.Clamp(
            Camera.main.orthographicSize,
            ScenarioGenerationViewerConstants.MIN_CAMERA_ZOOM,
            ScenarioGenerationViewerConstants.MAX_CAMERA_ZOOM
        );
    }
}
