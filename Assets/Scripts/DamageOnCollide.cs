using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damage = 1;
    public int damageToSelf = 5;

    void HitObject(GameObject theObject)
    {
        var theirDamage = theObject.GetComponentInParent<DamageTaking>();

        if (theirDamage != null)
        {
            theirDamage.TakeDamage(damage);
        }

        var ourDamage = this.GetComponentInParent<DamageTaking>();
        if (ourDamage != null)
        {
            ourDamage.TakeDamage(damageToSelf);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        HitObject(collider.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitObject(collision.gameObject);
    }
}
