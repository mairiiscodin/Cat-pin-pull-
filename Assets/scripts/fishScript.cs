using UnityEngine;

public class fishScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("liquid")){
            Debug.Log("lose");
            GameManager.instance.Lose();
            Destroy(gameObject);
        }
    }
}
