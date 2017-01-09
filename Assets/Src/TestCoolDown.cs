using UnityEngine;
using System.Collections;

/// <summary>
/// by Jaden 2016-10-22 15:47:25
/// CoolDown效果测试
/// Tips:
/// 第一种使用自定义shader实现 从内向外的的cd效果
/// 第二种使用NGUI BaseSprite的Filled类型 Radial360
/// 另外发现NGUI的一个bug：当UITexture使用自定义Shader时必须同时指定Material不能只指定Shader，否则会导致不同Shader合批。
/// 原因是UIPanel.FindDrawCall方法里添加UIWidget时查询DC时只判断了BaseMaterial是否相同。这也是本例中第一个指定材质的原因。
/// FindDrawCall会在UIWidget添加到Panel时调用，包括Active从false变为true，FillAmount从0增大等情况
/// </summary>

public class TestCoolDown : MonoBehaviour {

    public UITexture CoolDownMask;

    public UITexture CoolDownMask2;

    public UITexture CoolDownMask3;

    private float _scale = 0.0f;

	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 30;
	}
	
	// Update is called once per frame
	void Update () {
        _scale += 0.005f;
        if(_scale > 1.0f)
        {
            _scale = 0.0f;
        }
	    if(CoolDownMask != null)
        {
            if(CoolDownMask.drawCall != null)
            {
                if(CoolDownMask.drawCall.dynamicMaterial != null)
                {
                    CoolDownMask.drawCall.dynamicMaterial.SetFloat("_Scale", _scale);
                }
            }
        }

        if (CoolDownMask3 != null)
        {
            if (CoolDownMask3.drawCall != null)
            {
                if (CoolDownMask3.drawCall.dynamicMaterial != null)
                {
                    CoolDownMask3.drawCall.dynamicMaterial.SetFloat("_Scale", _scale);
                }
            }
        }

        if (CoolDownMask2 != null)
        {
            CoolDownMask2.fillAmount = 1 - _scale;
        }
	}
}
