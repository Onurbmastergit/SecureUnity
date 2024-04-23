using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    public int vidaAtual;
    public int vidaBase = 100;

    public Image LifeBar;
    private Animator animator;
    private NavMeshAgent agent;
    public bool tomouDano;
    private Rigidbody rb;

    void Start() 
    {
        vidaAtual = vidaBase;
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        vidaAtual = vidaBase;
        animator.SetInteger("Death", vidaAtual);
    }
    private void Update()
    {
        float fillAmount = (float)vidaAtual/vidaBase;
        LifeBar.fillAmount = fillAmount;
        animator.SetInteger("Death", vidaAtual);
    }
    public void ReceberDano(int dano) 
    {
        animator.SetBool("Hit", true);
        agent.enabled = false;
        tomouDano = true; 
        vidaAtual -= dano;
        VerificarMorte();
    }
    void VerificarMorte() 
    {
        if (vidaAtual <= 0) 
        {
            animator.SetBool("Hit", false);
            Destroy(rb);
            agent.enabled = false;
        }
    }
    public void Morte()
    {
        Destroy(gameObject);
    }
    public void DisableAnimation() 
    {

        animator.SetBool("Hit", false);
        tomouDano = false;
        agent.enabled = true;
        
    }
}
