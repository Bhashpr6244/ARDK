// Copyright 2022 Niantic, Inc. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Niantic.ARDK.AR.Anchors;

namespace Niantic.ARDK.Extensions {
  [ExecuteInEditMode]
  public class PlanefindingGrid : MonoBehaviour {

    [SerializeField]
    private Renderer _renderer = null;

    [SerializeField]
    private MaterialPropertyBlock propBlock = null;

    [SerializeField]
    private float textureScale = 0.0f;
      
    [SerializeField]
    public IARPlaneAnchor tempAnchor;
    public Vector3 prevscale; 


        private void Awake() {

         propBlock = new MaterialPropertyBlock();

      // Get the current value of the material properties in the renderer.
      _renderer.GetPropertyBlock(propBlock);

    }
        IEnumerator Start()
        {
           

            if (tempAnchor.Alignment.ToString().Equals("Horizontal"))
            {

                gameObject.transform.localScale = Vector3.one;
                gameObject.transform.GetChild(0).transform.localScale = new Vector3(0.08f, 2f, 0.08f);
                yield return new WaitForSeconds(0.5f);
                gameObject.transform.localScale = tempAnchor.Extent;
                gameObject.transform.GetChild(0).transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                //Destroy(gameObject.transform.GetChild(0).gameObject.GetComponent<Collider_mesh>());

            }
           
        }



    private void Update() {

            if (prevscale != null)
            {
                transform.localScale = prevscale;
            }
         if (transform.hasChanged) {
        // Assign our new value.
        var targetVector = new Vector4(
          transform.localScale.x,
          transform.localScale.z,
          -transform.localScale.x * 0.5f,
          -transform.localScale.z * 0.5f);

         propBlock.SetVector("_MainTex_ST",targetVector * textureScale);
        _renderer.SetPropertyBlock(propBlock);

        transform.hasChanged = false;

      }
    }




  }
}
