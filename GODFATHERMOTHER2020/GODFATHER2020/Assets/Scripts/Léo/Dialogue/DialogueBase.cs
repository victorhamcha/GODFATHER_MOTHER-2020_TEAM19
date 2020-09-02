using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBase : MonoBehaviour
    {
        public bool finished { get; private set; }
       protected IEnumerator WriteText(string input , Text textholder, float delay, float delayBetween)
        {
            for(int i = 0; i < input.Length; i++)
            {
                textholder.text += input[i];
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(delayBetween);
            finished = true;
        }
    }
}
