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
		  //�Ⱥ��ϵ����Ȳ��Ժ���Ҫ ��һ��Pass����Ȳ�����ZֵԶ����Ⱦ  ���ڵ��ķ�����Ⱦ ��Ȳ���ѡ�����Ǵ��ڲο�ֵ������  �����ڵ�������ʾ
		//�ڶ���Pass��Ȳ����Ǳ��ڵ��� ǽ��ZֵС����  �����˱��ڵ�  
		//��Ϊ��û���ڵ���ϵ�������  ��һ��pass������ǰһ��pass  ����û��  ���ڵ���ϵʱ��  ��һ��pass������Ⱦ  ���ڶ���pass���ڵ�������Ȳ��Բ���  ���Բ���Ⱦ
		//�Ȼ���������ʾ�Ĳ���  
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
				float4 pos : POSITION; // �ӿ�λ��
				float2 vertex : TEXCOORD0;  // ��ͼ��������
		   };

		   // ��������  
		   v2f vert(appdata v)
		   {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				half2 offset;
				float3 Costomnor = mul((float3x3)UNITY_MATRIX_IT_MV,v._normal); 
				offset.x = Costomnor.x;  
				offset.y = Costomnor.y; 
				//�ı䷨�ߵ�ֵ�÷�Χ
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
