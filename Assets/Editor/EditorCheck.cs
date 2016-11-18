using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorCheck   {

	[MenuItem("Editor Check/Material/Get Material")]
	public static void ManipulateMaterial(){
		var r = GameObject.Find ("Sphere").GetComponent<Renderer> ();

		// ここでマテリアルが複製され、複製されたものが自動的にRendererにも設定されてしまう
		var mat = r.material;

		// 内部でこんなイメージの処理が走る
		// public Material material get{
		//     var newMaterial = new Material(this_material); // 複製する
		//     this_material = newMaterial; // 複製したもので自分も書き換えることで元々設定されてたものが影響を受けないように待避している
		//     return new Material;
		// }

		// なのでここで書き換えても、その情報は元のマテリアルには影響がない
		mat.SetTextureOffset ("_MainTex",new Vector2(0.25f,0.25f));

		// 実行時ではなくエディタ中でこのコードを走らせてしまうと、Rendererの持ってるマテリアルも変わってしまうので注意
		// また、実行時に走らせた場合は，明示的にDestroyしないと残り続ける
	}

	[MenuItem("Editor Check/Material/Get *Shared* Material")]
	public static void ManipulateSharedMaterial(){
		var r = GameObject.Find ("Sphere").GetComponent<Renderer> ();

		// ここでマテリアルが複製されないので、これで得た物を操作すると元々設定されていたファイルの内容が書き換わってしまう
		var mat = r.sharedMaterial;

		// ここを書き換えると元のマテリアル(アセットファイル)のプロパティを書き換えちゃう！
		mat.SetTextureOffset ("_MainTex",new Vector2(0.25f,-0.25f));
	}

}
