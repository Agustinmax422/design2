using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movEnemigo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] puntos;

    //[SerializeField] private float vida;
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
   /* public void TomarDanio(float danio)
    {
        vida -= danio;
        if(vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
       Destroy(this.gameObject); 
    }*/
}
