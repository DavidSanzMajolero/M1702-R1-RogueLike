using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private Transform particleSpawnPoint;
    [SerializeField] private float attackCooldown = 0.1f; 

    private bool isAttacking = false;
    private float nextAttackTime = 0f;

    private void Update()
    {
        MouseFollowWithOffset();

        if (Input.GetMouseButton(0)) 
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    public void Attack()
    {
        GameObject particles = Instantiate(particlePrefab, particleSpawnPoint.position, particleSpawnPoint.rotation);
        particles.transform.SetParent(null);  
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = worldMousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
