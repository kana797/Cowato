using UnityEngine;
using System.Collections;

public class CowatoController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Animator animator;
    public WeatherData weatherData;

    private bool isWorking;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isWorking) // Left-click
        {
            Pat();
        }

    }

    public void Pat()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject) // If this sprite is clicked
        {
            animator.SetTrigger("Pat");
            StartCoroutine(WaitforAnimation(1.1f));
        }

    }

    public void Feed()
    {
        if (!isWorking)
        {
            animator.SetTrigger("Feed");
            StartCoroutine(WaitforAnimation(1f));
        }
    }

    public void Stretch()
    {
        animator.SetTrigger("Stretch");
        isWorking = true;
        StartCoroutine(WaitforAnimation(60f));
    }

    public void Meditation()
    {
        animator.SetTrigger("Meditation");
        isWorking = true;
        StartCoroutine(WaitforAnimation(60f));
    }


    IEnumerator WaitforAnimation(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for 'delay' seconds
        animator.SetTrigger("BackToIdle");
        isWorking = false;
    }

}
