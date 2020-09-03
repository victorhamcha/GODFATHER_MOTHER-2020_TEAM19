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
            if(Input.GetKey(KeyCode.Space) && i == 0)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
            }
            if (transform.GetChild(i-1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButtonDown("joystic button 0") && i == 1)
            {
                transform.GetChild(i-1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
            }
            if (transform.GetChild(i-1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButtonDown("joystic button 0") && i == 2)
            {
                transform.GetChild(i-1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
            }
            if (transform.GetChild(i-1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButtonDown("joystic button 0") && i == 3)
            {
                transform.GetChild(i-1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
              
            }
            if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButtonDown("joystic button 0") && i == 4)
            {
                transform.GetChild(i - 1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
                
            }
            if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButtonDown("joystic button 0") && i == 5)
            {
                transform.GetChild(i - 1).gameObject.SetActive(false);
                transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished = false;
                transform.GetChild(i).gameObject.SetActive(true);
                i++;
                
            }
            if (transform.GetChild(i - 1).GetComponent<DialogueHolder>().IsFinished == true && Input.GetButtonDown("joystic button 0") && i == 6)
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
