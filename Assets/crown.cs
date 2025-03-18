using UnityEngine;

public class crown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            Score score = FindObjectOfType<Score>();
            if (score) 
            {
                score.EndLevel();
            }
            Destroy(gameObject);
            print("you win");
        }
    }
}
