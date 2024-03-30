using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerup : MonoBehaviour
{
    
    public ShooterController shooter;
    

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<ShooterController>()) {
            shooter.startInfiniteAmmo();
            Destroy(gameObject);
        }
    }

}
