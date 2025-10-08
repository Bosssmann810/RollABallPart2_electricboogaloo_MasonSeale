using UnityEngine;
using UnityEngine.SceneManagement;
public class menumangaer : MonoBehaviour
{
    public GameObject controlstext;
    public GameObject quitbuttton;
    public GameObject play;
    public GameObject levelselectbutton;
    public GameObject backbutton;
    public GameObject controlsbutton;
    private int currentscene = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlstext.SetActive(false);
        backbutton.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        play.SetActive(false);
        quitbuttton.SetActive(false);
        levelselectbutton.SetActive(false);
        controlsbutton.SetActive(false);
        backbutton.SetActive(true);
        controlstext.SetActive(true);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(1);
    }
    public void back()
    {
        play.SetActive(true);
        quitbuttton.SetActive(true);
        levelselectbutton.SetActive(true);
        controlsbutton.SetActive(true);
        backbutton.SetActive(false);
        controlstext.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
