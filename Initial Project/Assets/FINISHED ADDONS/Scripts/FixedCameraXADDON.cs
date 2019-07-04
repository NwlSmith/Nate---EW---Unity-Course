using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraXADDON : MonoBehaviour
{
    // ADD TO CAMERA
    // Fixes camera to a position on the X axis
    public float FixedXPosition = 0;
    private void Update()
    {
        transform.position = new Vector3(FixedXPosition, transform.position.y, transform.position.z);
    }
}
