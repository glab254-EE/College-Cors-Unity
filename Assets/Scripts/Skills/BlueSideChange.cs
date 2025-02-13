using System.Collections;
using UnityEngine;

[SerializeField,CreateAssetMenu(fileName ="Ability1",menuName ="Create new wololo")]
public class Wololo : AAbility
{
    public string AbilityDisplayName => "Team Changing Wololo";
    public float CoolDown => 5.5f;
    public AudioClip actionsound;
    public override IEnumerator Action(GameObject caster)
    {
        if (Ready){
            if (caster.TryGetComponent<MeshRenderer>(out MeshRenderer renderer)){
                Debug.Log(AbilityDisplayName);
                Ready=false;
                if (actionsound != null && caster.TryGetComponent<AudioSource>(out AudioSource source)){
                    source.clip = actionsound;
                    source.Play();
                    yield return new WaitForSeconds(source.clip.length);
                }
                if (renderer.material.color == Color.blue ){
                    renderer.material.color= Color.red;
                } else {
                    renderer.material.color=Color.blue;
                }
                yield return new WaitForSeconds(CoolDown);
                Ready = true;
            }
        }
    }
}