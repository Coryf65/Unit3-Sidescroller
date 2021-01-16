using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller.Player
{
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody playerRb = null;

        // Start is called before the first frame update
        void Start()
        {
            playerRb = GetComponent<Rigidbody>();

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Instant Jump!
                playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);

            }
        }
    }
}