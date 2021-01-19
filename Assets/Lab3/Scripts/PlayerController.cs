using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller.Lab3
{
    public class PlayerController : MonoBehaviour
    {
        private float speed = 5.0f;
        private Rigidbody playerRigidBody = null;
        private float zBounds = 6f; // constrain movement on Z axis

        // Start is called before the first frame update
        void Start()
        {
            playerRigidBody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            MovePlayer();

            ConstrainPlayerPosition();
        }

        /// <summary>
        ///  Move the player based on inputs
        /// </summary>
        void MovePlayer()
        {
            // simple movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            playerRigidBody.AddForce(Vector3.forward * speed * verticalInput);
            playerRigidBody.AddForce(Vector3.right * speed * horizontalInput);
        }

        /// <summary>
        ///  Prevent the player from moving outside of a set bounds
        /// </summary>
        void ConstrainPlayerPosition()
        {
            if (transform.position.z < -zBounds)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zBounds);
            }

            if (transform.position.z > zBounds)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zBounds);
            }
        }
    }
}
