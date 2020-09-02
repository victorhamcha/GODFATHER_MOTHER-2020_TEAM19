using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFall : MonoBehaviour
{
    GameObject text;
    TextMeshPro t;

    // Start is called before the first frame update
    void Start()
    {
        text = new GameObject();
        t = text.AddComponent<TextMeshPro>();
        if (Random.Range(0, 2) == 0)
        {
            t.text = "UN PAPA";
            this.GetComponentInParent<BoxCollider2D>().size = new Vector2(10.5f,2.0f);
        }
        else
        {
            t.text = "UNE MAMAN";
            this.GetComponentInParent<BoxCollider2D>().size = new Vector2(15.0f, 2.0f);
        }

        t.alignment = TextAlignmentOptions.Center;
        t.fontSize = 25;

        text.tag = "Text";
    }

    // Update is called once per frame
    void Update()
    {
        t.transform.localPosition = gameObject.transform.parent.localPosition;
    }
}
