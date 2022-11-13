using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movEnemigo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] puntos;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(puntos[Random.Range(0,puntos.Length)].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.1){
            agent.SetDestination(puntos[Random.Range(0, puntos.Length)].position);
        }
        Collider[] objeto = Physics.OverlapSphere(this.transform.position,4f);
        foreach(var hit in objeto)
        {
            if(hit.gameObject.tag == "Player"){
                agent.SetDestination(hit.gameObject.transform.position);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 16f);
    }
}