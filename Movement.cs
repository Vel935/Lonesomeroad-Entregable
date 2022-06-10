using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    public float Speed;
    public float JumpForce;
    // Start is called before the first frame update
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Vertical;
    private float Horizontal ; // Se declara aqui por que necesitamos que pueda ser usada por todo el programa
    
    private bool Grounded;

    

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        //Vertical = Input.GetAxisRaw("Vertical");
        

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Manejo de los parametor de animacion    
        // Vertical == 0.0f quiere decir que no estamos oprimiendo ni w ni s  o sea que el personaje solo se va mover horizontalmente 

        Animator.SetBool("running", Horizontal != 0.0f);   // Esto se hace para comprobar a traves del parametro bool en que animacion se encuentra
        Animator.SetBool("quieto", Horizontal == 0.0f);

        Debug.DrawRay(transform.position, Vector3.down*0.7f , Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.7f))
        {
            Grounded = true;
        }
        else Grounded = false;    //

        // animacion de salto luego de saber si estamos en el suelo 
        
        
        Animator.SetBool("grounded", Grounded);  // Si no esta en el suelo inicie la animacion de salto


        
        

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);  // Todas las variables van apareciendo en el unity 
                                                       // en el inspector de unity
    }



    private void FixedUpdate()  // Se usa este metodo cuando se  
    {                           //involucran fisicas debido a que estas se actuailizan de manera mas constante

        Rigidbody2D.velocity = new Vector2(Horizontal*Speed, Rigidbody2D.velocity.y);
    }
}   
    
