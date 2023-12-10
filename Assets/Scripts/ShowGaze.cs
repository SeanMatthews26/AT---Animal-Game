using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class ShowGaze : MonoBehaviour
{
    public float visualizationDistance = 10f;

    private bool _hasHistoricPoint;
    private Vector3 _historicPoint;

    //How heavy filtering to apply to gaze point bubble movements. 0.1f is most responsive, 1.0f is least responsive.
    public float FilterSmoothingFactor = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();

        UpdateGazeBubblePosition(gazePoint);
    }

    private void UpdateGazeBubblePosition(GazePoint gazePoint)
    {
        Vector3 gazePointInWorld = ProjectToPlaneInWorld(gazePoint);
        transform.position = Smoothify(gazePointInWorld);
    }

    private Vector3 ProjectToPlaneInWorld(GazePoint gazePoint)
    {
        Vector3 gazeOnScreen = gazePoint.Screen;
        gazeOnScreen += (transform.forward * visualizationDistance);
        return Camera.main.ScreenToWorldPoint(gazeOnScreen);
    }

    private Vector3 Smoothify(Vector3 point)
    {
        if (!_hasHistoricPoint)
        {
            _historicPoint = point;
            _hasHistoricPoint = true;
        }

        var smoothedPoint = new Vector3(
            point.x * (1.0f - FilterSmoothingFactor) + _historicPoint.x * FilterSmoothingFactor,
            point.y * (1.0f - FilterSmoothingFactor) + _historicPoint.y * FilterSmoothingFactor,
            point.z * (1.0f - FilterSmoothingFactor) + _historicPoint.z * FilterSmoothingFactor);

        _historicPoint = smoothedPoint;

        return smoothedPoint;
    }
}
