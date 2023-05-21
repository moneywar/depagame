using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    private SkillCoolDown skill;

    private void Start() {
        skill = GetComponent<SkillCoolDown>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && skill.Ready)
        {
            DamageManager manager = other.GetComponent<DamageManager>();
            float damage = GetComponentInParent<AttackPower>().Atk;
            manager.TakeDamage(damage);
            skill.Use();
        }
    }
}
