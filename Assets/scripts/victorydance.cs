using UnityEngine;

public class victorydance : MonoBehaviour
{
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            transform.Rotate(new Vector3(100, 200, 300) * Time.deltaTime);
        }
    }
}
