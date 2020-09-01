using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{   public class DialogueLine : DialogueBase
    {
        private Text textHolder;
        [SerializeField] private string input;
        [SerializeField] private float delay;
        [SerializeField] private float delayBetween;
        private void Awake()
        {
            textHolder = GetComponent<Text>();

           
        }
        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, delay,delayBetween));
        }
    }
  
}

