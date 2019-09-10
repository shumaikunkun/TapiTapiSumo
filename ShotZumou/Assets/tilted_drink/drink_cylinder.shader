Shader "Unlit/drink_cylinder"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_Level ("Level", Range(0,1)) = 1
		_UpperRadius ("Upper radius", Float) = 1
		_LowerRadius ("Lower radius", Float) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "DisableBatching"="True"}
		LOD 100
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 rotOrig : TEXCOORD0;
				float3 orig : TEXCOORD1;
			};

			fixed4 _Color;
			float _Level;
			float _UpperRadius;
			float _LowerRadius;

			v2f vert (appdata v)
			{
				#if !defined(SHADER_API_OPENGL)
				if(v.vertex.z >	0) {

					float scale = pow(abs(determinant((float3x3)unity_ObjectToWorld)),1.0/3);
					float top = mul(unity_ObjectToWorld, float3(0,0,0.9999) / scale).y;
					float theta = acos(top);
					float level = (sin(theta) * (-_UpperRadius) + cos(theta) * (1.0)) * scale;
					float lowest = (sin(theta) * (-_LowerRadius) + cos(theta) * (-1.0)) * scale;
					float quantity = lowest + _Level * scale * 2;
					level = min(level, quantity);

					// (rotated vertex).y == level
					float3 d = float3(v.vertex.xy * (_UpperRadius - _LowerRadius), 2);
					v.vertex.xy *= _UpperRadius;
					float rotated = mul((float3x3)unity_ObjectToWorld, v.vertex).y;
					float dContrib = mul((float3x3)unity_ObjectToWorld, d).y;

					if(dContrib > 0.0) {
						// rotated + dContrib * dd == level
						float le = (level - rotated) / dContrib;
						v.vertex.xyz += d * le;
					}
				} else {
					v.vertex.xy *= _LowerRadius;
				}
				#endif

				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.rotOrig = mul((float3x3)unity_ObjectToWorld, v.vertex);
				o.orig = v.vertex;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				clip(i.orig.z - (-1.0));
				float scale = pow(abs(determinant((float3x3)unity_ObjectToWorld)),1.0/3);
				float top = mul(unity_ObjectToWorld, float3(0,0,0.9999) / scale).y;
				float theta = acos(top);
				float level = (sin(theta) * (-_UpperRadius) + cos(theta) * (1.0)) * scale;
				float lowest = (sin(theta) * (-_LowerRadius) + cos(theta) * (-1.0)) * scale;
				float quantity = lowest + _Level * scale * 2;
				level = min(level, quantity);

				clip(level - lowest);
				float ratio = (i.rotOrig.y - lowest) / (level - lowest);
				clip(1.0001 - ratio);
				return _Color;
			}
			ENDCG
		}
	}
}
