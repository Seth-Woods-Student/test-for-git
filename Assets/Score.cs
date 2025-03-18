using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreDisplay;
    public Animator scoreAnimator;
    public int nextlevel = 0;
    public void EndLevel()
    {
        cannon cannon = FindObjectOfType<cannon>();
        if(cannon)
        {
            int Fired = cannon.fired;
            if(Fired == 1)
            {
                print("3 starrrrr");
                scoreDisplay.text = "3 starrrrr";
                scoreAnimator.SetInteger("Stars", 3);
            }
            else if (Fired == 2) 
            {
                print("2 star");
                scoreDisplay.text = "2 star";
                scoreAnimator.SetInteger("Stars", 2);
            }
            else
            {
                print("1 star you Suck!!!!");
                scoreDisplay.text = "1 star you Suck!!!!";
                scoreAnimator.SetInteger("Stars", 1);
            }
            
            Invoke("NextLevel", 3);
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(nextlevel);
    }

}