using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class bigguy : MonoBehaviour
{
    public Transform chips;
    public playercontroller playercontroller;
    public Transform player;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(chips.position);
    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("chips"))
        { 
            mad();
            if(player != null)
            {
                agent = GetComponent<NavMeshAgent>();
                agent.SetDestination(player.position);
            }

            other.gameObject.SetActive(false);
           
        }
       
    }
    public void sadness()
    {   
        sad();
        if (player != null)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(player.position);
        }
    }
    private void mad()
    {
        agent.speed = 7.0f;
    }
    private void sad()
    {
        agent.speed = 0.0f;
    }
}