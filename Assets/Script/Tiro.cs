//By: Mark Ribeiro
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade;
    private float nascimento;
    private float ultimaVezAndada;
    private float ultimoUpdate;

    // Start is called before the first frame update
    void Start()
    {
        nascimento = Time.time;
        ultimaVezAndada = Time.time;
        ultimoUpdate = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - nascimento >= 5f){
            Destroy(gameObject);
        }
        float intervaloUltimaVezAndada = Time.time - ultimaVezAndada;
        if (intervaloUltimaVezAndada >= 0.00003f) { 
            transform.position += new Vector3(velocidade * intervaloUltimaVezAndada, 0f, 0f);
            ultimaVezAndada = Time.time;
        }

        ultimoUpdate = Time.time;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Parede" || other.tag == "Player")
        {
         
        }
    }
}
