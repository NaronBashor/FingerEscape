using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilateEnemy : MonoBehaviour
{
        [SerializeField] private float amplitude;
        [SerializeField] private float frequency;

        private void Start()
        {
                // If too far left, flip so teeth are in gameplay area
                if (this.transform.position.x > 6)
                {
                        this.transform.localScale = new Vector2(-1.25f , 1.25f);
                }
        }

        private void Update()
        {
                // Find angle of oscillation
                float angle = Mathf.Sin(Time.time * frequency) * amplitude;

                // Set rotation
                transform.eulerAngles = new Vector3(0 , 0 , angle);
        }
}
