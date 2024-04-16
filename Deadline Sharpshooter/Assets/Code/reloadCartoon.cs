using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadCartoon : MonoBehaviour
{
    public ShooterController shooterController; // Assign this in the Inspector
    private Animator otherAnimator;

    void Start()
    {
        otherAnimator = GetComponent<Animator>();
        print("reloadCartoonworkings");
    }
    //nothing here
    void Update()
    {
        if (shooterController != null)
        {
            // Get the current bullet count from the ShooterController
            int bullets = shooterController.GetCurrentBullets();

            // Set the Animator parameter (assuming it's an integer parameter named "BulletCount")
            otherAnimator.SetInteger("bulletnumber", bullets);
            //print(bullets);
        }
    }
}
