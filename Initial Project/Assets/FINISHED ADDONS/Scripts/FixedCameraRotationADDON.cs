using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraRotationADDON : MonoBehaviour
{
    // ADD TO CAMERA
    // Prevents camera from rotating with player
    private void Update()
    {
        transform.eulerAngles = Vector3.zero;
    }
}
