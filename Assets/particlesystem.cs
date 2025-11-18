using UnityEngine;

public class particlesystem : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem thing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        if(player == null)
        {
            thing.Play();
            Destroy(this, 0.3f);
        }
        else
        {
            transform.position = player.transform.position;
        }
            
   
    }
}
