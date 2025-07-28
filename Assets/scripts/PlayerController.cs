using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour

{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private Vector2 movementVector;
    public TextMeshProUGUI countText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }
    private void FixedUpdate()
    {
        rb.AddForce(movementVector);
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
        }
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText = "Count: " + count.ToString();
    }
  

}
