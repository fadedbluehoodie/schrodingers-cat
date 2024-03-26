using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
/*
{
    public Transform Player; // The player's Transform to Follow.
    public float smoothSpeed = 0.125f; //The smooting factor for Camera movement.
    public Vector3 offset; //The offset between the camera and the player.

  

    // Update is called once per frame
    void Update()
    {

        if (Player == null)
            return;


        //calc the desired camera postion,
        Vector3 desiredPosition = Player.position + offset;

        // use smoothDamp to smoothly interpolate between current position and desired position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // set the camera's position to the smoothed position
        transform.position = smoothedPosition;

    }
}
*/
{
    private float camYDefault = 2f;
    private float camYDelta = 3f;
    private float camYOffset = 2f;

    [SerializeField] private Transform player1;


    void Update()
    {
        // If the player holds down the "s" key, camera offset will shift lower.
        if (Input.GetKeyDown("s"))
        {
            camYOffset = camYDefault - camYDelta;
        }
        if (Input.GetKeyUp("s"))
        {
            camYOffset = camYDefault;
        }

        // Follow's the player's X position with a Y offset so relevant content is displayed
        transform.position = new Vector3(player1.position.x, player1.position.y + camYOffset, transform.position.z);
    }
}