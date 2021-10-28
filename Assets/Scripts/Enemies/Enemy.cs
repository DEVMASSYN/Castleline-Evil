using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Sprite deadBody;
    public int maxHealth;
    float health;

    EnemyStates es;
    NavMeshAgent nma;
    SpriteRenderer sr;
    BoxCollider bc;
    GameObject vision;
    DynamicBillboardChange dbc;
    Animator anim;

    private void Start()
    {
        health = maxHealth;
        es = GetComponent<EnemyStates>();
        nma = GetComponent<NavMeshAgent>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider>();
        dbc = GetComponent<DynamicBillboardChange>();
        vision = transform.Find("Vision").gameObject;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            es.enabled = false;
            nma.enabled = false;
            dbc.enabled = false;
            anim.enabled = false;
            anim.Rebind();
            sr.sprite = deadBody;
            bc.center = new Vector3(0, -0.8f, 0);
            bc.size = new Vector3(1.05f, 0.43f, 0.2f);
            vision.SetActive(false);
        }
    }

    void AddDamage(float damage)
    {
        health -= damage;
    }
}