using UnityEngine;
using System.Collections;

public class CowatoController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Animator animator;
    private bool inAnimation;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject && !inAnimation) // If this sprite is clicked
            {
                inAnimation = true;
                animator.SetTrigger("Pat");
                StartCoroutine(WaitforAnimation(4f)); 
                inAnimation = false;      
            }

        }
    }
    IEnumerator WaitforAnimation(float delay)
    {
        animator.SetBool("InAnimation",true);
        yield return new WaitForSeconds(delay); // Wait for 'delay' seconds
        animator.SetBool("InAnimation",false);
    }
}
