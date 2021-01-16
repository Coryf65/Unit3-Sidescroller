using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.Sidescroller.Player
{
    public class Ragdoll : MonoBehaviour
    {

        //[SerializeField] Collider playerCollider = null;
        //[SerializeField] float respawnTime = 30f;
        private Rigidbody[] rigidbodies = null;
        private bool isRagdoll = false;

        // Start is called before the first frame update
        void Start()
        {
            rigidbodies = GetComponentsInChildren<Rigidbody>();
            //playerCollider = GetComponent<BoxCollider>();
        }

        public void ToggleRagdoll(bool ragdoll)
        {
            isRagdoll = ragdoll;

            foreach (Rigidbody ragdollBone in rigidbodies)
            {
                ragdollBone.isKinematic = true;
            }
        }
    }
}
