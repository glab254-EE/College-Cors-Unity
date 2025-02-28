using System.Collections;
using UnityEngine;

[SerializeField,CreateAssetMenu(fileName ="Ability3",menuName ="Create new fish")]
public class PlaySoundIfBlue : AAbility
{
    public string AbilityDisplayName => "I am just a fish!";
    public override float CoolDown => 5;
    public AudioClip actionsound;
    public override IEnumerator Action(GameObject caster)
    {
        if (Ready){
            if (caster.TryGetComponent<MeshRenderer>(out MeshRenderer renderer) && renderer.material.color == Color.blue){
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