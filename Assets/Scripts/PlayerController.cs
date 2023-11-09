using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 120f;
    public float interactDistance = 2f;

    private CharacterController characterController;
    private Camera mainCamera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            // Rotate player to face the direction of movement
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }

        Vector3 moveVector = transform.forward * moveSpeed * moveDirection.magnitude;
        moveVector.y = 0;
        characterController.SimpleMove(moveVector);

        // Interact with objects (e.g., ladders, items) using spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    void Interact()
    {
        Ray interactRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(interactRay, out hit, interactDistance))
        {
            // Check if the hit object can be interacted with
            GameObject interactableObject = hit.collider.gameObject;
            HandleInteraction(interactableObject);
        }
    }

    void HandleInteraction(GameObject interactableObject)
    {
        // Add your interaction logic here
        // You can check the type of the interactableObject or tag to determine the interaction behavior
        // For example, check if it's a ladder, item, etc., and perform the appropriate action.

        // Example: Check if the object has a "Ladder" tag
        if (interactableObject.CompareTag("Ladder"))
        {
            // Implement ladder climbing logic
        }
        // Example: Check if the object has an "Item" tag
        else if (interactableObject.CompareTag("Item"))
        {
            // Implement item pickup logic
        }
        // Add more interactions as needed
    }
}