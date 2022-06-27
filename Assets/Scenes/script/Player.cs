using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed= 5;
    private Rigidbody2D rb;
     public float jump=5;
     private bool isgrounded=false;
     private Animator anim;
     private Vector3 rotation;
     private Sowrdmanagment1 m;
     public GameObject panel;
     public GameObject Camera;
     
     
    void Start()
    {
        
        rb= GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        rotation=transform.eulerAngles;
        m=GameObject.FindGameObjectWithTag("Text").GetComponent<Sowrdmanagment1>();
        
      
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        if(direction != 0)
        {
            anim.SetBool("IsRunning" , true);
        }
        else
        {
            anim.SetBool("IsRunning" , false);
        }
        if(direction < 0)
        {
            transform.eulerAngles=rotation- new Vector3(0,180,0);
            transform.Translate(Vector2.right*speed*-direction* Time.deltaTime);

        }
        if(direction > 0)
        {
             transform.eulerAngles=rotation;
             transform.Translate(Vector2.right*speed*direction* Time.deltaTime);
        }

        if(isgrounded == false)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }
        
        

        if(Input.GetKeyDown(KeyCode.Space) && isgrounded ){
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
             isgrounded=false;
           
        }

        Camera.transform.position = new Vector3(transform.position.x ,0,-10);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground"){
            isgrounded=true;
        }

        if(collision.gameObject.tag == "Enemy" )
        {
            
            panel.SetActive(true);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("gameover");
            
        }
        
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "sowrd")
        {
            m.Addmoney();
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("sword");
        }
        if(other.gameObject.tag == "box")
        {
            panel.SetActive(true);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("gameover");
        
        }

        if(other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        


    }
}
