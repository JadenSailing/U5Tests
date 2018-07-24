Shader "Jaden/ShaderSin"
{
	Properties
	{
		_MainTex("Base (RGB), Alpha (A)", 2D) = "black" {}
	}

	SubShader
	{
		LOD 200

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
			Fog{ Mode Off }
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag			
	#include "UnityCG.cginc"

			sampler2D _MainTex;
		float4 _MainTex_ST;

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

		v2f vert(appdata_t v)
		{
			o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
			o.texcoord = v.texcoord;
			o.color = v.color;
			return o;
		}

		fixed4 frag(v2f IN) : COLOR
		{
			half2 uv = IN.texcoord;
			uv.x = uv.x + sin(_Time * 200 + uv.x * 20) / 200;
			uv.y = uv.y + cos(_Time * 200 + uv.y * 20) / 200;
			return tex2D(_MainTex, uv) * IN.color;
		}
			ENDCG
		}
	}
}