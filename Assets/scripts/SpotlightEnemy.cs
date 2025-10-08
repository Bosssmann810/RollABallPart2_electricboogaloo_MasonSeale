using UnityEngine;
using UnityEngine.AI;

public class SpotlightEnemy : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    public bool spotted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        spotted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spotted == true)
        {
            if (player != null)
            {
                navMeshAgent.SetDestination(player.position);
            }
        }
    }
    public void allerted()
    {
        spotted = true;
        

    }
}
