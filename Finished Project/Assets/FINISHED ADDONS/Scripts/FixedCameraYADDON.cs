using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraYADDON : MonoBehaviour
{
    // ADD TO CAMERA
    // Fixes camera to a position on the Y axis
    public float FixedYPosition = 0;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, FixedYPosition, transform.position.z);
    }
}
