using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float velocidadeAndar;
    public Rigidbody2D meuRB;

    public float velocidadePular;
    private int puloCont;
    public SpriteRenderer meuSR;

    public Animator animator;

    public bool orbColada;
    public bool orbSegurada;
    public bool orbAtirada;
    private int virado;
    private int viradoAoAtirar;
    private float posicaoInicialX;
    private float posicaoInicialY;
    private float posicaoInicialZ;
    public Orb orb;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        orbColada = false;
        orbSegurada = false;
        orbAtirada = false;
        virado = 1;
        posicaoInicialX = transform.position.x;
        posicaoInicialY = transform.position.y;
        posicaoInicialZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(meuRB.velocity.x));
        if (Mathf.Abs(meuRB.velocity.y) > 0) {
            animator.SetBool("IsJumping", true);
        } else {
            animator.SetBool("IsJumping", false);
        }

        if(meuRB.velocity.x < 0) {
            if(Physics2D.gravity.y > 0) { 
                meuSR.flipX = false;
            } else {
                meuSR.flipX = true;
            }
            virado = -1;
        }
        if (meuRB.velocity.x > 0) {
             if(Physics2D.gravity.y > 0) { 
                meuSR.flipX = true;
            } else {
                meuSR.flipX = false;
            }
            virado = 1;
        }

        if(Physics2D.gravity.x == 0 && Physics2D.gravity.y < 0) { //CHAO 
            if(Input.GetAxisRaw("Horizontal") > 0f) {
                meuRB.velocity = new Vector3(velocidadeAndar, meuRB.velocity.y, 0f);
            } else if(Input.GetAxisRaw("Horizontal") < 0f) {
                meuRB.velocity = new Vector3(-velocidadeAndar, meuRB.velocity.y, 0f);
            } else {
                meuRB.velocity = new Vector3(0f, meuRB.velocity.y, 0f);
            }
            if (Input.GetButtonDown("Jump") && puloCont < 2){
                meuRB.velocity = new Vector3(meuRB.velocity.x, velocidadePular, 0f);
                puloCont = puloCont + 1;
            }
        } else if(Physics2D.gravity.x > 0 && Physics2D.gravity.y == 0) { //PAREDE DIR
            if (Input.GetAxisRaw("Horizontal") > 0f){
                meuRB.velocity = new Vector3(meuRB.velocity.x, velocidadeAndar, 0f);
            } else if (Input.GetAxisRaw("Horizontal") < 0f){
                meuRB.velocity = new Vector3(meuRB.velocity.x, -velocidadeAndar, 0f);
            } else {
                meuRB.velocity = new Vector3(meuRB.velocity.x, 0f, 0f);
            }
            if (Input.GetButtonDown("Jump") && puloCont < 2){
                meuRB.velocity = new Vector3(-velocidadePular, meuRB.velocity.y, 0f);
                puloCont = puloCont + 1;
            }
        } else if(Physics2D.gravity.x == 0 && Physics2D.gravity.y > 0) { //TETO
            if(Input.GetAxisRaw("Horizontal") > 0f) {
                meuRB.velocity = new Vector3(-velocidadeAndar, meuRB.velocity.y, 0f);
            } else if(Input.GetAxisRaw("Horizontal") < 0f) {
                meuRB.velocity = new Vector3(velocidadeAndar, meuRB.velocity.y, 0f);
            } else {
                meuRB.velocity = new Vector3(0f, meuRB.velocity.y, 0f);
            }
            if (Input.GetButtonDown("Jump") && puloCont < 2){
                meuRB.velocity = new Vector3(meuRB.velocity.x, -velocidadePular, 0f);
                puloCont = puloCont + 1;
            }
        }else if(Physics2D.gravity.x < 0 && Physics2D.gravity.y == 0) { //PAREDE ESQ
            if (Input.GetAxisRaw("Horizontal") > 0f){
                meuRB.velocity = new Vector3(meuRB.velocity.x, -velocidadeAndar, 0f);
            } else if (Input.GetAxisRaw("Horizontal") < 0f){
                meuRB.velocity = new Vector3(meuRB.velocity.x, velocidadeAndar, 0f);
            } else {
                meuRB.velocity = new Vector3(meuRB.velocity.x, 0f, 0f);
            }
            if (Input.GetButtonDown("Jump") && puloCont < 2){
                meuRB.velocity = new Vector3(velocidadePular, meuRB.velocity.y, 0f);
                puloCont = puloCont + 1;
            }
        }else if(Physics2D.gravity.x > 0 && Physics2D.gravity.y < 0) { //DIAGONAL INF DIR
            if (Input.GetAxisRaw("Horizontal") > 0f){
                meuRB.velocity = new Vector3(velocidadeAndar/2, velocidadeAndar/2, 0f);
            } else if (Input.GetAxisRaw("Horizontal") < 0f){
                meuRB.velocity = new Vector3(-velocidadeAndar/2, -velocidadeAndar/2, 0f);
            } else {
                meuRB.velocity = new Vector3(meuRB.velocity.x/2 , meuRB.velocity.y/2 , 0f);
            }
            if (Input.GetButtonDown("Jump") && puloCont < 2){
                meuRB.velocity = new Vector3(-velocidadePular, meuRB.velocity.x, 0f);
                puloCont = puloCont + 1;
            }
        } else if(Physics2D.gravity.x > 0 && Physics2D.gravity.y > 0) { //DIAGONAL SUP DIR
            if (Input.GetAxisRaw("Horizontal") > 0f){
                meuRB.velocity = new Vector3(-velocidadeAndar/2, velocidadeAndar/2, 0f);
            } else if (Input.GetAxisRaw("Horizontal") < 0f){
                meuRB.velocity = new Vector3(velocidadeAndar/2, -velocidadeAndar/2, 0f);
            } else {
                meuRB.velocity = new Vector3(meuRB.velocity.x/2, meuRB.velocity.y/2, 0f);
            }
        }else if(Physics2D.gravity.x < 0 && Physics2D.gravity.y > 0) { //DIAGONAL SUP ESQ
            if (Input.GetAxisRaw("Horizontal") > 0f){
                meuRB.velocity = new Vector3(-velocidadeAndar/2, -velocidadeAndar/2, 0f);
            } else if (Input.GetAxisRaw("Horizontal") < 0f){
                meuRB.velocity = new Vector3(velocidadeAndar/2, velocidadeAndar/2, 0f);
            } else {
                meuRB.velocity = new Vector3(-meuRB.velocity.x/2, meuRB.velocity.y/2, 0f);
            }
        }else if(Physics2D.gravity.x < 0 && Physics2D.gravity.y < 0) { //DIAGONAL INF ESQ
            if (Input.GetAxisRaw("Horizontal") > 0f){
                meuRB.velocity = new Vector3(velocidadeAndar/2, -velocidadeAndar/2, 0f);
            } else if (Input.GetAxisRaw("Horizontal") < 0f){
                meuRB.velocity = new Vector3(-velocidadeAndar/2, velocidadeAndar/2, 0f);
            } else {
                meuRB.velocity = new Vector3(-meuRB.velocity.x/2, -meuRB.velocity.y/2, 0f);
            }
        }
        if(meuRB.velocity.y == 0){
            puloCont = 0;
        }

        if (Input.GetButtonDown("Fire3") && orbColada == true) {
            orbSegurada = true;
            orb.transform.parent = transform;
            orb.meuRB.gravityScale = 0;
            //orb.meuRB.isKinematic = true;
        }

        if(orbSegurada == true) {
            orb.meuRB.isKinematic = true;
            orb.transform.position = new Vector3(transform.position.x + 0.5f * virado, transform.position.y, 0f);
        }

        if (Input.GetButtonDown("Fire2") == true && orbSegurada == true) //lança orb
        {
            orbSegurada = false;
            orbColada = false;
            orb.meuRB.gravityScale = 1;
            orb.transform.parent = null;
            transform.eulerAngles = new Vector3(0, 0, 0);
            meuRB.velocity = new Vector3(0f, 0f, 0f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            //orb.meuRB.velocity = new Vector3(velocidadeAndar * 30, orb.meuRB.velocity.y, 0f);
            orbAtirada = true;
            orb.emMovimento = true;
            viradoAoAtirar = virado;
            //orb.transform.position += new Vector3(velocidadeAndar, 0f, 0f);
        }

        if (Input.GetButtonUp("Fire3") == true) {
            orb.meuRB.isKinematic = false;
            orbSegurada = false;
            orb.meuRB.gravityScale = 1;
            orb.transform.parent = null;
            //orb.meuRB.isKinematic = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
            meuRB.velocity = new Vector3(0f, 0f, 0f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
        }

        if(orbAtirada == true) {
            orb.meuRB.isKinematic = false;
            orb.transform.position += new Vector3(0.1f* viradoAoAtirar, 0f, 0f);
        }

        if(orb.emMovimento == false)
        {
            orbAtirada = false;
        }

        /*
        if (Input.GetButtonDown("Jump") && puloCont < 2){
            meuRB.velocity = new Vector3(meuRB.velocity.x, velocidadePular, 0f);
            puloCont = puloCont + 1;
        }*/

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tiro" || other.tag == "Espeto" || other.tag == "Inimigo")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            meuRB.velocity = new Vector3(0f, 0f, 0f);
            Physics2D.gravity = new Vector2(0f, -9.81f);
            transform.position = new Vector3(posicaoInicialX, posicaoInicialY, posicaoInicialZ);
        }

        if (other.tag == "Orb")
        {
            orbColada = true;
        }

        if (other.tag != "Orb")
        {
            orbColada = false;
        }
    }
}
