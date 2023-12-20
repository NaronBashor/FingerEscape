using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClearer : MonoBehaviour
{
        // Clear enemies that leave the screen
        private void OnTriggerEnter2D(Collider2D collision)
        {
                if (collision != null)
                {
                        if (collision.CompareTag("Enemy"))
                        {
                                Destroy(collision.gameObject);
                        }
                }
        }
}
