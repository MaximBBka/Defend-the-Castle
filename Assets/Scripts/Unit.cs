using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected CheckObstacle CheckObstacle;
    [SerializeField] protected Transform aim;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public Stats stats;
    [SerializeField] protected Animator animator;
    [SerializeField] private TextMeshProUGUI healtText;
    private WaitForSeconds wait;
    protected Coroutine coroutine; // Карутина задержки атаки

    private void OnDrawGizmos()
    {
        Gizmos.color = CheckObstacle.color;
        Gizmos.DrawWireSphere(aim.position, CheckObstacle.radius);
    }
    private void Update()
    {
        if (stats.Health <= 0)
        {
            if (animator != null)
            {
                Death();
            }
        }
        else
        {
            Find();
        }
    }
    public virtual void Find() { }
    public void Move()
    {
        animator.SetBool("IsWalk", true);
        animator.SetBool("IsAttack", false);
        rb.velocity = transform.forward * stats.MoveSpeed;
    }
    public virtual void Death()
    {
        animator.SetTrigger("IsDie");
        Destroy(gameObject, 0.7f);
    }
    public virtual void TakeDamage(float damage)
    {
        stats.Health -= damage;
        stats.Health = Mathf.Clamp(stats.Health, 0f, 10000f);
        healtText?.SetText(stats.Health.ToString());
    }
    public IEnumerator DelayAttack(Unit target)
    {
        AnimatorStateInfo clip = animator.GetCurrentAnimatorStateInfo(0);
        wait ??= new WaitForSeconds(clip.length); // Проверка на null
        yield return wait;
        target.TakeDamage(stats.Damage + Random.Range(0, 8));
        coroutine = null;
    }
}
