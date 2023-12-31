using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : CharacterController
{
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject attackArea;
    [SerializeField] private EnemySight enemySight;
    private IState currentState;
    private bool isRight=true;
    private CharacterController target;
    private bool isAttack=false;
    public CharacterController Target { get => target; set => target = value; }

    public void Update()
    {
        if(currentState != null && !IsDead)
        {
            currentState.OnExecute(this);
        }
    }
    public override void OnInit()
    {
        base.Damage = DataManager.GetInstance().GD.damgeEnemy;
        base.OnInit();
        ChangeState(new IdleState());
        DeActiveAttack();
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(HealthBar.gameObject);
        Destroy(gameObject);
    }
    protected override void OnDeath()
    {
        ChangeState(null);
        DataManager.GetInstance().GD.totalEnemy -= 1;
        if(DataManager.GetInstance().GD.totalEnemy < 0)
        {
            DataManager.GetInstance().GD.totalEnemy = 0;
        }
        base.OnDeath();
        
    }

    public void Moving()
    {
        ChangeAnim("run");
        rb.velocity = transform.right * moveSpeed ;
    }

    public void StopMoving() {
        ChangeAnim("idle");
        rb.velocity = Vector2.zero;
    }

    public void Attack()
    {
        if (isAttack)
        {
            return;
        }
        ChangeAnim("attack");
        isAttack = true;
        Invoke(nameof(UnAttack),0.5f);
        rb.velocity = Vector2.zero;
        ActiveAttack();
        Invoke(nameof(DeActiveAttack), 0.1f);
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if(currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    internal void SetTarget(CharacterController characterController)
    {
        this.target= characterController;
        if (IsTargetInRange())
        {
            ChangeState(new AttackState());
        }
        else
        if (target != null)
        {
            ChangeState(new PatrolState());
        }
        else
        {
            ChangeState(new IdleState());
        }
    }
    public bool IsTargetInRange()
    {
        if (target != null)
        {
            return Vector2.Distance(target.transform.position, transform.position) <= attackRange;
        }
        else
        {
            return false;
        }
    }
    private void UnAttack()
    {
        isAttack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyWall")
        {
            ChangeDirection(!isRight);
            enemySight.gameObject.SetActive(false);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnemyWall")
        {
            enemySight.gameObject.SetActive(true);
            target = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            ChangeDirection(!isRight);
        }
    }
    public void ChangeDirection(bool isRight)
    {
        this.isRight = isRight;

        transform.rotation = isRight ? Quaternion.Euler(Vector3.zero) : Quaternion.Euler(Vector3.up * 180);
    }
    private void ActiveAttack()
    {
        attackArea.SetActive(true);
    }
    private void DeActiveAttack()
    {
        attackArea.SetActive(false);
    }

}
