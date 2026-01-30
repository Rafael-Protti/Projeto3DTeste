using StarterAssets;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{

    Animator animator;
    StarterAssetsInputs inputs;

    int comboIndex = 0;
    bool canAttack = true;
    float comboTime = 1;
    float comboTimeDecurred = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        inputs = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {

        if (inputs.attack && canAttack)
        {
            comboIndex++;
            animator.SetInteger("Combo", comboIndex);
            canAttack = false;
            comboTimeDecurred = 0;
        }

        if (canAttack)
        {
            comboTimeDecurred += Time.deltaTime;
            if (comboTimeDecurred > comboTime)
            {
                ResetCombo();
            }
        }
    }

    void ResetCombo()
    {
        comboIndex = 0;
        animator.SetInteger("Combo", comboIndex);
    }

    public void OnAttackFisish()
    {
        canAttack = true;


        if (comboIndex >= 3)
        {
            ResetCombo();
        }
    }
}
