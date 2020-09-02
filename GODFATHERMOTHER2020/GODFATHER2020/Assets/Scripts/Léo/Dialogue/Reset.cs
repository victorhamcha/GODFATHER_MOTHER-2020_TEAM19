using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class Reset : DialogueBase
    {
        private int i = 0;
        public float TimeBetween;
        public float TimeLeft;
        public GameObject Fond;
        public void start()
        {
            TimeLeft = TimeBetween;
        }
        public void Update()
        {
            if (transform.GetChild(i).GetComponent<DialogueHolder>().IsFinished == true)
            {
                TimeLeft -= Time.deltaTime;
                Fond.SetActive(false);
                transform.GetChild(i).gameObject.SetActive(false);
                if(TimeLeft <= 0f)
                {
                    TimeLeft = TimeBetween;
                    transform.GetChild(i + 1).gameObject.SetActive(true);
                    Fond.SetActive(true);
                    i++;
                }
            }


        }

    }

}
