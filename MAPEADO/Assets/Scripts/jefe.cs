using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe : MonoBehaviour
{
    private GameObject _player;
    //private Vector2 pos_atack;
    Transform P_player;
    //private Vector3 Dist;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        P_player = _player.transform;
        // pos_atack = new Vector2(P_player.position.x-this.transform.position.x, P_player.position.z-this.transform.position.z );
       /* Dist = new Vector3(_player.transform.position.x - this.transform.position.x, _player.transform.position.y, _player.transform.position.z - this.transform.position.z);
  
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, Dist, out hit, 30f))
            {

                if (hit.transform.tag == "Player")
                {
                Debug.LogWarning("choque");
                }
            }*/
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            _Move();
        }
    }

    private void _Move()
    {
        this.transform.position = new Vector3((2* P_player.position.x)-this.transform.position.x, this.transform.position.y, (2*P_player.position.z )- this.transform.position.z);
        
    }
}
