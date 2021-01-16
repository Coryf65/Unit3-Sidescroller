using Cory.Sidescroller.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller.Obstacle
{
    public class MoveLeft : MonoBehaviour
    {
        private float speed = 20f; // sync across all
        private PlayerController playerController = null;

        private void Start()
        {
            playerController = GameObject.Find("Player").GetComponent<PlayerController>(); // find the player and get the playerController
        }

        // Update is called once per frame
        void Update()
        {
            if (!playerController.isGameOver)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed); // moves the object over time
            }

        }
    }
}
