using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller.Player
{
    public class PlayerController : MonoBehaviour
    {

        public float jumpForce = 10f;
        public float gravityModifier = 1;
        public bool isGameOver = false;

        private Rigidbody playerRb = null;
        private Animator playerAnimator = null;
        private bool isOnGround = true;
        

        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<Animator>();
            Physics.gravity *= gravityModifier;

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                // Instant Jump!
                playerAnimator.SetTrigger("Jump_trig"); // do jumping animation

                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {

            // Check if we collide with an obstacle
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                // gameover
                Debug.LogWarning("Game is Over!");
                isGameOver = true;
                // stop moving left

            } else if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }

        }
    }
}