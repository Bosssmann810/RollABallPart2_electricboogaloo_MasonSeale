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
            if (Input.GetKeyDown(KeyCode.T))
            {
                int currentscene = SceneManager.GetActiveScene().buildIndex;

                SceneManager.LoadScene(currentscene + 1);
            }
        }
    }
    public void Continue()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentscene + 1);
    }
}
