using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{   public class DialogueLine : DialogueBase
    {
        private string[] LignesDialoguesBoss;
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
        private void Awake()
        {

            textHolder = GetComponent<Text>();

           
        }
        private void Start()
        {
            LignesDialoguesBoss = new string[5];
            LignesDialoguesBoss[0] = Dialogue1;
            LignesDialoguesBoss[1] = Dialogue2;
            LignesDialoguesBoss[2] = Dialogue3;
            LignesDialoguesBoss[3] = Dialogue4;
            LignesDialoguesBoss[4] = Dialogue5;

            input = LignesDialoguesBoss[Random.Range(0, 4)];
            
           
            StartCoroutine(WriteText(input, textHolder, delay,delayBetween));
        }
    }
  
}

