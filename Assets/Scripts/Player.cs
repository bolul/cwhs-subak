using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject spawnObject;
    GameObject spawned;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, 4, 0);

        if (Input.GetMouseButtonDown(0)) {
		spawned = Instantiate(spawnObject, new Vector3(mousePos.x, 4, 0), Quaternion.identity);
	} else if (Input.GetMouseButtonUp(0)) {
		spawned.GetComponent<Rigidbody2D>().gravityScale = 3;
	}
    
    }

}
