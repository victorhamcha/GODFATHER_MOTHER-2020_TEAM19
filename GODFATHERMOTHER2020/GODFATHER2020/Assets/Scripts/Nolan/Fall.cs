using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fall : MonoBehaviour
{
    private int speed = 2;
    public Transform roofPosition;
    private bool goal;

    [Header("Spawn Letter")]
    private int compt;
    public Transform[] spawnPoint;
    public GameObject letter;
    private int randLetter;
    private int randSpawn;
    private float cooldown=0.0f;
    private string text;

    // Start is called before the first frame update
    void Start()
    {
        roofPosition = GameObject.FindGameObjectWithTag("Roof").transform;
        this.transform.localPosition = GameObject.FindGameObjectWithTag("Enemy").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (text == null)
        {
            text = GameObject.FindGameObjectWithTag("Text").gameObject.GetComponent<TextMeshPro>().text;
            text = text.Replace(" ", "");
            compt = text.Length;
        }


        if (this.transform.position == roofPosition.position && !goal)
        {
            goal = true;
        }
        else if(this.transform.position != roofPosition.position && !goal)
        {
            this.transform.localPosition = Vector2.MoveTowards(transform.position, roofPosition.position, 1.5f*speed*Time.deltaTime);
        }

        cooldown -= Time.deltaTime;
        if (goal && cooldown <= 0)
        {
            randSpawn = Random.Range(0, 6);
            randLetter = Random.Range(0, text.Length);

            GameObject letterGameObject = (GameObject)Instantiate(letter, spawnPoint[randSpawn].position, spawnPoint[randSpawn].rotation);
            letterGameObject.GetComponentInChildren<TextFall>().texte = text[randLetter].ToString();
            for(int i=0;i< GameObject.FindGameObjectWithTag("Text").gameObject.GetComponent<TextMeshPro>().text.Length; i++)
            {
                if (GameObject.FindGameObjectWithTag("Text").gameObject.GetComponent<TextMeshPro>().text[i] == text[randLetter])
                {
                    GameObject.FindGameObjectWithTag("Text").gameObject.GetComponent<TextMeshPro>().text=GameObject.FindGameObjectWithTag("Text").gameObject.GetComponent<TextMeshPro>().text.Remove(i, 1);
                    i = GameObject.FindGameObjectWithTag("Text").gameObject.GetComponent<TextMeshPro>().text.Length;
                    text = GameObject.FindGameObjectWithTag("Text").gameObject.GetComponent<TextMeshPro>().text;
                    text = text.Replace(" ", "");
                }
            }
            compt--;
            cooldown = 1.0f;
        }

        if (compt==0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Text"));
            Destroy(this.gameObject);
        }
    }
}
