using UnityEngine;
using UnityEngine.SceneManagement;
public class levelselect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void lv1()
    {
        SceneManager.LoadScene(2);
    }
    public void lv2()
    {
        SceneManager.LoadScene(3);
    }
    public void lv3()
    {
        SceneManager.LoadScene(4);
    }
    public void lv4()
    {
        SceneManager.LoadScene(5);
    }
    public void lv5()
    {
        SceneManager.LoadScene(6);
    }
    public void lv6()
    {
        SceneManager.LoadScene(7);
    }
    public void lv7()
    {
        SceneManager.LoadScene(8);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
