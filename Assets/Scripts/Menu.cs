using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject MenuButton;

    public void TogglePanel()
    {
        Panel.SetActive(!Panel.activeSelf);

        Debug.LogError("fdp");
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("AR Scene 1");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("Level3");
    }

    void Start()
    {
        if (MenuButton != null)
        {
            MenuButton.SetActive(true);
        }
    }
}