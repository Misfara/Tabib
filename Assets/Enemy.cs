using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animator;
    public float Health{
        set{
            _health = value;
            if(_health >0){
                animator.SetTrigger("beingHit");
            }
            if(_health <=0){
                Dead();
            }   
        }
        get {
            return _health;
        }
    }

    public float _health = 3;

  
  public void Start(){
        animator = GetComponent<Animator>();
   }

   public void Dead(){
    animator.SetTrigger("Death");
   }

    public void RemoveEnemy(){
    Destroy(gameObject);
   }
}
