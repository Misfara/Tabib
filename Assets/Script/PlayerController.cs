using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
    
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float HAxis;

    bool hitted = false;

    float ZAxis;

    bool canMove= true;

    UnityEngine.Vector2 direction ;

    UnityEngine.Vector2 newDirectionH;
   
   UnityEngine.Vector2 newDirectionZ ;
    Rigidbody2D rb;

     [SerializeField]
    float speed = 3;

    [SerializeField]
    float DashPower = 5;
    [SerializeField] bool isblocked = false;

    [SerializeField] bool isDashing = false;

    [SerializeField]float JumpPower = 3;

    [SerializeField]
    bool OnGround = true ;

    Animator animator;

    [SerializeField]TrailRenderer tr;
    
    private bool canDash = true;

    ChargeAttack chargeAttack;
   
   
    private float dashingTime = 0.2f;

    [SerializeField]private float dashingCooldown =1f;

    [SerializeField] private Cooldown cooldown;

    public Attacking attacking;

    public float knockbackForce;
    public float knockbackCounter;
    public float knockbackTime;

    public bool knockFromRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tr = GetComponentInChildren<TrailRenderer>();
        chargeAttack = GetComponent<ChargeAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockbackCounter<=0){

        
          if(canMove){

       
    
      if(isDashing){
        return;
      }
        Movement();
        Dash();
        facing();
        Dashing();
        Jump();
        animations();
        AttackingInput();
        
    }
    }else{
        if(knockFromRight == true){
            rb.velocity = new UnityEngine.Vector2 (-knockbackForce,knockbackForce);
        }
        if(knockFromRight == false){
            rb.velocity = new UnityEngine.Vector2 (knockbackForce,-knockbackForce);
        }

        knockbackCounter -= Time.deltaTime; 
    }
    }

void Dash(){
    if(Input.GetKeyDown(KeyCode.Space)&& canDash){
        StartCoroutine(Dashing());
    }
}

    private IEnumerator Dashing(){
        canDash = false;
        isDashing = true;
        rb.velocity = new UnityEngine.Vector3 (HAxis,ZAxis)*DashPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.velocity = new UnityEngine.Vector3 (0,0);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash=true;
        
    }

    
    

    public void Movement()
    {
        //Player Input
        if(isblocked== false){
        HAxis = Input.GetAxis("Horizontal");
        ZAxis = Input.GetAxis("Vertical");
        direction = new UnityEngine.Vector2 (HAxis,ZAxis); 
        rb.MovePosition(rb.position + direction*speed*Time.fixedDeltaTime);
        }

    if(isblocked == true){
        newDirectionH = new UnityEngine.Vector2 (HAxis,0); 
        rb.MovePosition(rb.position + newDirectionZ*speed*Time.fixedDeltaTime);
    }
        if(isblocked == true){
        newDirectionZ = new UnityEngine.Vector2 (0,ZAxis); 
        rb.MovePosition(rb.position + newDirectionZ*speed*Time.fixedDeltaTime);
       
    }

    
    }
     

    void Jump()
    {

        
    }

    private void OnTriggerExit(Collider col){
        if(col.tag == "Wall"){
           isblocked = false; 

        
        }
    }

    

    private void OnTriggerEnter(Collider col){
        if(col.tag == "Wall"){
           isblocked = true;    
           
        }
    }


    


    void facing(){
        // is player going left scale = -1
        if(HAxis < 0 ){
            transform.localScale = new UnityEngine.Vector3 (-1,1,1);
            
           
        } else if(HAxis > 0 ){
            transform.localScale = new UnityEngine.Vector3 (1,1,1);
            
            
        }
        // is player doing right scale = 1
    }

    

    void animations(){
        // if player if moving 
        animator.SetFloat("RightLeft", Mathf.Abs(HAxis));
        animator.SetFloat("UpDown",Mathf.Abs(ZAxis)); 
        animator.SetBool("Dash",isDashing);
        
        }

        void AttackingInput(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            animator.SetTrigger("Attacking");
        }
    }

public void Attacking(){
    LockMovement();
   if(HAxis < 0 ){
    transform.localScale = new UnityEngine.Vector3 (-1,1,1);
    attacking.AttackLeft();
   }else{

    attacking.AttackRight();}
}
    public void LockMovement(){
    canMove= false;
    }
    public void UnlockMovement(){
        canMove= true;
    }


    public void EndStopAttack(){
        attacking.StopAttack();
        canMove= true;
    }
    
}
