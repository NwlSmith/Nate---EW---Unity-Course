using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollowADDON : MonoBehaviour
{
    // ADD TO CAMERA
    // Makes camera follow the player smoothly
    // MAKE SURE CAMERA IS NOT PARENTED TO PLAYER

    public float smoothness = 2f;
    private PlayerADDON playerADDON;
    private Transform playerTrans;
    void Start()
    {
        playerADDON = FindObjectOfType<PlayerADDON>();
        if (playerADDON == null)
            Debug.Log("ERROR: PlayerADDON is not present on the Player.");
        else
        {
            playerTrans = playerADDON.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
         
        Vector3 targetTrans = Vector3.Lerp(transform.position, playerTrans.position, smoothness * Time.deltaTime);
        targetTrans.z = -10;
        transform.position = targetTrans;
    }
}
