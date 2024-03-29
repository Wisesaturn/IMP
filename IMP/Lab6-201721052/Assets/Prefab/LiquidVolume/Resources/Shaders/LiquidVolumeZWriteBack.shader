﻿Shader "LiquidVolume/ZWriteBack" {
	Properties {
		_FlaskThickness ("Flask Thickness", Float) = 1
		_Color ("Color", Color) = (0,0,1,1)
	}
	SubShader {
	Tags { "RenderType" = "TransparentLiquid" }

	Pass {	
		Cull Front ZTest Greater

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
        #pragma fragmentoption ARB_precision_hint_fastest
        #pragma multi_compile _ LIQUID_VOLUME_FP_RENDER_TEXTURES

		#include "UnityCG.cginc"

		struct v2f {
			float4 pos: SV_POSITION;
		    float3 worldPos: TEXCOORD0;
		};
		
		float _FlaskThickness;

		v2f vert(appdata_base v) {
    		v2f o;
    		v.vertex.xyz *= _FlaskThickness;
    		o.pos = UnityObjectToClipPos(v.vertex);
    		o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
    		return o;
		}

		float4 frag (v2f i) : SV_Target {
            float dist = distance(_WorldSpaceCameraPos, i.worldPos);
            #if LIQUID_VOLUME_FP_RENDER_TEXTURES
			return dist;
			#else
			return EncodeFloatRGBA( 1.0 / (1.0 + dist) );
			#endif
		}
		ENDCG
	} 	

  }

}

    