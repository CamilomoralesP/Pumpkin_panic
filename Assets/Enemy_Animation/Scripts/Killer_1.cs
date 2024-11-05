using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Killer_1 : Enemy
{
    private NavMeshAgent agent;
    public Animator animatics;

    public float damage = 3;

    public void Awake() 
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    public override void IdleCondition()
    {
        base.IdleCondition();
        if(animatics!=null) animatics.SetFloat("Velocity", 0);
        if(animatics!=null) animatics.SetBool("Attack", false);
        agent.SetDestination(transform.position);
    }

    public override void FollowCondition()
    {
        base.FollowCondition();
        if(animatics!=null) animatics.SetFloat("Velocity", 1);
        if(animatics!=null) animatics.SetBool("Attack", false);
        agent.SetDestination(target.position);
    }

    public override void AttackCondition()
    {
        base.AttackCondition();
        if(animatics!=null) animatics.SetFloat("Velocity", 0);
        if(animatics!=null) animatics.SetBool("Attack", true);
        agent.SetDestination(transform.position);
        transform.LookAt(target, Vector3.up);
    }

    public override void DeadCondition()
    {
        base.DeadCondition();
        if(animatics!=null) animatics.SetBool("Live", false);
        agent.enabled = false;
    }

    [ContextMenu("Kill")]

    public void Kill()
    {
        ChangueCondition(Conditions.dead);
    }

}

