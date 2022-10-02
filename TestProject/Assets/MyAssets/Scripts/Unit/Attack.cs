using System;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private int attack = 10;
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float attackRate = .5f;
    private Movement movement;
    private Transform tr;

    private void Start()
    {
        attack = UnityEngine.Random.Range(5, 10);
        attackDistance = UnityEngine.Random.Range(1f, 3f);
    }

    public void SetTarget(Transform trg)
    {
        target = trg;
    }

    public void SetAttack(int a)
    {
        attack = a;
    }

    public void SetAttackDistance(float a)
    {
        attackDistance = a;
    }

    public void SetAttackRate(float a)
    {
        attackRate = a;
    }

    private void Awake()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        if (TryGetComponent(out Movement m))
            movement = m;
        else
            throw new NullReferenceException();
        tr = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (target == null)
            return;
        if (Distance(target.position, tr.position) > attackDistance)
            movement.Move(target.position);
        else
        {
            if(RecentAttack() > attackRate)
                SetAttack();
        }
    }
            
    private float Distance(Vector3 start, Vector3 end)
    {
        return (start - end).magnitude;
    }

    private float recentTime;
    private void SetAttack()
    {
        target.SendMessage("SetDamage", attack);
        recentTime = Time.time;
        if (target.gameObject.activeSelf == false)
            target = null;
    }

    private float RecentAttack()
    {
        return Time.time - recentTime;
    }
}
