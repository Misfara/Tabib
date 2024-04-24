using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamageable
{
    public float Heatlh{set;get ; }
    public bool Targetable {set;get;}
    public bool invincible {set;get;}
    public void OnHit (float damage, UnityEngine.Vector2 knockback);

    public void OnHit(float damage);

    public void OnObjectDestroyed();

}

