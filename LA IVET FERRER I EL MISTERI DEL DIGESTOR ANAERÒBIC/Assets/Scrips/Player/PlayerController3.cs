using UnityEngine;
public class PlayerController3 : MonoBehaviour
{
    private Vector3 finishPos;
    private Vector3 lastPosition;
    [SerializeField] private float velocity, limitToWalk;
    private Vector3 previousPosition;
    private bool canInteract;

    [SerializeField] private Vector2 minYRange = new Vector2(-5, 0), scaleRange = new Vector2(0.2f, 1.0f);

    [SerializeField] private Animator animator;
    private bool isMoving;
    private void Update()
    {
        Movement();
        AnimationController();
        Scale();
    }
    private void Movement()
    {
        if (isMoving && finishPos.y <= limitToWalk)
            this.transform.position = Vector3.MoveTowards(this.transform.position, finishPos, velocity * Time.deltaTime);

        if (isMoving && Vector3.Distance(this.transform.position, finishPos) < 0.01f)
            isMoving = false;
    }
    private void FlipingSprite()
    {
        Vector3 currentPosition = transform.position;
        if (currentPosition.x > previousPosition.x) { this.gameObject.GetComponent<SpriteRenderer>().flipX = false; }
        else if (currentPosition.x < previousPosition.x) { this.gameObject.GetComponent<SpriteRenderer>().flipX = true; }
        previousPosition = currentPosition;
    }
    private void Scale()
    {
        float inverseScaleFactor = Mathf.InverseLerp(minYRange.x, minYRange.y, transform.position.y);
        float scaledValue = Mathf.Lerp(scaleRange.y, scaleRange.x, inverseScaleFactor);

        transform.localScale = new Vector3(scaledValue, scaledValue, 1f);
    }
    private void AnimationController()
    {
        animator.SetBool("isWalking", isMoving);
    }
    public void CanInteract()
    {
        canInteract = true;
    }
    public void CantInteract()
    {
        canInteract = false;
    }
}