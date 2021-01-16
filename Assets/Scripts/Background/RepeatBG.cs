using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller.Background
{
    public class RepeatBG : MonoBehaviour
    {

        private Vector3 startPosition; // the reset 
        [SerializeField] private float offset = 56.5f;

        // Start is called before the first frame update
        void Start()
        {
            startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < startPosition.x - offset)
            {
                transform.position = startPosition; // reset the poisition
            }
        }
    }
}
