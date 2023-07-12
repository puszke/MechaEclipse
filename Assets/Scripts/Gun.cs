using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject muzzleFlash, groundBeam;
    public int mouseKey = 0;
    void Shoot()
    {
        GetComponent<Animator>().SetTrigger("Shoot");
        Camera.main.GetComponent<CameraShake>().shakeDuration = 0.1f;
        foreach (Transform t in transform)
        {
            if (t.transform.name == "Turret")
            {
                Debug.Log(t.name);
                GameObject newFlash = Instantiate(muzzleFlash);
                newFlash.transform.position = t.transform.position;
                newFlash.transform.rotation = Camera.main.transform.rotation;
                newFlash.transform.parent = t.transform;
                Destroy(newFlash, 2);

                RaycastHit hit;
                Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward + new Vector3(Random.Range(-PlayerStats.instance.recoil / 100, PlayerStats.instance.recoil / 100), 0, 0)), out hit, Mathf.Infinity, layerMask);
                GameObject newFlash2 = Instantiate(groundBeam);
                newFlash2.transform.position = hit.point + new Vector3(0, 2, 0);
                Destroy(newFlash2, 2);

                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyHealth>().DealDamage(PlayerStats.instance.base_damage);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(mouseKey))
        {
            Shoot();
        }
    }
}
