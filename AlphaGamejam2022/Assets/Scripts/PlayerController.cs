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
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement = Vector2.ClampMagnitude(movement, 1f);
        transform.position = transform.position + (Vector3)(movement * speed * Time.deltaTime);
    }

    private void ReduceHeat(int heat)
    {
        
    }
}