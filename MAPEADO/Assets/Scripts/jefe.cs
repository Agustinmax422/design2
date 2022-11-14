using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe : MonoBehaviour
{
    private GameObject _player;
    //private Vector2 pos_atack;
    Transform P_player;
    private Vector3 Dist;

    private float ang_rotate;
    private float ang;

    
    
    private int angle_redir;
   
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        angle_redir = 90;
      
    }

    // Update is called once per frame
    void Update()
    {
        P_player = _player.transform;
        // pos_atack = new Vector2(P_player.position.x-this.transform.position.x, P_player.position.z-this.transform.position.z );
        Dist = new Vector3(_player.transform.position.x - this.transform.position.x, _player.transform.position.y, _player.transform.position.z - this.transform.position.z);

        ang = Mathf.Atan2(Dist.z, Dist.x);
        ang_rotate = ang * (180 / Mathf.PI) * -1 + angle_redir;
        Quaternion angle = Quaternion.Euler(0, ang_rotate, 0);
        this.transform.rotation = angle;
        /*  RaycastHit hit;
          if (Physics.Raycast(this.transform.position, Dist, out hit, 30f))
          {

              if (hit.transform.tag == "Player")
              {
              Debug.LogWarning("choque");
              }
          }*/
        //cam.transform.rotation; cam.transform.localRotation = Quaternion.AngleAxis(velocity_look.x, Vector3.up);

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
