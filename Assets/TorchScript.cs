using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        transform.position = Vector2.MoveTowards(transform.position, target, 100 * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, -10);
        } else
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
    }
}
