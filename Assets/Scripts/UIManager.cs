using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsPanel;

    public void ShowMainMenu()
    {
        creditsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ShowCredits()
{
    mainMenu.SetActive(false);
    creditsPanel.SetActive(true);
}

}
