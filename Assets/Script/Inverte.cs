//By: Mark Ribeiro
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverte : MonoBehaviour
{
    public PlayerMove player;
    public int gira;
    public float x;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.orb == false){
            player.transform.eulerAngles = new Vector3(0, 0, 0);
            Physics2D.gravity = new Vector2(0f, -9.81f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && player.orbSegurada == true)
        {
            player.transform.eulerAngles = new Vector3(0, 0, gira);
            Physics2D.gravity = new Vector2(x, y);
            
        }
    }
}
