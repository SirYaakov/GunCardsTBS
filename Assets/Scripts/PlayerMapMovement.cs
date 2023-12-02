using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units.Movement
{
    public class PlayerMapMovement : MonoBehaviour
    {
        PlayerController playerController;
        private Vector2 moveInput;

        void Start ()
        {
            playerController = GetComponent<PlayerController>();
        }

        void Update()
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 && playerController.IsMapMode == true)
            {
                playerController.IsMoving = true;
            }
            else
            {
                playerController.IsMoving = false;
            }
        }

        private void FixedUpdate()
        {
           if(playerController.IsMapMode == true)
           {
                UpdateMovement();
           }
             
        }

        public void UpdateMovement() 
        { 
            playerController.rigidbody2D.velocity = moveInput * playerController.moveSpeed;
        }
    }
}