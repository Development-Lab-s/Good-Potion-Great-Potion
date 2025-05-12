// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/RadialFill"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
        _Angle("Angle", Range(0, 360)) = 0
        _Arc1("Arc Point 1", Range(0, 360)) = 15
        _Arc2("Arc Point 2", Range(0, 360)) = 15
		_Size("Size", Range(0,1)) = 0.8
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;
			float _AlphaSplitEnabled;
			float _Angle;
			float _Arc1;
			float _Arc2;
			float _Size;

			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);

#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
				if (_AlphaSplitEnabled)
					color.a = tex2D (_AlphaTex, uv).r;
#endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

				return color;
			}

			///gpt가 진짜 최고다...
		fixed4 frag(v2f IN) : SV_Target
		{
		    fixed4 c = SampleSpriteTexture(IN.texcoord) * IN.color;
		    c.rgb *= c.a;
		
		    // 중심 기준 좌표 (-1 ~ 1)
		    float2 centeredUV = IN.texcoord * 2.0 - 1.0;
		    float angle = degrees(atan2(centeredUV.y, centeredUV.x));
		    if (angle < 0) angle += 360;
		
		    // Arc 범위 계산
		    float startAngle = _Angle - _Arc1;
		    float endAngle = _Angle + _Arc2;
		
		    // 0~360 사이로 조정
		    if (startAngle < 0) startAngle += 360;
		    if (endAngle >= 360) endAngle -= 360;
		
		    // 각도 포함 여부 판단 (360도 래핑 고려)
		    bool insideArc = startAngle < endAngle ?
		        (angle >= startAngle && angle <= endAngle) :
		        (angle >= startAngle || angle <= endAngle);
		
		    if (!insideArc) discard;
		
		    // 중심 거리 기반 내부 비우기
		    float dist = length(centeredUV);
		    if (dist < _Size) discard;
		
		    return c;
		}

		ENDCG
		}
	}
}