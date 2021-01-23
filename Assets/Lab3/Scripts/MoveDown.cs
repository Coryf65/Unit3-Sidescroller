using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller
{
    public class MoveDown : MonoBehaviour
    {

        public float speed = 5.0f;

        private Rigidbody objectsRb = null;

        // Start is called before the first frame update
        void Start()
        {
            objectsRb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            objectsRb.AddForce(Vector3.forward * speed);
        }
    }
}
