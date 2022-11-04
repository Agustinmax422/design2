using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movEnemigo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] puntos;
    public int vidaEnemigo=1;
    public int danio=1;
    public GameObject Jugador;
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
        Collider[] obstaculos = Physics.OverlapSphere(this.transform.position, 4f);
        foreach (var hit in obstaculos){
            if(hit.gameObject.tag == "Player"){
                agent.SetDestination(hit.gameObject.transform.position);
            }
        }
    }
    private void OnTriggerEnter(Collider collision) {
        if(collision.tag=="Player"){
            Jugador.GetComponent<Player>().vidaPlayer-= danio;
        }
    }
}
