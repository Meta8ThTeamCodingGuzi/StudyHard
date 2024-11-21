 Shader "Custom/SurfaceShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        OverlapTex ("Overlap Texture", 2D) = "gray" {}
        _ColorMultiple("Color Multiplier", Range(0,1)) = 1 
        _ClippingMultiple("Clipping Multiplier", integer) = 1
        _ClippingInclin("Clipping Inclination", float) = 1
    }
    SubShader
    {
        Tags{"RenderType" = "Opaque"}
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _MainTex;
        sampler2D OverlapTex;
        float _ColorMultiple;
        int _ClippingMultiple;
        float _ClippingInclin;

        struct Input
        {
            float2 /*유니티로 치면 Vector2*/ uv_MainTex;
            //float2 uvOverlapTex;
            float4 screenPos;
            float3 worldPos;
        };
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            clip(frac((IN.worldPos.y * _ClippingMultiple) + (IN.worldPos.x * _ClippingInclin)) - 0.4);
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _ColorMultiple;
            //o.Albedo *= tex2D(OverlapTex, IN.uvOverlapTex);
            float2 screenUV = (IN.screenPos.xy / IN.screenPos.w) * float2(10,5);

            float2 timeScale = float2(0 , _SinTime.w);

            o.Albedo *= tex2D(OverlapTex, screenUV + timeScale).rgb * 2;

            
        }

        ENDCG   
    }
    FallBack "Diffuse"
}
