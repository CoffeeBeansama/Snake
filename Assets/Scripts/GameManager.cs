using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class GameManager : MonoBehaviour
    {
        public KeyCode[] Inputs;
        private void Update()
        {
            for (int i = 0; i < Inputs.Length; i++)
            {
                if (Input.GetKeyDown(Inputs[i]))
                {
                    SceneManager.LoadScene("Snake");
                }
            }
        }
    }
}