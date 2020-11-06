using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFitScreenResolution : MonoBehaviour {
    public float sceneWidth = 10;
    Camera _camera;
    void Start () {
        _camera = GetComponent<Camera> ();
        AdjustScreenSize ();
    }
    void LateUpdate () {
        AdjustScreenSize ();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void AdjustScreenSize () {
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        _camera.orthographicSize = desiredHalfHeight;
    }
}