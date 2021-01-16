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

            // for testing 
            playerRb.AddForce(Vector3.up * 1000);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}