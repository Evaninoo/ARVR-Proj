using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject Panel;

    public void TogglePanel()
    {
       Panel.SetActive(!Panel.activeSelf);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
