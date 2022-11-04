using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=10f;
    private new Rigidbody rigidbody;
    public int vidaPlayer=1;
    void Start()
    {   
        
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");   

        if(hor != 0.0f || ver != 0.0f){
            Vector3 dir = transform.forward * ver + transform.right * hor;

            rigidbody.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }
        /*if(vidaPlayer <= 0){
                Destroy(this.gameObject);
            }
    */}
    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Enemigo")){
            Destroy(this.gameObject);
        }
    }
}