using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    [SerializeField] private int hp;
    private UnityEvent damageEvent = new UnityEvent();
    private UnityEvent deadEvent = new UnityEvent();

    private void Start()
    {
        hp = Random.Range(50, 100);
    }

    public void SetHp(int h)
    {
        hp = h;
    }

    public int GetHp()
    {
        return hp;
    }

    public void AddDamageEventListener(UnityAction unityAction)
    {
        damageEvent.AddListener(unityAction);
    }

    public void AddDeadEventListener(UnityAction unityAction)
    {
        deadEvent.AddListener(unityAction);
    }

    public virtual void SetDamage(int damage)
    {
        if (hp > 0)
        {
            if (damageEvent != null)
                damageEvent.Invoke();
            hp -= damage;
            if (hp <= 0)
                Dead();
            
        }
    }

    private void Dead()
    {
        if (deadEvent != null)
            deadEvent.Invoke();
        gameObject.SetActive(false);
    }
}
