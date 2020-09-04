using DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclencheurVictoire : MonoBehaviour
{
    public GameObject ScriptVictoire;
    public GameObject Boss;
    private void Update()
    {
        if (Boss.GetComponent<BossManager>().hp <= 0)
        {
            ScriptVictoire.SetActive(true);
            Boss.GetComponent<BossManager>().enabled = false;
        }
    }
}
