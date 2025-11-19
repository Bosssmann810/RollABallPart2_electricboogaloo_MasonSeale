using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class gallery : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemytext;
    public GameObject Bigguy;
    public GameObject Bigguytext;
    public GameObject littlefella;
    public GameObject littlefellatext;
    public GameObject Ghost;
    public GameObject Ghosttext;
    public GameObject spotlight;
    public GameObject spotlighttext;
    public GameObject thebehemoth;
    public GameObject behemothtext;
    static int currentpage = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentpage == 0)
        {
            Enemy.SetActive(true);
            Enemytext.SetActive(true);
            Bigguy.SetActive(false);
            Bigguytext.SetActive(false);
            littlefella.SetActive(false);
            littlefellatext.SetActive(false);
            Ghost.SetActive(false);
            Ghosttext.SetActive(false);
            spotlight.SetActive(false);
            spotlighttext.SetActive(false);
            thebehemoth.SetActive(false);
            behemothtext.SetActive(false);
            Debug.Log("enemy");
        }
        if (currentpage == 1)
        {
            Enemy.SetActive(false);
            Enemytext.SetActive(false);
            Bigguy.SetActive(true);
            Bigguytext.SetActive(true);
            littlefella.SetActive(false);
            littlefellatext.SetActive(false);
            Ghost.SetActive(false);
            Ghosttext.SetActive(false);
            spotlight.SetActive(false);
            spotlighttext.SetActive(false);
            thebehemoth.SetActive(false);
            behemothtext.SetActive(false);
            Debug.Log("bigguy");
        }
        if (currentpage == 2)
        {
            Enemy.SetActive(false);
            Enemytext.SetActive(false);
            Bigguy.SetActive(false);
            Bigguytext.SetActive(false);
            littlefella.SetActive(true);
            littlefellatext.SetActive(true);
            Ghost.SetActive(false);
            Ghosttext.SetActive(false);
            spotlight.SetActive(false);
            spotlighttext.SetActive(false);
            thebehemoth.SetActive(false);
            behemothtext.SetActive(false);
            Debug.Log("little fella");
        }
        if (currentpage == 3)
        {
            Enemy.SetActive(false);
            Enemytext.SetActive(false);
            Bigguy.SetActive(false);
            Bigguytext.SetActive(false);
            littlefella.SetActive(false);
            littlefellatext.SetActive(false);
            Ghost.SetActive(true);
            Ghosttext.SetActive(true);
            spotlight.SetActive(false);
            spotlighttext.SetActive(false);
            thebehemoth.SetActive(false);
            behemothtext.SetActive(false);
            Debug.Log("ghost");
        }
        if (currentpage == 4)
        {
            Enemy.SetActive(false);
            Enemytext.SetActive(false);
            Bigguy.SetActive(false);
            Bigguytext.SetActive(false);
            littlefella.SetActive(false);
            littlefellatext.SetActive(false);
            Ghost.SetActive(false);
            Ghosttext.SetActive(false);
            spotlight.SetActive(true);
            spotlighttext.SetActive(true);
            thebehemoth.SetActive(false);
            behemothtext.SetActive(false);
            Debug.Log("spotlight");
        }
        if (currentpage == 5)
        {
            Enemy.SetActive(false);
            Enemytext.SetActive(false);
            Bigguy.SetActive(false);
            Bigguytext.SetActive(false);
            littlefella.SetActive(false);
            littlefellatext.SetActive(false);
            Ghost.SetActive(false);
            Ghosttext.SetActive(false);
            spotlight.SetActive(false);
            spotlighttext.SetActive(false);
            thebehemoth.SetActive(true);
            behemothtext.SetActive(true);
            Debug.Log("behemoth");

        }
    }
    public void forward()
    {
        currentpage += 1;
        if (currentpage == 6)
        {
            currentpage = 0;
        }
    }
    public void backwards()
    {
        currentpage -= 1;
        if (currentpage == -1)
        {
            currentpage = 6;
        }
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
