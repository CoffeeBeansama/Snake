using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class Snake : MonoBehaviour
    {
        [Header("Body")]
        private Vector2 Direction = Vector2.right;
        private List<Transform> BodyParts;
        public Transform BodySegmentPrefab;
        public int InitialSize = 4;

        [Header("Score")]
        public int Score;
        public GameObject ScoreManager;

        [Header("Sounds")]
        public AudioClip SnakeEat;
        public AudioClip SnakeHit;

        private void Start()
        {
            BodyParts = new List<Transform>();
            BodyParts.Add(transform);

            for (int i = 1; i < InitialSize; i++)
            {
                BodyParts.Add(Instantiate(BodySegmentPrefab));
            }


        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Direction = Vector2.up;
            }else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                Direction = Vector2.down;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Direction = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Direction = Vector2.right;
            }
        }

        private void FixedUpdate()
        {
            for(int i = BodyParts.Count -1; i > 0; i--)
            {
                BodyParts[i].position = BodyParts[i - 1].position;
            }



            transform.position = new Vector3(
                Mathf.Round(transform.position.x) + Direction.x,
                Mathf.Round(transform.position.y) + Direction.y,
                0.0f
            );
        }

        private void SnakeGrowth()
        {
            Transform segment = Instantiate(BodySegmentPrefab);
            segment.position = BodyParts[BodyParts.Count - 1].position; // -1 gets the last position on the list

            BodyParts.Add(segment);

            Score += 1;
            ScoreManager.GetComponent<Text>().text = Score.ToString();

            SoundManager.instance.PlaySound(SnakeEat);
        }

        private void ResetSnake()
        {
            Score = 0;
            ScoreManager.GetComponent<Text>().text = Score.ToString();

            SoundManager.instance.PlaySound(SnakeHit);
            for (int i = 1; i < BodyParts.Count; i++)
            {
                Destroy(BodyParts[i].gameObject);
            }
            
        
            BodyParts.Clear();
            BodyParts.Add(transform);

            for(int i = 1; i < InitialSize; i++)
            {
                BodyParts.Add(Instantiate(BodySegmentPrefab));
            }

            transform.position = Vector2.zero;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Food"))
            {
              
                
                SnakeGrowth();
            }else if(other.gameObject.CompareTag("Obstacle"))
            {
                ResetSnake();
            }
        }
    }
}