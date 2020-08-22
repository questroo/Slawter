Shader "RC_MultiLayer"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Color01("Color01", 2D) = "white" {}
		_Color02("Color02", 2D) = "white" {}
		_Color_mask("Color_mask", 2D) = "white" {}
		_Spec01("Spec01", 2D) = "white" {}
		_Spec02("Spec02", 2D) = "white" {}
		_Spec01_multi("Spec01_multi", Range( 0 , 1)) = 1
		_Spec02_multi("Spec02_multi", Range( 0 , 1)) = 1
		_Smoothness("Smoothness", Range( 0 , 1)) = 0
		_normal01("normal01", 2D) = "white" {}
		_Normal02("Normal02", 2D) = "white" {}
		_Normal01_multi("Normal01_multi", Vector) = (1,1,1,0)
		_Normal02_multi("Normal02_multi", Vector) = (1,1,1,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float2 texcoord_0;
		};

		uniform sampler2D _normal01;
		uniform float4 _normal01_ST;
		uniform float3 _Normal01_multi;
		uniform sampler2D _Normal02;
		uniform float4 _Normal02_ST;
		uniform float3 _Normal02_multi;
		uniform sampler2D _Color_mask;
		uniform sampler2D _Color01;
		uniform float4 _Color01_ST;
		uniform sampler2D _Color02;
		uniform float4 _Color02_ST;
		uniform sampler2D _Spec01;
		uniform float4 _Spec01_ST;
		uniform float _Spec01_multi;
		uniform sampler2D _Spec02;
		uniform float4 _Spec02_ST;
		uniform float _Spec02_multi;
		uniform float _Smoothness;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			o.texcoord_0.xy = v.texcoord2.xy * float2( 1,1 ) + float2( 0,0 );
		}

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_normal01 = i.uv_texcoord * _normal01_ST.xy + _normal01_ST.zw;
			float2 uv_Normal02 = i.uv_texcoord * _Normal02_ST.xy + _Normal02_ST.zw;
			float4 tex2DNode5 = tex2D( _Color_mask, i.texcoord_0 );
			float3 lerpResult19 = lerp( ( UnpackNormal( tex2D( _normal01, uv_normal01 ) ) * _Normal01_multi ) , ( UnpackNormal( tex2D( _Normal02, uv_Normal02 ) ) * _Normal02_multi ) , tex2DNode5.r);
			o.Normal = lerpResult19;
			float2 uv_Color01 = i.uv_texcoord * _Color01_ST.xy + _Color01_ST.zw;
			float2 uv_Color02 = i.uv_texcoord * _Color02_ST.xy + _Color02_ST.zw;
			float4 lerpResult3 = lerp( tex2D( _Color01, uv_Color01 ) , tex2D( _Color02, uv_Color02 ) , tex2DNode5.r);
			o.Albedo = lerpResult3.rgb;
			float3 temp_cast_3 = (0.0).xxx;
			o.Emission = temp_cast_3;
			float2 uv_Spec01 = i.uv_texcoord * _Spec01_ST.xy + _Spec01_ST.zw;
			float2 uv_Spec02 = i.uv_texcoord * _Spec02_ST.xy + _Spec02_ST.zw;
			float4 lerpResult6 = lerp( ( tex2D( _Spec01, uv_Spec01 ) * _Spec01_multi ) , ( tex2D( _Spec02, uv_Spec02 ) * _Spec02_multi ) , tex2DNode5.r);
			o.Specular = lerpResult6.rgb;
			o.Smoothness = _Smoothness;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
}