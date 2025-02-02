using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    private bool isVisible;
    public GameObject objectToAppear1;
    public GameObject objectToAppear2;
    public GameObject objectToAppear3;
    public GameObject objectToAppear4;
    public GameObject objectToAppear5;
    public GameObject objectToAppear6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ToggleObject()
    {
        isVisible = !isVisible;
        objectToAppear1.SetActive(isVisible); // Show or hide object
        objectToAppear2.SetActive(isVisible);
        objectToAppear3.SetActive(isVisible);
        objectToAppear4.SetActive(isVisible);
        objectToAppear5.SetActive(isVisible);
        objectToAppear6.SetActive(isVisible);
        Debug.Log("showmenu");
    }
}
