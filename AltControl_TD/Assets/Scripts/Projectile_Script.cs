using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Projectile_Script : MonoBehaviour
{
    private Transform _target;
    private Vector3 _lastPosition;
    public int Damage = 1;
    public float speed = 70f;
    Vector3 dir;




    public void Seek(Transform target)
    {
        _target = target;
        _lastPosition = _target.position;
    }

    private void Start()
    {
        dir = _lastPosition - transform.position;
    }

    void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        

        float distanceThisFrame = speed * Time.deltaTime;

            //if(dir.magnitude <= distanceThisFrame)
            //{
            //    HitTarget();
            //    return;
            //}

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            HitTarget();
            EnemyState TargetState = other.gameObject.GetComponent<EnemyState>();
            TargetState.HitPoints = TargetState.HitPoints - Damage;

        }
    }
    


    void HitTarget()
    {
        Debug.Log("Got em");
        Destroy(gameObject);
    }
}
