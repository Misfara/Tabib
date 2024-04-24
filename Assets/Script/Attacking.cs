using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{

    public float damage = 1;

    Vector2 rightAttackOffset;
    public Collider2D swordCollider;
    // Start is called before the first frame update
 
    private void Start(){

   
    rightAttackOffset=transform.position;

    }

    

     public  void AttackRight(){
       
     swordCollider.enabled = true;
     transform.localPosition= rightAttackOffset;
     }

   public void AttackLeft(){
   
        swordCollider.enabled = true;
    transform.localPosition= new UnityEngine.Vector2(0.5f, rightAttackOffset.y);
    }
        
     public void StopAttack(){
    swordCollider.enabled = false;
        
    }

     private void OnTriggerEnter2D(Collider2D other){
        print("blyat");
    if(other.tag == "Enemy"){}
        Enemy enemy = other.GetComponent<Enemy>();
        
        if(enemy!=null){
            enemy.Health -= damage;
        }
    }   

    
}

