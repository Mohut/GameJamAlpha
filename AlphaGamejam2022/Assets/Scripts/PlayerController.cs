using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed
    [SerializeField] public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector based on the input
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the movement vector so that diagonal movement is not faster
        movement = Vector2.ClampMagnitude(movement, 1f);

        // Apply the movement to the player's position
        transform.position = transform.position + (Vector3)(movement * speed * Time.deltaTime);
    }
}