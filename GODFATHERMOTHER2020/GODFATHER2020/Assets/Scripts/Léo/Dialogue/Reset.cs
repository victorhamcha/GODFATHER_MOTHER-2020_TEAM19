using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class Reset : DialogueBase
    {
        private int i = 0;
        public float TimeBetween;
        public float TimeLeft;
        private bool IntroFinie;
        public GameObject Fond;
        public GameObject Fond2;
        private bool IntroFin;
        public GameObject Boss;
      

        public void Start()
        {
            Boss.GetComponent<BossManager>().enabled = false;
            TimeBetween = transform.GetChild(i).GetComponent<DialogueHolder>().time;
            TimeLeft = TimeBetween;
            IntroFinie = false;
         
        }
        public void Update()
        {
            if(Input.GetButton("Dialogues") && i == 0)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
            }
            if (i > 0)
            {
                if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButton("Dialogues") && i == 1)
                {
                    transform.GetChild(i - 1).gameObject.SetActive(false);
                    transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                    transform.GetChild(i).gameObject.SetActive(true);
                    i++;
                }
                if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButton("Dialogues") && i == 2)
                {
                    transform.GetChild(i - 1).gameObject.SetActive(false);
                    transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                    transform.GetChild(i).gameObject.SetActive(true);
                    i++;
                }
                if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButton("Dialogues") && i == 3)
                {
                    transform.GetChild(i - 1).gameObject.SetActive(false);
                    transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                    transform.GetChild(i).gameObject.SetActive(true);
                    i++;

                }
                if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButton("Dialogues") && i == 4)
                {
                    transform.GetChild(i - 1).gameObject.SetActive(false);
                    transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                    transform.GetChild(i).gameObject.SetActive(true);
                    i++;

                }
                if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButton("Dialogues") && i == 5)
                {
                    transform.GetChild(i - 1).gameObject.SetActive(false);
                    transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                    transform.GetChild(i).gameObject.SetActive(true);
                    i++;

                }
                if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButton("Dialogues") && i == 6)
                {
                    transform.GetChild(i - 1).gameObject.SetActive(false);
                    transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                    transform.GetChild(i).gameObject.SetActive(true);
                    IntroFinie = true;
                    i++;

                }

                if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && IntroFinie == true && i < transform.childCount)
                {
                    Boss.GetComponent<BossManager>().enabled = true;
                    transform.GetChild(i - 1).gameObject.SetActive(false);
                    Fond.SetActive(false);
                    Fond2.SetActive(false);
                    TimeLeft -= Time.deltaTime;
                    
                    if (TimeLeft <= 0f)
                    {
                        
                        transform.GetChild(i).gameObject.SetActive(true);
                        TimeBetween = transform.GetChild(i + 1).GetComponent<DialogueHolder>().time;
                        Fond2.SetActive(true);
                        TimeLeft = TimeBetween;
                        

                        i++;
                    }
                }
            }
           
        }
 
    }
}
