using UnityEngine;
using UnityEngine.SceneManagement;

public class inputs : MonoBehaviour
{
    private bool canprogress = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if they hit the r key
        if (Input.GetKeyDown(KeyCode.R))
        {
            //reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //if they hit escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //quit the game
            Application.Quit();
        }
        
        if (canprogress == true)
        {
            //if they hit T
            if (Input.GetKeyDown(KeyCode.T))
            {
                int currentscene = SceneManager.GetActiveScene().buildIndex;
                //skip to next level
                SceneManager.LoadScene(currentscene + 1);
            }
        }
        //if they hit Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            int currentscene = SceneManager.GetActiveScene().buildIndex;
            //load previous level
            SceneManager.LoadScene(currentscene - 1);
        }
    }
    public void Continue()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentscene + 1);
    }
    
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
