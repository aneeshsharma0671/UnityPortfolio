using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5f;  
    [SerializeField] private GameObject Visuals;
    [SerializeField] private CharacterController controller;
    private bool isGrounded;
    private Vector3 movement;
    private Vector3 direction;
    private void Start() {
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, 0, vertical);

        if(direction.magnitude > 1f) {
            direction.Normalize();
        }

        movement = direction * speed * Time.deltaTime;

        movement.y = Physics.gravity.y * Time.deltaTime;

        Visuals.transform.LookAt(transform.position + direction);
        controller.Move(movement);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.tag == "Water") {
            Debug.Log("Hit Water");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
