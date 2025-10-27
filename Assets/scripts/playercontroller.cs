using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class playercontroller : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY; 
    private int count;
    public float speed = 0;
    public int levelcount;
    public bool canDash;
    public TextMeshProUGUI countText;
    public GameObject winTextobject;
    public GameObject exit;
    public TextMeshProUGUI levelText;
    public GameObject continuebutton;
    public GameObject menubutton;
    public bigguy bigguy;
    public GameObject tipText;
    public SpotlightEnemy SpotlightEnemy;
    public GameObject[] backup;
    public TextMeshProUGUI versiontext;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        versiontext.text = "V1.12";
        rb = GetComponent<Rigidbody>();
        count = 0;
        winTextobject.SetActive(false);
        exit.SetActive(false);
        
        foreach (GameObject enemy in backup)
        {
            enemy.SetActive(false);
        }
        tipText.SetActive(false);
        menubutton.SetActive(false);
        SetCountText();
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "Level: " + (currentscene - 1).ToString();
        continuebutton.SetActive(false);
    }


    void OnMove(InputValue movmentvalue)
    {
        Vector2 movementvector = movmentvalue.Get<Vector2>();
        movementX = movementvector.x;
        movementY = movementvector.y;
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        //when they get all the epickups start the escape
        if (count >= levelcount)
        {
            winTextobject.SetActive(true);
            
           foreach (GameObject enemy in backup)
            {
                enemy.SetActive(true);
            }
            exit.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); 
        rb.AddForce(movement * speed);
        

    
    }

    private void Update()
    {        
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canDash == true) //only if they can dash
            {
                float dashspeed = speed * 30;
                rb.AddForce(movement * dashspeed, ForceMode.Force);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        { 
            other.gameObject.SetActive(false);
            count += 1;
            //every pickup increases speed
            speed += 1;
            SetCountText();
        }
        //if the player hits the barrier act like they lost but with diffrent text        
        if (other.gameObject.CompareTag("deathzone"))
        {
            Destroy(gameObject);
            winTextobject.SetActive(true);
            winTextobject.GetComponent<TextMeshProUGUI>().text = "Out Of Bounds";
        }
        //if the player gets to the exit end the game
        if (other.gameObject.CompareTag("exit"))
        {
            
            winTextobject.GetComponent<TextMeshProUGUI>().text = "YOU ESCAPED! ";
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            foreach(GameObject enemy in backup)
            {
                Destroy(enemy);
            }

            continuebutton.SetActive(true);
            menubutton.SetActive(true);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("chips"))
        {
            
            other.gameObject.SetActive(false);
            count += 1;
            speed += 1;
            SetCountText();
            bigguy.mad();
        }
        if (other.gameObject.CompareTag("spotlight"))
        {
            SpotlightEnemy.allerted();
        }
        if (other.gameObject.CompareTag("upgrade1"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            speed += 1;
            SetCountText();
            canDash = true;
            tipText.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextobject.SetActive(true);
            winTextobject.GetComponent<TextMeshProUGUI>().text = "You Lose"; 
        }
        //same thing diffrent tag
        if (collision.gameObject.CompareTag("WAVE2"))
        {
            Destroy(gameObject);
            winTextobject.SetActive(true);
            winTextobject.GetComponent<TextMeshProUGUI>().text = "You Lose";
        }
    }

}
