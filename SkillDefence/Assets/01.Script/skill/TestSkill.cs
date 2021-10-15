using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkill : Skill
{
    public float bloodEffectTime = 0.5f;

    public override void OnDamage(float damage, Vector3 position, Vector3 normal)
    {
        if (dead) return;

        base.OnDamage(damage, position, normal);
        StartCoroutine(ShowBloodEffect(position, normal));
    }

    private IEnumerator ShowBloodEffect(Vector3 position, Vector3 normal)
    {
        // GameObject effect = EffectManager.GetBloodEffect();
        // Quaternion rot = Quaternion.LookRotation(normal);
        // effect.transform.position = position;
        // effect.transform.rotation = rot;
        // effect.SetActive(true);
        yield return new WaitForSeconds(bloodEffectTime);
        // effect.SetActive(false);
    }

    public override void Die()
    {
        base.Die();
    }

    public void Move()
    {
        if(rect.anchoredPosition.x <= 2400f)
        {
            float x1 = rect.anchoredPosition.x;
            x1 += 1f;
            rect.anchoredPosition = new Vector3(x1, 0);
        }
    }
}
