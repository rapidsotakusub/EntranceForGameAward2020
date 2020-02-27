Shader "Custom/box" {
	Properties{
	 _Color("Color", Color) = (1,1,1,1)
	 _MainTex("Albedo (RGB)", 2D) = "white" {}
	 _Glossiness("Smoothness", Range(0,1)) = 0.5
	 _Metallic("Metallic", Range(0,1)) = 0.0
	}
		SubShader{
		 Tags { "RenderType" = "Opaque" }
		 LOD 200

		 CGPROGRAM

		 #pragma surface surf Standard fullforwardshadows vertex:vert
		 #pragma target 3.0

		 sampler2D _MainTex;

		 struct Input {
		  float2 uv_MainTex;
		  float2 scaleXY;
		 };

		 void vert(inout appdata_full v, out Input o) {

		  UNITY_INITIALIZE_OUTPUT(Input, o);

		  // スケールを取得する
		  float scaleX = length(float3(unity_ObjectToWorld[0].x, unity_ObjectToWorld[1].x, unity_ObjectToWorld[2].x));
		  float scaleY = length(float3(unity_ObjectToWorld[0].y, unity_ObjectToWorld[1].y, unity_ObjectToWorld[2].y));
		  o.scaleXY = float2(scaleX, scaleY);
		 }

		 half _Glossiness;
		 half _Metallic;
		 fixed4 _Color;

		 void surf(Input IN, inout SurfaceOutputStandard o) {

			 // スケールに合わせてUVを調整する
			 fixed4 c = tex2D(_MainTex, IN.uv_MainTex * IN.scaleXY) * _Color;
			 o.Albedo = c.rgb;
			 o.Metallic = _Metallic;
			 o.Smoothness = _Glossiness;
			 o.Alpha = c.a;
			}
			ENDCG
	 }
		 FallBack "Diffuse"
}