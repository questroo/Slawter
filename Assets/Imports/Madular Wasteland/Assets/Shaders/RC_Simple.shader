Shader "RC_simple"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_Color("Color", 2D) = "white" {}
		_Specular("Specular", 2D) = "white" {}
		_Normal("Normal", 2D) = "white" {}
		_Spec_multi("Spec_multi", Range( 0 , 1)) = 0
		_Smoothness("Smoothness", Range( 0 , 1)) = 0
		_Normal_multi("Normal_multi", Vector) = (1,1,1,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform float3 _Normal_multi;
		uniform sampler2D _Color;
		uniform float4 _Color_ST;
		uniform sampler2D _Specular;
		uniform float4 _Specular_ST;
		uniform float _Spec_multi;
		uniform float _Smoothness;

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = ( UnpackNormal( tex2D( _Normal, uv_Normal ) ) * _Normal_multi );
			float2 uv_Color = i.uv_texcoord * _Color_ST.xy + _Color_ST.zw;
			o.Albedo = tex2D( _Color, uv_Color ).rgb;
			float3 temp_cast_1 = (0.0).xxx;
			o.Emission = temp_cast_1;
			float2 uv_Specular = i.uv_texcoord * _Specular_ST.xy + _Specular_ST.zw;
			o.Specular = ( tex2D( _Specular, uv_Specular ) * _Spec_multi ).xyz;
			o.Smoothness = _Smoothness;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	
}