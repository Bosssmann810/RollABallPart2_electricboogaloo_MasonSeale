using UnityEngine;
using UnityEngine.SceneManagement;
public class menumangaer : MonoBehaviour
{
    private int currentscene = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(currentscene + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
