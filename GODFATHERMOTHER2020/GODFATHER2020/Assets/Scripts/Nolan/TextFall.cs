using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFall : MonoBehaviour
{
    GameObject text;
    TextMeshPro t;
    public string texte;
    public int size;

    // Start is called before the first frame update
    void Start()
    {
        text = new GameObject();
        t = text.AddComponent<TextMeshPro>();

        t.text = texte;
        t.alignment = TextAlignmentOptions.Center;
        t.fontSize = size;

        text.tag = "Text";
        text.transform.SetParent(this.GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        t.transform.position = gameObject.transform.parent.position;
    }
}
