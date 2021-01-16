using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller.Player
{
    public class PlayerController : MonoBehaviour
    {

        public float jumpForce = 10f;
        public float gravityModifier = 1;
        
        private Rigidbody playerRb = null;

        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Instant Jump!
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }
        }
    }
}