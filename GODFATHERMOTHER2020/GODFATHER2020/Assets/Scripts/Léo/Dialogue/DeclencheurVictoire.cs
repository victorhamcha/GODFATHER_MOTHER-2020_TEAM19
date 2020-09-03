using DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclencheurVictoire : MonoBehaviour
{
    public GameObject ScriptVictoire;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ScriptVictoire.SetActive(true);
        }
    }
}
