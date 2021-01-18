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
        public ParticleSystem eplosionParticles = null;

        private Rigidbody playerRb = null;
        private Animator playerAnimator = null;
        private Ragdoll ragdoll = null;
        private bool isOnGround = true;
        

        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<Animator>();
            ragdoll = GetComponent<Ragdoll>();
            Physics.gravity *= gravityModifier;

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
            {
                // Instant Jump!
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnimator.SetTrigger("Jump_trig"); // do jumping animation
            }
        }

        private void OnCollisionEnter(Collision collision)
        {

            // Check if we collide with an obstacle
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                // play explosion particles
                eplosionParticles.Play();

                // gameover
                Debug.LogWarning("Game is Over!");
                isGameOver = true;
                playerAnimator.SetBool("Death_b", true); // toggle death anim
                playerAnimator.SetInteger("DeathType_int", 1);

            } else if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }

        }
    }
}