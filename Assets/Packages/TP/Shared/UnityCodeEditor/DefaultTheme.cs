using UnityEngine;

namespace Ardenfall.UnityCodeEditor
{
    public class DefaultTheme : CodeTheme
    {
        // public override string background => "#" + ColorUtility.ToHtmlStringRGBA(new Color(1, 2, 3));
        // public override string color => "#" + ColorUtility.ToHtmlStringRGBA(Color.green);
        // public override string selection => "#" + ColorUtility.ToHtmlStringRGBA(Color.white);
        // public override string cursor => "#" + ColorUtility.ToHtmlStringRGBA(Color.white);
        
        public override string background => "#262626";
        public override string color => "#dddddd";
        public override string selection => "#08335e";
        public override string cursor => "00ff00";
    }
}