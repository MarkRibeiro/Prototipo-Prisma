//By: Mark Ribeiro
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public Rigidbody2D meuRB;
    public CircleCollider2D meuCC;
    public bool emMovimento;
    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        meuCC = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Parede" && emMovimento == true)
        {
            emMovimento = false;
        }
    }

}
