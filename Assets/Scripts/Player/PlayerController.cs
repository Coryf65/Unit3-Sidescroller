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
        public ParticleSystem explosionParticles = null;
        public ParticleSystem dirtParticles = null;
        public AudioClip jumpClip = null;
        public AudioClip crashClip = null;

        private AudioSource playerAudioSource = null;
        private Rigidbody playerRb = null;
        private Animator playerAnimator = null;
        private bool isOnGround = true;
        

        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<Animator>();
            playerAudioSource = GetComponent<AudioSource>();
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
                dirtParticles.Stop();
                playerAudioSource.PlayOneShot(jumpClip, 1.0f); // play sound clip one time, at full volume
            }
        }

        private void OnCollisionEnter(Collision collision)
        {

            // Check if we collide with an obstacle
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                // play particles
                explosionParticles.Play();
                dirtParticles.Stop();
                playerAudioSource.PlayOneShot(crashClip, 1.0f); // play sound clip one time, at full volume
                // gameover
                Debug.LogWarning("Game is Over!");
                isGameOver = true;
                playerAnimator.SetBool("Death_b", true); // toggle death anim
                playerAnimator.SetInteger("DeathType_int", 1);

            }
            else if (collision.gameObject.CompareTag("Ground"))
            {
                dirtParticles.Play();
                isOnGround = true;
            }

        }
    }
}