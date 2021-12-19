using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleEffect : MonoBehaviour
{
    #region Variables
    public float duration;
    public ParticleSystem ps;
    private IEnumerator coroutine;
    public ParticleSystem.Burst burst = new ParticleSystem.Burst(0, 20, 20, 0, 0);
    #endregion

    private void Start()
    {
        coroutine = Wait(.01f * Time.deltaTime);
    }

    public void FuckOff()
    {
        ps = GetComponent<ParticleSystem>();
        var emission = ps.emission;
        emission.SetBursts(new ParticleSystem.Burst[] { burst });
        StartCoroutine(coroutine);
        
        gameObject.transform.parent = null;
        Destroy(gameObject, duration);
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime * Time.deltaTime);
        ps.Stop();
    }

}
