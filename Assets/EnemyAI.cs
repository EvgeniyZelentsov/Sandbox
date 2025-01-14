using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {

        //var lookAt = player.transform.position;
        ////lookAt.y = transform.position.y;
        //transform.LookAt(lookAt);
        agent.SetDestination(player.position);
        //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
