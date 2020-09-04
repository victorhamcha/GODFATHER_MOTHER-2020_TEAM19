using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DialogueSystem
{
    public class DialogueVictoire : MonoBehaviour
    {
        public GameObject Fond;
        private Text textHolder;
        [SerializeField] private string input;
        [SerializeField] private float delay;
        private void Awake()
        {
            textHolder = GetComponent<Text>();
            Fond.SetActive(true);
            StartCoroutine(WriteVictory(input,textHolder, 0.01f));
             
        }
        IEnumerator WriteVictory(string input, Text textholder, float delay)
        {
            for (int i = 0; i < input.Length; i++)
            {
                textholder.text += input[i];
                yield return new WaitForSeconds(delay);
            }

        }
        IEnumerator Menu()
        {
           
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene("VictorMenu");

        }


    }
    
}

