using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        addComponents();
    }

    // Update is called once per frame
    
    public void addComponents()
    {
        gameObject.AddComponent<PlayerSpawner>();
    }
}
