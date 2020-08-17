//By: Mark Ribeiro
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public float tempoDoTiro;
    int i;
    public GameObject tiro;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoDoTiro*i - Time.time <= 0f)
        {
            Instantiate(tiro, transform.position, Quaternion.identity);
            i = i + 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Orb")
        {
            Destroy(gameObject);
        }
    }
}
