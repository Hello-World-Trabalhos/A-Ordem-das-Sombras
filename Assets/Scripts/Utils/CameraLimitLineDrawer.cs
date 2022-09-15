using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimitLineDrawer : MonoBehaviour
{

    void Start()
    {
        SetUpCameraLimitLine();
    }

    private void SetUpCameraLimitLine()
    {
        Vector3[] positions = new Vector3[] {
            new Vector3(ScenarioGeneratiorViewerConstants.MAX_X_CAMERA_AXIS, ScenarioGeneratiorViewerConstants.MAX_Y_CAMERA_AXIS, 0),
            new Vector3(ScenarioGeneratiorViewerConstants.MAX_X_CAMERA_AXIS, ScenarioGeneratiorViewerConstants.MIN_Y_CAMERA_AXIS, 0),
            new Vector3(ScenarioGeneratiorViewerConstants.MIN_X_CAMERA_AXIS, ScenarioGeneratiorViewerConstants.MIN_Y_CAMERA_AXIS, 0),
            new Vector3(ScenarioGeneratiorViewerConstants.MIN_X_CAMERA_AXIS, ScenarioGeneratiorViewerConstants.MAX_Y_CAMERA_AXIS, 0),
            new Vector3(ScenarioGeneratiorViewerConstants.MAX_X_CAMERA_AXIS, ScenarioGeneratiorViewerConstants.MAX_Y_CAMERA_AXIS, 0)
        };

        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }
}
