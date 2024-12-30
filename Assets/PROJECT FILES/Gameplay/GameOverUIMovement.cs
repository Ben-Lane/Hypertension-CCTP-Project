using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GameOverUIMovement : MonoBehaviour
{
    public float startHeight;  // Starting position
    public float endHeight;    // Target position
    public float lerpDuration = 2.0f; // Duration of the lerp in seconds

    private float elapsedTime = 0.0f; // Tracks time for the lerp

    private bool start_movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start_movement)
        {
            if (elapsedTime < lerpDuration)
            {
                print(elapsedTime);
                // Increment elapsed time
                elapsedTime += Time.deltaTime;

                // Progress (%) through the lerp
                float t = elapsedTime / lerpDuration;

                // Adjust % based on an exponential curve
                t = 1 - Mathf.Pow(2, -7.5f * t);

                // Perform the lerp
                transform.position = new Vector3(transform.position.x, startHeight + ((endHeight - startHeight) * t), transform.position.z);

            }
            else
            {
                start_movement = false;
            }
        }       
      
    }

    public void StartMovement()
    {
        start_movement = true;
        print(start_movement);
    }
}
