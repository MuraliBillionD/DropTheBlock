Shader "Custom/CustomShader"
{
  Properties
  {
	  _MainTex("Texture",2D) = "white"{}
      _Color("Color",COLOR)={1,1,1,1}

  }
  SubShader
  {
	  Pass
	  {

		  CGPROGRAM


		  ENDCG
      }
  }
}
