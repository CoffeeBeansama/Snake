using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class SnakeFood : MonoBehaviour
    {
        public BoxCollider2D AreaGrid;

        private void Start()
        {
            RandomizeFoodPosition();
        }



        private void RandomizeFoodPosition()
        {
            // Picks a random location based on Area grid's box collider bounds

            Bounds bounds = AreaGrid.bounds;

            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            gameObject.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        }

        private void OnTriggerEnter2D(Collider2D Snake)
        {
            if(Snake.gameObject.CompareTag("Player"))
            {
                RandomizeFoodPosition();
            }
        }

    }
}