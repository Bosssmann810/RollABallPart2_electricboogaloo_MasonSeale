using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
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
    public GameObject backup_A;
    public GameObject backup_B;
    public GameObject backup_C;
    public TextMeshProUGUI levelText;
    public GameObject continuebutton;
    public bigguy bigguy;
    public GameObject tipText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winTextobject.SetActive(false);
        exit.SetActive(false);
        backup_A.SetActive(false);
        backup_B.SetActive(false);
        backup_C.SetActive(false);
        tipText.SetActive(false);
        SetCountText();
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        levelText.text = "Level: " + currentscene.ToString();
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
            
           
            exit.SetActive(true);
            backup_A.SetActive(true);
            backup_B.SetActive(true);
            backup_C.SetActive(true);
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
                float dashspeed = speed * 50;
                rb.AddForce(movement * dashspeed, ForceMode.Force);
            }
            else
            {
                return;
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
            Destroy(gameObject);
            winTextobject.GetComponent<TextMeshProUGUI>().text = "YOU ESCAPED! ";
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            //remove the backups
            backup_A.SetActive(false);
            backup_B.SetActive(false);
            backup_C.SetActive(false);
            continuebutton.SetActive(true);
        }
        if (other.gameObject.CompareTag("chips"))
        {
            
            other.gameObject.SetActive(false);
            count += 1;
            speed += 1;
            SetCountText();
            bigguy.mad();
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
