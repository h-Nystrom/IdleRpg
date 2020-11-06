  using UnityEngine.UI;

  namespace Common {
      /// <summary>
      /// This component should be used, whenever you need elements to be hit by a Graphic-Raycaster, without
      /// producing any necessary drawcalls. Most common usage: on Button gameObjects to add a rect collider.
      /// </summary>
      public class EmptyGraphic : Graphic {
#if !UNITY_5_0 && !UNITY_5_1
          protected override void OnPopulateMesh (VertexHelper vh) {
              vh.Clear ();
          }
#else
          protected override void OnFillVBO (List<UIVertex> vbo) {
              vbo.Clear ();
          }
#endif
      }
  }