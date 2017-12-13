using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverse : MonoBehaviour {

    public GameMaster gm;
    public Animator anim;

    private void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        anim = gameObject.GetComponent<Animator>();

    }

    private void Update()
    {
        anim.SetBool("isReversed", gm.inverseActive);
        anim.SetFloat("Countdown", gm.inverseCountdown);
        anim.SetFloat("Duration", gm.inverseDuration);
    }
}
