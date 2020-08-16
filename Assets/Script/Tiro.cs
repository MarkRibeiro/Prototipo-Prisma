using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade;
    private float nascimento;

    // Start is called before the first frame update
    void Start()
    {
        nascimento = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - nascimento >= 5f)
        {
            Destroy(gameObject);
        }

        transform.position += new Vector3(velocidade/100, 0f, 0f);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Parede" || other.tag == "Player")
        {
            //Destroy(gameObject);
        }
    }
}
