 Shader "Custom/SurfaceShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags{"RenderType" = "Opaque"}
        CGPROGRAM
        #pragma surface surf Lambert
        sampler2D _MainTex;

        struct Input
        {
            float2 /*유니티로 치면 Vector2*/ uv_MainTex;
        };
        void surf(Input IN, inout SurfaceOutput o)
        {

        }
        ENDCG   
    }
    FallBack "Diffuse"
}
