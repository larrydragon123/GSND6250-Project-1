using Conversa.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "Actor", menuName = "Conversa/Actor with avatar", order = 0)]
public class AvatarActor : Actor
    {
        [SerializeField] private Sprite avatar;
        public Sprite Avatar => avatar;

    }
