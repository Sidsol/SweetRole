using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetRole.Models
{
    public class Scene
    {
        public int SceneID { get; set; }
        public string Name { get; set; }
        public string Setting { get; set; }

        public int StoryID { get; set; }
        public virtual Story Story { get; set; }

        public virtual ICollection<CharacterScene> CharacterScenes { get; set; }

    }
}
