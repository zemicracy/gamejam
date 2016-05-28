using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Animator anim;
    public Vector2 speed = new Vector2(0.5f, 0.5f);


    float tempo = 0.1f;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Move(tempo);
        Action();

        if (Input.GetKey("left"))
        {
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey("right"))
        {
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey("up"))
        {
            anim.SetBool("Walk", true);
        }
        else if(Input.GetKey("down")){
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
	}

    void Move(float tempo)
    {
        Vector2 Position = transform.position;

        if (Input.GetKey("right"))
        {
            Position.x += speed.x * tempo;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (Input.GetKey("left"))
       {
            Position.x -= speed.x * tempo;
            transform.rotation =new Quaternion(0,-180,0,0);
        }
<<<<<<< HEAD
        if (Input.GetKey("up"))
=======
        else if (Input.GetKey("up"))
>>>>>>> 8e25cc8b0d87b2ec7e7452a3167d088adb99f128
        {
            Position.y += speed.x * tempo;
            transform.rotation = transform.rotation;
        }
<<<<<<< HEAD
        if (Input.GetKey("down"))
=======
        else if (Input.GetKey("down"))
>>>>>>> 8e25cc8b0d87b2ec7e7452a3167d088adb99f128
        {
            Position.y -= speed.x * tempo;
            transform.rotation = transform.rotation;
        }
        transform.position = Position;
        transform.LookAt(transform.position); 
    }

    void Action()
    {
<<<<<<< HEAD

=======
        
    }

    void OnTriggerStay2D(Collider2D colider)
    {

        if (colider.gameObject.tag == "kazan")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("aaaa");
            }
        }
>>>>>>> 8e25cc8b0d87b2ec7e7452a3167d088adb99f128
    }
}
