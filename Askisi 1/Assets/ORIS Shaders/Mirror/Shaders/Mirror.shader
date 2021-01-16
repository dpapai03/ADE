// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ORIS/Mirror"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_RenderTexture("Render Texture", 2D) = "white" {}
		_RTColor("RT Color", Color) = (0,0,0,0)
		_Dirty("Dirty", 2D) = "white" {}
		_DirtyColor("Dirty Color", Color) = (0,0,0,0)
		_DirtyPressence("Dirty Pressence", Float) = 0
		_BrockenGlass("Brocken Glass", 2D) = "white" {}
		[Toggle]_OpacityOnOff("Opacity OnOff", Float) = 1
		[Toggle]_InvertOpacity("Invert Opacity", Float) = 1
		_OpacityValue("Opacity Value", Float) = 1
		_DistortionIntensity("Distortion Intensity", Range( -5 , 5)) = 0
		_Specular("Specular", 2D) = "white" {}
		_SpecularColor("Specular Color", Color) = (0,0,0,0)
		_SpecularIntensity("Specular Intensity", Float) = 0
		_Smoothness("Smoothness", 2D) = "white" {}
		_SmoothnessIntensity("Smoothness Intensity", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Background+0" }
		Cull Back
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#pragma target 3.0
		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _BrockenGlass;
		uniform float _DistortionIntensity;
		uniform float4 _BrockenGlass_ST;
		uniform float4 _RTColor;
		uniform sampler2D _RenderTexture;
		uniform sampler2D _Dirty;
		uniform float4 _Dirty_ST;
		uniform float4 _DirtyColor;
		uniform float _DirtyPressence;
		uniform sampler2D _Specular;
		uniform float4 _Specular_ST;
		uniform float4 _SpecularColor;
		uniform float _SpecularIntensity;
		uniform sampler2D _Smoothness;
		uniform float4 _Smoothness_ST;
		uniform float _SmoothnessIntensity;
		uniform float _InvertOpacity;
		uniform float _OpacityOnOff;
		uniform float _OpacityValue;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			float2 uv0_BrockenGlass = i.uv_texcoord * _BrockenGlass_ST.xy + _BrockenGlass_ST.zw;
			float3 tex2DNode14 = UnpackScaleNormal( tex2D( _BrockenGlass, uv0_BrockenGlass ), _DistortionIntensity );
			o.Normal = tex2DNode14;
			float4 appendResult3 = (float4(( 1.0 - i.uv_texcoord.x ) , i.uv_texcoord.y , 0.0 , 0.0));
			float2 uv_Dirty = i.uv_texcoord * _Dirty_ST.xy + _Dirty_ST.zw;
			float4 lerpResult26 = lerp( ( _RTColor * tex2D( _RenderTexture, appendResult3.xy ) ) , ( tex2D( _Dirty, uv_Dirty ) * _DirtyColor ) , _DirtyPressence);
			o.Albedo = lerpResult26.rgb;
			float2 uv_Specular = i.uv_texcoord * _Specular_ST.xy + _Specular_ST.zw;
			o.Specular = ( ( tex2D( _Specular, uv_Specular ) * _SpecularColor ) * _SpecularIntensity ).rgb;
			float2 uv_Smoothness = i.uv_texcoord * _Smoothness_ST.xy + _Smoothness_ST.zw;
			o.Smoothness = ( (tex2D( _Smoothness, uv_Smoothness )).r * _SmoothnessIntensity );
			o.Alpha = 1;
			float temp_output_23_0 = ( lerp(1.0,tex2DNode14.r,_OpacityOnOff) * _OpacityValue );
			clip( lerp(( 1.0 - temp_output_23_0 ),temp_output_23_0,_InvertOpacity) - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17000
7;7;1904;1004;2767.154;-985.504;1.054276;True;True
Node;AmplifyShaderEditor.CommentaryNode;29;-2033.671,-318.9434;Float;False;1068.861;376.5303;Brocken Glass;4;12;13;14;4;;1,1,1,1;0;0
Node;AmplifyShaderEditor.TexturePropertyNode;4;-1983.671,-268.5132;Float;True;Property;_BrockenGlass;Brocken Glass;6;0;Create;True;0;0;False;0;None;f8a1791aa2432d74c83eb6abb4440a95;True;white;Auto;Texture2D;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.RangedFloatNode;13;-1668.934,-57.41302;Float;False;Property;_DistortionIntensity;Distortion Intensity;10;0;Create;True;0;0;False;0;0;1.93;-5;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;12;-1663.67,-191.2131;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;14;-1284.81,-268.9434;Float;True;Property;_BrockenGlassTexture;BrockenGlass Texture;1;0;Create;True;0;0;False;0;None;None;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WireNode;49;-848.6436,-91.58726;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;48;-909.1254,81.21935;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;27;-2250.038,-1392.008;Float;False;1787.005;875.1925;Diffuse (Mirror + Dirty);11;1;2;3;11;10;9;8;21;16;18;26;;1,1,1,1;0;0
Node;AmplifyShaderEditor.WireNode;50;-1401.624,111.4606;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;47;-2287.257,202.1839;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;1;-2200.038,-1163.832;Float;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WireNode;46;-2581.028,958.2137;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;2;-1893.038,-1142.832;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;44;-2356.765,1423.44;Float;False;1174.492;526.2037;Opacity;6;23;33;37;22;32;36;;1,1,1,1;0;0
Node;AmplifyShaderEditor.DynamicAppendNode;3;-1656.037,-1136.832;Float;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;36;-2301.525,1475.398;Float;False;Constant;_OpacityDefault;Opacity Default;16;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;45;-2419.084,1502.843;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;31;-2004.188,866.4276;Float;False;828.2195;374.6145;Smoothness;4;5;19;15;24;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;10;-1459.384,-1165.438;Float;True;Property;_RenderTexture;Render Texture;1;0;Create;True;0;0;False;0;None;3fe96ccc265d54348b02f678d9390417;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;9;-1458.711,-946.7092;Float;True;Property;_Dirty;Dirty;3;0;Create;True;0;0;False;0;None;f6c31d030ace6af4d9a3c0b7c9e76580;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;8;-1423.243,-726.1579;Float;False;Property;_DirtyColor;Dirty Color;4;0;Create;True;0;0;False;0;0,0,0,0;0.3661005,0.3616501,0.4056604,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ToggleSwitchNode;37;-2064.667,1473.44;Float;True;Property;_OpacityOnOff;Opacity OnOff;7;0;Create;True;0;0;False;0;1;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;11;-1370.128,-1342.008;Float;False;Property;_RTColor;RT Color;2;0;Create;True;0;0;False;0;0,0,0,0;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;22;-2037.128,1742.721;Float;False;Property;_OpacityValue;Opacity Value;9;0;Create;True;0;0;False;0;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;30;-2039.937,201.9566;Float;False;821.9612;452.1008;Specular;5;7;17;20;25;6;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;23;-1835.471,1694.991;Float;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;21;-1108.656,-631.8153;Float;False;Property;_DirtyPressence;Dirty Pressence;5;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;6;-1989.937,251.9566;Float;True;Property;_Specular;Specular;11;0;Create;True;0;0;False;0;None;199f3ab4fbb606446a5fc08ae78df9b2;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-1077.144,-1256.043;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-1081.244,-742.1005;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;5;-1954.188,916.4276;Float;True;Property;_Smoothness;Smoothness;14;0;Create;True;0;0;False;0;None;c3a679387b52b7b4b851878f54f6d34c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;7;-1906.986,447.0574;Float;False;Property;_SpecularColor;Specular Color;12;0;Create;True;0;0;False;0;0,0,0,0;0.8207547,0.7839353,0.4994215,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;17;-1672.459,504.7241;Float;False;Property;_SpecularIntensity;Specular Intensity;13;0;Create;True;0;0;False;0;0;0.23;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;15;-1625.532,1126.042;Float;False;Property;_SmoothnessIntensity;Smoothness Intensity;15;0;Create;True;0;0;False;0;0;2.53;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;26;-647.033,-767.7198;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ComponentMaskNode;19;-1623.793,917.0249;Float;True;True;False;False;False;1;0;COLOR;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;20;-1597.394,360.8087;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;33;-1615.803,1670.249;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;25;-1386.976,418.9815;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ToggleSwitchNode;32;-1436.273,1691.644;Float;True;Property;_InvertOpacity;Invert Opacity;8;0;Create;True;0;0;False;0;1;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;28;-168.3983,-448.1568;Float;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;-1344.969,923.9611;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;StandardSpecular;ORIS/Mirror;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;TransparentCutout;;Background;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;12;2;4;0
WireConnection;14;0;4;0
WireConnection;14;1;12;0
WireConnection;14;5;13;0
WireConnection;49;0;14;1
WireConnection;48;0;49;0
WireConnection;50;0;48;0
WireConnection;47;0;50;0
WireConnection;46;0;47;0
WireConnection;2;0;1;1
WireConnection;3;0;2;0
WireConnection;3;1;1;2
WireConnection;45;0;46;0
WireConnection;10;1;3;0
WireConnection;37;0;36;0
WireConnection;37;1;45;0
WireConnection;23;0;37;0
WireConnection;23;1;22;0
WireConnection;16;0;11;0
WireConnection;16;1;10;0
WireConnection;18;0;9;0
WireConnection;18;1;8;0
WireConnection;26;0;16;0
WireConnection;26;1;18;0
WireConnection;26;2;21;0
WireConnection;19;0;5;0
WireConnection;20;0;6;0
WireConnection;20;1;7;0
WireConnection;33;0;23;0
WireConnection;25;0;20;0
WireConnection;25;1;17;0
WireConnection;32;0;33;0
WireConnection;32;1;23;0
WireConnection;28;0;26;0
WireConnection;24;0;19;0
WireConnection;24;1;15;0
WireConnection;0;0;28;0
WireConnection;0;1;14;0
WireConnection;0;3;25;0
WireConnection;0;4;24;0
WireConnection;0;10;32;0
ASEEND*/
//CHKSM=F2DDAF2067D1EDECF04AA1E5DE9E6EBA80D98073