using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Hello menu " + menuCanvas.enabled);
            if (menuCanvas.enabled == true)
            {
                menuCanvas.enabled = false;
            }
            else 
            {
                menuCanvas.enabled = true;
            }
        }
    }
}
