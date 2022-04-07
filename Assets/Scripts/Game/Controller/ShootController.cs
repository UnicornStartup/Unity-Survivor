using UnityEngine;

public class ShootController : MonoBehaviour
{

    public GameObject bulletPrefav;
    public Stats stats;

    void Start()
    {
        stats = GetComponent<Stats>();
    }

    void Update()
    {

    }

}
