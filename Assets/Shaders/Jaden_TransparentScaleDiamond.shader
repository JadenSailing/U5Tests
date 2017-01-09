Shader "Jaden/TransparentScaleDiamond"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
		_Scale ("����",Range( 0.0 , 1.0 )) = 1
	}
	
	SubShader
	{
		LOD 150

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			Offset -1, -1
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag			
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float _Scale;
	
			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};
	
			struct v2f
			{
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};
	
			v2f o;

			v2f vert (appdata_t v)
			{
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.texcoord = v.texcoord;
				o.color = v.color;
				return o;
			}
				
			fixed4 frag (v2f IN) : COLOR
			{
				//���βü�
				fixed deltaX = (IN.texcoord.x - 0.5);
				fixed deltaY = (IN.texcoord.y - 0.5);
				deltaX = abs(deltaX);
				deltaY = abs(deltaY);
				float alpha = 1;
				_Scale = _Scale / 2;
				if(deltaX + deltaY <= _Scale)
				{
					//discard;
					alpha = 0;
				}
				if(deltaX + deltaY > 0.5)
				{
					//discard;
					alpha = 0;
				}
				IN.color.r = 0;
				IN.color.g = 0; 
				IN.color.b = 0;
				return IN.color * alpha;
			}
			ENDCG
		}
	}
}
