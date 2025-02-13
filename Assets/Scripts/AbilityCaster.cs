using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCaster : MonoBehaviour
{
    [SerializeField] private List<ButtonAndAbility> buttonforability;
    private void UpdateButtons(){
        foreach(ButtonAndAbility values in buttonforability){
            if (!values.ability.Ready){
                values.button.interactable = false;
            } else {
                values.button.interactable = true;
            }
        }
    }
    void Start(){
        foreach(ButtonAndAbility values in buttonforability){
            if (values.button != null && values.button.interactable){
                values.ability.Ready = true;
                values.button.onClick.AddListener(()=>{
                    StartCoroutine(values.ability.Action(gameObject));
                });
            }
        }
        UpdateButtons();
    }
    private void FixedUpdate(){
        UpdateButtons();
    }
}
[Serializable] 
public class ButtonAndAbility
{
    public Button button;
    public AAbility ability;
}