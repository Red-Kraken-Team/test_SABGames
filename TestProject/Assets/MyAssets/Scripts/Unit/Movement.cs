
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Transform tr;

    private void Awake()
    {
        tr = transform;
    }

    public void Move(Vector3 target)
    {        
        Vector3 direction = (target - tr.position).normalized;
        direction = new Vector3(direction.x, 0, direction.z);
        tr.LookAt(target);
        tr.position +=(direction * moveSpeed * Time.deltaTime);
    }

}
