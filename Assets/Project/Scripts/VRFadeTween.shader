Shader "Custom/VRFadeSphere"
{
    Properties
    {
        _Color ("Color", Color) = (0, 0, 0, 1)   // 淡入淡出颜色，通常为黑色
        _Alpha ("Alpha", Range(0, 1)) = 0        // 透明度，脚本通过此值控制
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"              // 透明渲染队列
            "RenderType" = "Transparent"
            "IgnoreProjector" = "True"
        }

        // 关闭深度写入，确保不会遮挡其他物体
        ZWrite Off
        // 使用传统的透明度混合
        Blend SrcAlpha OneMinusSrcAlpha
        // 剔除正面，只渲染球体内表面（摄像机在球内）
        Cull Front

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                UNITY_VERTEX_OUTPUT_STEREO      // 支持单 Pass 立体渲染 (VR)
            };

            UNITY_INSTANCING_BUFFER_START(Props)
                UNITY_DEFINE_INSTANCED_PROP(float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP(float, _Alpha)
            UNITY_INSTANCING_BUFFER_END(Props)

            v2f vert (appdata v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_OUTPUT(v2f, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);

                float4 color = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
                float alpha = UNITY_ACCESS_INSTANCED_PROP(Props, _Alpha);

                color.a *= alpha;   // 结合材质属性的 Alpha 与颜色 Alpha
                return color;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}