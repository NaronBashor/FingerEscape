using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
        [SerializeField] private float spinSpeed;

        private void Update()
        {
                // Reset spin speed once full rotation complete
                if (spinSpeed > 360)
                {
                        spinSpeed = 0;
                }
        }

        private void FixedUpdate()
        {
                // Use fixed update to rotate rigidbody
                this.transform.rotation = Quaternion.Euler(0 , 0 , spinSpeed += 1);
        }
}
