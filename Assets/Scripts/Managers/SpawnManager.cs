using Cory.Sidescroller.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller.Managers
{
    public class SpawnManager : MonoBehaviour
    {

        public GameObject obstaclePrefab = null;

        private Vector3 spawnPosition = new Vector3(25, 0, 0);
        private float startDelay = 2f;
        private float spawnRate = 2f;
        private PlayerController playerController = null;

        // Start is called before the first frame update
        void Start()
        {
            // call a method over time
            InvokeRepeating("SpawnObstacle", startDelay, spawnRate);
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        // spawn object, at same rotation at our point
        public void SpawnObstacle()
        {
            if (!playerController.isGameOver)
            {
                Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
            }

        }
    }
}
