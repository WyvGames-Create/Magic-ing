using UnityEngine;

public class BirbScript : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true){
            myrigidbody.linearVelocity = Vector2.up * 10;
        }
    }
}
