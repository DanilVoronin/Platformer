using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Helpers
{
    public class MovingPlatform2D : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D currentRigidbody2D;
        [SerializeField] private Vector2 oldPosition;

        private List<Rigidbody2D> rigidbody2Ds = new List<Rigidbody2D>(); 

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Unit") && 
                collision.attachedRigidbody &&
                !rigidbody2Ds.Contains(collision.attachedRigidbody))
            {
                rigidbody2Ds.Add(collision.attachedRigidbody);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Unit") &&
                collision.attachedRigidbody &&
                rigidbody2Ds.Contains(collision.attachedRigidbody))
            {
                rigidbody2Ds.Remove(collision.attachedRigidbody);
            }
        }

        private void FixedUpdate()
        {
            if (rigidbody2Ds.Count > 0)
            {
                Vector2 shift = currentRigidbody2D.position - oldPosition;
                foreach (Rigidbody2D rigidbody2D in rigidbody2Ds)
                {
                    rigidbody2D.position += shift;
                }
            }
            oldPosition = currentRigidbody2D.position;
        }
    }
}