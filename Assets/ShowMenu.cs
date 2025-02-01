using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    private bool isVisible;
    public GameObject objectToAppear1;
    public GameObject objectToAppear2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ToggleObject()
    {
        isVisible = !isVisible;
        objectToAppear1.SetActive(isVisible); // Show or hide object
        objectToAppear2.SetActive(isVisible);
        Debug.Log("showmenu");
    }
}
