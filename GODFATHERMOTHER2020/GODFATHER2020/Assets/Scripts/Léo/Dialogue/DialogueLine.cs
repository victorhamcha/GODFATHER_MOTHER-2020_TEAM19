using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{   public class DialogueLine : DialogueBase
    {
        private string[] LignesDialogues;
        [Header("Dialogue")]
        [SerializeField] private string Dialogue1;
        [SerializeField] private string Dialogue2;
        [SerializeField] private string Dialogue3;
        [SerializeField] private string Dialogue4;
        [SerializeField] private string Dialogue5;

        
        private Text textHolder;
        [SerializeField] private string input;
        [SerializeField] private float delay;
        [SerializeField] private float delayBetween;

        public bool Fini;
        

        private void Awake()
        {

            textHolder = GetComponent<Text>();

           
        }
        private void Start()
        {
            
            LignesDialogues = new string[5];
            LignesDialogues[0] = Dialogue1;
            LignesDialogues[1] = Dialogue2;
            LignesDialogues[2] = Dialogue3;
            LignesDialogues[3] = Dialogue4;
            LignesDialogues[4] = Dialogue5;

            input = LignesDialogues[Random.Range(0, 4)];

            StartCoroutine(WriteText(input, textHolder, delay,delayBetween));
        }
    }
  
}

