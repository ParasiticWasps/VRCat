Shader "Custom/ToonOutline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("Outline Width", Range(0, 0.1)) = 0.01
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        // Pass 1: 渲染外轮廓
        Pass
        {
            Cull Front // 剔除正面，只渲染背面

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float _OutlineWidth;
            float4 _OutlineColor;

            v2f vert (appdata v)
            {
                v2f o;
                // 1. 将顶点沿法线方向外扩
                float3 extrudedPos = v.vertex.xyz + v.normal * _OutlineWidth;
                o.vertex = UnityObjectToClipPos(extrudedPos);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // 2. 直接输出轮廓颜色
                return _OutlineColor;
            }
            ENDCG
        }

        // Pass 2: 正常渲染模型（此处省略，可用标准表面着色器替代）
    }
}