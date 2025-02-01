using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator CowatoController;
    public void Feed()
    {
        Debug.Log("?????");
        CowatoController.SetTrigger("Feed");
    }
}
