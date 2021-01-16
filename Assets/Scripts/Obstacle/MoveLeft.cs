using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller.Obstacle
{
    public class MoveLeft : MonoBehaviour
    {

        [SerializeField] private float speed = 10f;

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // moves the object over time
        }
    }
}
