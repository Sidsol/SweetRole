using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.Models
{
    public class CharacterScene
    {
        //public int CharacterSceneId { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }

        public int SceneId { get; set; }
        public Scene Scene { get; set; }
    }
}
