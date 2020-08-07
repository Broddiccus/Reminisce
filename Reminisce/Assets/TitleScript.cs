using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScript : MonoBehaviour
{
    public GameObject Title;
    public GameObject Credits;
    public string theFirstOne;

    public void GameStart()
    {
        SceneManager.LoadScene(theFirstOne);
    }
    public void CreditSet()
    {
        Title.SetActive(false);
        Credits.SetActive(true);
    }
    public void TitleSet()
    {
        Title.SetActive(true);
        Credits.SetActive(false);
    }
    public void Leave()
    {
        Application.Quit();
    }
}
