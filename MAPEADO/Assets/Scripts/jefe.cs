using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe : MonoBehaviour
{
    private GameObject _player;
    private Vector2 pos_atack;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Transform P_player = _player.transform;
        pos_atack = new Vector2(P_player.position.x-this.transform.position.x, P_player.position.z-this.transform.position.z );

//        Debug.Log(pos_atack);
    }
    private void OnBecameInvisible()
    {
        //atacar despues de 6 seguindos
    }
    private void OnBecameVisible()
    {
        //esperar para cambiar de posicion
    }

    private void _Move()
    {
        
    }
}
