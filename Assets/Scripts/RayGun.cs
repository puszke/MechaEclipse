using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public class RayGun : MonoBehaviour
{
    public GameObject ray;
    public LayerMask layerMask;
    [SerializeField] private Transform turret;
    [SerializeField] private Image rayBar;
    public float loaded = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Shoot()
    {
         GetComponent<Animator>().SetTrigger("ShootPower");
        Camera.main.GetComponent<CameraShake>().shakeDuration = 0.2f;
        loaded = 0;
        RaycastHit hit; 
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask);

        GameObject newRay = Instantiate(ray);
        Vector3[] l = new Vector3[2];

        l[0] = turret.transform.position;
        l[1] = hit.point;

        newRay.GetComponent<LineRenderer>().SetPositions(l);

        if (hit.transform.tag == "Enemy")
            hit.transform.GetComponent<EnemyHealth>().DealDamage(PlayerStats.instance.base_damage * 7f);
        Destroy(newRay,5);
    }
    // Update is called once per frame
    void Update()
    {
        float loadAmount = loaded / PlayerStats.instance.ray_load_time;
        rayBar.fillAmount = loadAmount;
        if(Input.GetMouseButton(1))
        {
            loaded += 1*Time.deltaTime;
        }
        else
        {
            if (loaded > PlayerStats.instance.ray_load_time)
                Shoot();
            loaded = 0; 
        }
    }
}
