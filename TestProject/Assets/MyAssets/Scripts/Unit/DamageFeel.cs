using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFeel : MonoBehaviour
{
    private Transform tr;
    private void Start()
    {
        tr = transform;
        if (TryGetComponent(out Damage dmg))
            dmg.AddDamageEventListener(AddDamageFeel);
    }

    private bool pulse = false;
    private void AddDamageFeel()
    {
        if (!pulse)
            StartCoroutine(Pulse());
    }

    IEnumerator Pulse()
    {
        pulse = true;
        tr.localScale = Vector3.one * 2.5f;
        while(tr.localScale != Vector3.one)
        {
            tr.localScale = Vector3.MoveTowards(tr.localScale, Vector3.one, 25f * Time.deltaTime);
            yield return null;
        }
        pulse = false;
    }
}
