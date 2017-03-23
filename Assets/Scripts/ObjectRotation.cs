using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

    /// <summary>
    /// Alberto Wong.
    /// Coin Rotation script.
    /// </summary>
 

    // Update is called once per frame
    void Update ()
    {
        RotateCoin(); //Calls the function to rotate coin.
    }
      
    void RotateCoin()
    {
        transform.Rotate(8, 0, 0 * Time.deltaTime); //rotates coin over time. The first value inside the parenthesis determines the speed of the rotation.
    }    

}
