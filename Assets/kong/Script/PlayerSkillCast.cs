using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerSkillCast : MonoBehaviour
{
    [SerializeField] private GameObject[] SkillSlot;
    [SerializeField] private TMP_Text SkillText;
    public GameObject player;
    private GameObject curSkill;
    private int state = 0;
    void Start(){
        curSkill = SkillSlot[state];
        // player = GetComponentInParent<GameObject>();
    }
    void Update(){
        curSkill = SkillSlot[state];
        SkillText.text = state.ToString();
    }
    public void PressRightMouse(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed && SkillSlot.Length == 3 && curSkill){
            if(curSkill.name == "HealInstance"){
                curSkill.GetComponent<HealInstance>().Activate(player);
            }
            else if(curSkill.name == "FireBall"){
                curSkill.GetComponent<FireBall>().Activate(player,this.transform);
            }
        }
    }

    public void PressQ(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed && SkillSlot.Length == 3){
            state = (state + 1) % 3;
            Debug.Log(state);
            curSkill = SkillSlot[state];
        }
    }
}
