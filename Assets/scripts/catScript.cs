using UnityEngine;

public class catScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("fish")){
            Debug.Log("win");
            GameManager.instance.Win();
        }
        else if(col.gameObject.CompareTag("liquid")){
            Debug.Log("lose");
            GameManager.instance.Lose();
            Destroy(gameObject);
        }
    }
}
