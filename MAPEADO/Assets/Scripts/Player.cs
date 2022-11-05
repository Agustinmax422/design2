using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=10f;
    private new Rigidbody rigidbody;
    public int vidaPlayer=1;


   // [SerializeField] private Transform controladorGolpe;
   // [SerializeField] private float radioGolpe;
   // [SerializeField] private float danioGolpe;

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
    */
/*    {
        Golpe();
    }*/
}
    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Enemigo")){
            Destroy(this.gameObject);
        }
    }
    /*private void Golpe(){
        Collider[] objeto = Physics.OverlapSphere(controladorGolpe.position, radioGolpe);

        foreach(Collider colisionador in objeto)
        {
            if(colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<movEnemigo>().TomarDanio(danioGolpe);
            }
        }
    }
    */
}