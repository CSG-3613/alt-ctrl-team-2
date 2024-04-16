using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower_Script : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    public float fireCooldown = 0f;
    

    [Header("Setup")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform _target;
    private bool _isActive = false;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            _target = nearestEnemy.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_target == null) { return;}
        if(this.transform.position.y > -5) { _isActive = true; }
        else { _isActive = false; }

        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCooldown <= 0f && _isActive)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;

    }

    void Shoot()
    {
        Debug.Log("I'm shooting");
        GameObject bulletObject = (GameObject)Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        Projectile_Script bulletScript = bulletObject.GetComponent<Projectile_Script>();

        if (bulletScript != null) { bulletScript.Seek(_target); }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
