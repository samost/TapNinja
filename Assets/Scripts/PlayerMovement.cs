using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject sword;

    private float _oldSpeed;
    void Update()
    {
        transform.position += Vector3.forward * (Time.deltaTime * Speed);
    }

    public void StopMovedIfAttack()              // called in animation event
    {
        if (Speed > 0)
        {
            _oldSpeed = Speed;
            Speed = 0;
            sword.SetActive(true);
        }
        else
        {
            Speed = _oldSpeed;
            sword.SetActive(false);
        }
    }

    public void Attack()
    {
        animator.SetTrigger("1");
    }
}
