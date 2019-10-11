// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Shader Forge/XRayPlayer" {
    Properties {
        _MainTex ("MainTexture", 2D) = "white" {}
		_ShadeColor ("Shade Color", Color) = (0.7, 0.3, 0.6, 1)
		_alpha("Alpha", Range(0,1)) = 1
    }
    SubShader {
        Tags {
            "Queue" = "AlphaTest+3" "RenderType"="TransparentCutout"
        }
		  //先后关系和深度测试很重要 第一个Pass的深度测试是Z值远的渲染  被遮挡的反而渲染 深度测试选出的是大于参考值的像素  所以遮挡反而显示
		//第二个Pass深度测试是被遮挡了 墙的Z值小于人  所以人被遮挡  
		//因为在没有遮挡关系的情况下  后一次pass覆盖了前一个pass  所以没事  有遮挡关系时候  第一个pass照样渲染  但第二个pass被遮挡部分深度测试不过  所以不渲染
		//先绘制遮罩显示的部分  
		Pass
		{
		   Blend One OneMinusSrcColor 
		   Cull Off   
           Lighting Off   
		   ZTest Greater 
		   ZWrite Off
		   CGPROGRAM
		   #pragma vertex vert
		   #pragma fragment frag
		   #pragma fragmentoption ARB_precision_hint_fastest   
   
		   float4 _ShadeColor;
		   sampler2D _MainTex;
		   uniform fixed _alpha;
		   struct appdata
		   {
				float4 vertex : POSITION;
				float3 _normal : NORMAL;
		   };

		   struct v2f
		   {
				float4 pos : POSITION; // 视口位置
				float2 vertex : TEXCOORD0;  // 贴图纹理坐标
		   };

		   // 操作顶点  
		   v2f vert(appdata v)
		   {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				half2 offset;
				float3 Costomnor = mul((float3x3)UNITY_MATRIX_IT_MV,v._normal); 
				offset.x = Costomnor.x;  
				offset.y = Costomnor.y; 
				//改变法线的值得范围
				o.vertex =offset*0.7+0.7;// v.vertex.xy*v.vertex.yz;//
				return o;
		   }
		   float4 frag(v2f i) : COLOR
		   {
				return tex2D(_MainTex,i.vertex)*_alpha*_ShadeColor;				
		   }
		   ENDCG
		}
        
    }
    FallBack "Diffuse"
    //CustomEditor "ShaderForgeMaterialInspector"
}
