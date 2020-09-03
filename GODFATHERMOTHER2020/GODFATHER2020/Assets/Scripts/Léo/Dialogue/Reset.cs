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
        private bool IntroFin;
        
        public void start()
        {
            TimeBetween = transform.GetChild(i).GetComponent<DialogueHolder>().time;
            TimeLeft = TimeBetween;
            IntroFinie = false;
         
        }
        public void Update()
        {
            if(Input.GetKey(KeyCode.Space) && i == 0)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
            }
            if (transform.GetChild(i-1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetKey(KeyCode.Space) && i == 1)
            {
                transform.GetChild(i-1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
            }
            if (transform.GetChild(i-1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetKey(KeyCode.Space) && i == 2)
            {
                transform.GetChild(i-1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
            }
            if (transform.GetChild(i-1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetKey(KeyCode.Space) && i == 3)
            {
                transform.GetChild(i-1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
              
            }
            if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetKey(KeyCode.Space) && i == 4)
            {
                transform.GetChild(i - 1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
                
            }
            if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetKey(KeyCode.Space) && i == 5)
            {
                transform.GetChild(i - 1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
                
            }
            if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetKey(KeyCode.Space) && i == 6)
            {
                transform.GetChild(i - 1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                IntroFinie = true;
                i++;
            }
           
            if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && IntroFinie == true && i < transform.childCount)
                        {
                           
                            transform.GetChild(i - 1).gameObject.SetActive(false);
                            TimeLeft -= Time.deltaTime;
                            Fond.SetActive(false);
                            if (TimeLeft <= 0f)
                            {
                                
                                transform.GetChild(i).gameObject.SetActive(true);
                                TimeBetween = transform.GetChild(i + 1).GetComponent<DialogueHolder>().time;
                                TimeLeft = TimeBetween;
                                Fond.SetActive(true);
                                i++;
                            }
                        }
           
        }
 
    }
}
