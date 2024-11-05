using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variable condiciones
    public Conditions condition;

    //variables rangos
    public float followDistance;
    public float attackDistance;
    public float escapeDistance;
    public bool live = true;

    //Variables para buscar jugador
    public Transform target;
    public bool autoSelectTarget = true;
    public float distance;

    //calculo de distancia del jugador
    public void Awake() 
    {
        if (autoSelectTarget)
        {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(CalculateDistance());  
        }
    }

    
    IEnumerator CalculateDistance()
    {
        while (live)
        {
            if (target != null)
            {
                distance = Vector3.Distance(transform.position, target.position);
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    //Rango para los cambios de estados
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, escapeDistance);
    }

    private void LateUpdate() 
    {
        CheckCondition();
    }

    //Metodo para comprobar la condicion
    public void ChangueCondition(Conditions c)
    {
        switch(c)
        {
            case Conditions.idle:
                break;
            case Conditions.follow:
                break;
            case Conditions.attack:
                break;
            case Conditions.dead:
            live = false;
                break;
        }
        condition = c;
    }

    //metodo para verificar la condicion
    private void CheckCondition()
    {
        switch(condition)
        {
            case Conditions.idle:
                IdleCondition();
                break;
                
            case Conditions.follow:
                transform.LookAt(target, Vector3.up);
                FollowCondition();
                break;
                
            case Conditions.attack:
                AttackCondition();
                break;
                
            case Conditions.dead:
                DeadCondition();
                break;
                
        }

    }

    public virtual void IdleCondition()
    {
        if (distance < followDistance)
        {
            ChangueCondition(Conditions.follow);
        }
    }
    
    public virtual void FollowCondition()
    {
        if (distance < attackDistance)
        {
            ChangueCondition(Conditions.attack);
        }
        else if (distance > escapeDistance)
        {
            ChangueCondition(Conditions.idle);
        }
    }

    public virtual void AttackCondition()
    {
        if (distance > attackDistance)
        {
            ChangueCondition(Conditions.follow);
        }

    }

    public virtual void DeadCondition()
    {
        
    }
    
}

//condiciones
public enum Conditions
{
    idle = 0,
    follow = 1,
    attack = 2,
    dead = 3
}