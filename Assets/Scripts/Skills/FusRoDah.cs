using System.Collections;
using UnityEngine;

[SerializeField,CreateAssetMenu(fileName ="Ability2",menuName ="Create new rudah")]
public class PlaySoundIfRed : AAbility
{
    public string AbilityDisplayName => "Fus RuDah!";
    public override float CoolDown => 10;
    public AudioClip actionsound;
    public override IEnumerator Action(GameObject caster)
    {
        if (Ready){
            if (caster.TryGetComponent<MeshRenderer>(out MeshRenderer renderer) && renderer.material.color == Color.red){
                Debug.Log(AbilityDisplayName);
                Ready=false;
                if (actionsound != null && caster.TryGetComponent<AudioSource>(out AudioSource source)){
                    source.clip = actionsound;
                    source.Play();
                }
                yield return new WaitForSeconds(CoolDown);
                Ready = true;
            }
        }
    }
}