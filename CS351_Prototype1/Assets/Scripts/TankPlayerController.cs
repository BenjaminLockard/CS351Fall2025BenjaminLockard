/*Benjamin Lockard
 *Prototype #1 (Follow Along)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    // try setting to 8 in inspect - holds move speed
    public float mSpeed;
    // try setting to 100 in inspect - holds turn speed
    public float tSpeed;

    public float verticalInput;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * Time.deltaTime * mSpeed * verticalInput);

        if (verticalInput <0)
        {
            transform.Rotate(Vector3.back, Time.deltaTime * -tSpeed * horizontalInput);
        } else
        {
            transform.Rotate(Vector3.back, Time.deltaTime * tSpeed * horizontalInput);
        }


        //transform.Rotate(Vector3.back, Time.deltaTime * tSpeed * horizontalInput);



    }
}
