using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFocLogic3 : MonoBehaviour
{
    [SerializeField] private Transform dest;
    private Animator animator;
    private float velocity = 2;
    private Vector3 previousPosition;
    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        Movement();
        FlipSprite();
    }
    private void Movement()
    {
        Vector3 direction = (dest.position - transform.position).normalized;
        transform.Translate(direction * velocity * Time.deltaTime);
        float movementThreshold = 0.1f;
        if (direction.magnitude > movementThreshold)
            animator.SetBool("Walking", true);
        else
            animator.SetBool("Walking", false);
    }
    private void FlipSprite()
    {
        Vector3 currentPosition = transform.position;
        if (currentPosition.x <= previousPosition.x) { this.gameObject.GetComponent<SpriteRenderer>().flipX = false; }
        else if (currentPosition.x > previousPosition.x) { this.gameObject.GetComponent<SpriteRenderer>().flipX = true; }
        previousPosition = currentPosition;
    }
}
