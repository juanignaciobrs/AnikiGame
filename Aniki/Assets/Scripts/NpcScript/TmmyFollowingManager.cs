using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmmyFollowingManager : MonoBehaviour
{

    public float speed;

    public Rigidbody2D rb;

    public Transform target; 

    private Vector2 toTarget;


    public float minDistance = 0.2f;


    public Transform Trigger1;

    public Transform Trigger2;


    bool toTrigger2;

    public float jumpForce;


    bool isGrounded;


   

    public Vector2 mov;

    // Start is called before the first frame update





    //BOOLS FOR STATE MACHINE

    private bool isWandering = false;
    private bool isJumping = false;
    private bool isNothing = false;

    //carlos me come los huevos

    // y ra�l tb
    private float timer; 
   


    void Start()
    {
        toTrigger2 = true;

      
      StartCoroutine(leTimmyController());

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    void FixedUpdate()
    {

        timer += Time.deltaTime;

        if (isJumping && timer >=1f)
        {
            timer = 0;
            jumping();
      
        }
        if (isWandering)
        {
            wandering();
        }

        if (isNothing)
        {
            rb.velocity = Vector2.zero;
        }

        //  StartCoroutine(jump());
        // wandering();



    }



    void tommyController(int n)
    {

        switch (n) {
        case 1:
                isJumping = true;
                isWandering = false;
                isNothing = false;

                Debug.Log("TIMMY SALTA");

        break;

        case 2:
                Debug.Log("TIMMY CAMINA");
                isJumping = false;
                isWandering = true;
                isNothing = false;

                jumping();

        break;
            case 3:
                Debug.Log("TIMMY NO HACE NADA");
                isJumping = false;
                isWandering = false;
                isNothing = true;

                break;
        }
    }




    void wandering()
    {
        // caminar del punto 1 al punto 2 a velocidad constante

        if (toTrigger2)
        {
            mov = Trigger2.transform.position - transform.position;

            mov = mov.normalized;
                
            rb.velocity = mov * speed;
        }

        if (toTrigger2==false)
        {
            mov = Trigger1.transform.position - transform.position;

            mov = mov.normalized;

            rb.velocity = mov * speed;
        }


    }
    
    
    void following()
    {

        toTarget = (target.transform.position - transform.position).normalized;

        if (Vector2.Distance(target.transform.position, transform.position) > minDistance)
        {



            rb.velocity = toTarget * speed * Time.fixedDeltaTime;

        }
        else
        {
            rb.velocity = Vector2.zero;
        }




        
}


    void singing()
    {

    }

    void jumping()
    {

      
        if (isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;

        }




    }



    private void OnTriggerEnter2D(Collider2D outsider)
    {
        if (outsider.gameObject.CompareTag("Trigger2"))
        {

           
            toTrigger2 = false;

    
        }
        if (outsider.gameObject.CompareTag("Trigger1"))
        {
          
            toTrigger2 = true;

        }


    



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
            if (other.gameObject.CompareTag("Ground"))
            {

                isGrounded = true;

            }
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {

            isGrounded = false;

        }

    }



    /*IEnumerator jump()
    {

        int jumps = 1;

        if (isGrounded) { 
        rb.velocity = Vector2.up * jumpForce;
            
        }


       
    }*/


    IEnumerator leTimmyController()
    {


        for (int i = 0; i < 100; i++)
        {

            int accion = Random.Range(1, 4);

            int duracion = Random.Range(1, 3);

            yield return new WaitForSeconds(2);


             tommyController(accion);

    

            yield return new WaitForSeconds(duracion);
     

        }


    }
    IEnumerator jumpingWait()
    {


        Debug.Log("SALTO");

        


            yield return new WaitForSeconds(2);



    }
}