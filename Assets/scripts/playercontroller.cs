using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playercontroller : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY; 
    private int count;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextobject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winTextobject.SetActive(false);
        SetCountText();
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
        if (count >= 12)
        {
            winTextobject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); 
        rb.AddForce(movement * speed);
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextobject.SetActive(true);
            winTextobject.GetComponent<TextMeshProUGUI>().text = "You Lose"; 
        }
    }
}
