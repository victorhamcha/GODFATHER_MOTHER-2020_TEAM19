using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LancerLeJeu : MonoBehaviour
{
    public GameObject fade;
    public void Transition()
    {
        fade.SetActive(true);
    }
 public void lancer()
    {
        SceneManager.LoadScene("VictorTrans");
    } 
}
